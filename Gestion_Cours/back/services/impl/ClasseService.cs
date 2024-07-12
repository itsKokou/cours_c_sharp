using Gestion_Cours.back.data.dto;
using Gestion_Cours.back.data.entities;
using Gestion_Cours.back.data.repositories;
using Gestion_Cours.back.data.repositories.impl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Gestion_Cours.back.services.impl
{
    public class ClasseService : IClasseService
    {
        private readonly IClasseRepository classeRepository;
        private readonly INiveauRepository niveauRepository;
        private readonly IFiliereRepository filiereRepository;

        private ICoursService coursService;
        public ICoursService CoursService { get => coursService; set => coursService = value; }

        private ClasseService(IClasseRepository classeRepository, INiveauRepository niveauRepository, IFiliereRepository filiereRepository)
        {
            this.classeRepository = classeRepository;
            this.niveauRepository = niveauRepository;
            this.filiereRepository = filiereRepository;
        }

        //==============================================================

        public static IClasseService classeService = null;
        public static IClasseService GetInstance(IClasseRepository classeRepository, INiveauRepository niveauRepository, IFiliereRepository filiereRepository)
        {
            if (classeService == null)
            {
                classeService = new ClasseService(classeRepository,niveauRepository,filiereRepository);
            }
            return classeService;
        }
        //===============================================================

        public int add(Classe entity)
        {
            int id = this.classeRepository.insert(entity);
            foreach (var module in entity.Modules)
            {
                this.classeRepository.insertModule(id, module.Id);
            }
            return id;
        }

        public int archivate(int id)
        {
            return this.classeRepository.archivate(id);
        }

        public Classe findById(int id)
        {
            Classe classe = null;
            DataTable dataTable = classeRepository.findById(id);
            foreach (DataRow row in dataTable.Rows)
            {
                classe= new Classe()
                {
                    Id = int.Parse(row.ItemArray[0].ToString()),
                    Name = row.ItemArray[1].ToString(),
                    Effectif = int.Parse(row.ItemArray[2].ToString()),
                    IsArchived = Convert.ToBoolean(row.ItemArray[3]),
                    Niveau = new Niveau() { Id = int.Parse(row.ItemArray[4].ToString()), Name = row.ItemArray[5].ToString() },
                    Filiere = new Filiere() { Id = int.Parse(row.ItemArray[6].ToString()), Name = row.ItemArray[7].ToString() }
                };
            }
            return classe;
        }

        public List<Classe> getAll()
        {
            List<Classe> classes = new List<Classe>();
            DataTable dataTable = classeRepository.findAll();
            foreach (DataRow row in dataTable.Rows)
            {
                classes.Add(new Classe() 
                { 
                    Id = int.Parse(row.ItemArray[0].ToString()), 
                    Name = row.ItemArray[1].ToString(),
                    Effectif = int.Parse(row.ItemArray[2].ToString()),
                    IsArchived = Convert.ToBoolean(row.ItemArray[3]),
                    Niveau = new Niveau() { Id = int.Parse(row.ItemArray[4].ToString()), Name = row.ItemArray[5].ToString() },
                    Filiere = new Filiere() { Id = int.Parse(row.ItemArray[6].ToString()), Name = row.ItemArray[7].ToString() }
                });
            }
            return classes;
        }

        public List<Classe> getAllByNiveauAndFiliere(int niveauId, int filiereId)
        {
            List<Classe> classes = new List<Classe>();
            DataTable dataTable = classeRepository.findByNiveauAndFiliere(niveauId,filiereId);
            foreach (DataRow row in dataTable.Rows)
            {
                classes.Add(new Classe()
                {
                    Id = int.Parse(row.ItemArray[0].ToString()),
                    Name = row.ItemArray[1].ToString(),
                    Effectif = int.Parse(row.ItemArray[2].ToString()),
                    IsArchived = Convert.ToBoolean(row.ItemArray[3]),
                    Niveau = new Niveau() { Id = int.Parse(row.ItemArray[4].ToString()), Name = row.ItemArray[5].ToString() },
                    Filiere = new Filiere() { Id = int.Parse(row.ItemArray[6].ToString()), Name = row.ItemArray[7].ToString() }
                });
            }
            return classes;
        }

        public List<Filiere> getAllFiliere()
        {
            List<Filiere> filieres = new List<Filiere>();
            DataTable dataTable = filiereRepository.findAll();
            foreach (DataRow row in dataTable.Rows)
            {
                filieres.Add(new Filiere() { Id = int.Parse(row.ItemArray[0].ToString()), Name = row.ItemArray[1].ToString() });
            }
            return filieres;
        }

        public List<Niveau> getAllNiveau()
        {
            List<Niveau> niveaux = new List<Niveau>();
            DataTable dataTable = niveauRepository.findAll();
            foreach (DataRow row in dataTable.Rows)
            {
                niveaux.Add(new Niveau() { Id = int.Parse(row.ItemArray[0].ToString()), Name = row.ItemArray[1].ToString() });
            }
            return niveaux;
        }

        public List<Module> getClasseModules(int classeID)
        {
            List<Module> classemodules = new List<Module>();
            DataTable dataTable = classeRepository.findClasseModules(classeID);
            foreach (DataRow row in dataTable.Rows)
            {
                classemodules.Add(new Module()
                {
                    Id = int.Parse(row.ItemArray[0].ToString()),
                    Name = row.ItemArray[1].ToString(),
                    IsArchived = Convert.ToBoolean(row.ItemArray[2])
                    });
            }
            return classemodules;
        }

        public int update(Classe entity)
        {
            return this.classeRepository.update(entity);
        }

        public List<Classe> getClasseDisponibles(Module module, DateTime date, DateTime heureD, DateTime heureF, List<Classe> classesDuProf)
        {
            List<Classe> classesDisponibles = new List<Classe>();

            int isDisponible;
            foreach (var classe in classesDuProf)
            {
                isDisponible = 1;
                List<CoursDto5Attributs> listCours = coursService.getAllByProfesseurAndClasse(0, classe.Id);
                foreach (var cours in listCours)
                {
                    if (cours.Module.Equals(module))
                    {
                        isDisponible = 0;
                        break;
                    }
                    else
                    {
                        if (cours.Date.Equals(date))
                        {
                            if (cours.HeureD.CompareTo(heureF) < 0 && heureF.CompareTo(cours.HeureF) < 0)
                            {
                                isDisponible = 0;
                                break;
                            }
                            else
                            {
                                if (cours.HeureD.CompareTo(heureD) < 0 && heureD.CompareTo(cours.HeureF) < 0)
                                {
                                    isDisponible = 0;
                                    break;
                                }
                                else
                                {
                                    if (heureD.CompareTo(cours.HeureD) < 0 && cours.HeureD.CompareTo(cours.HeureF) < 0 && cours.HeureF.CompareTo(heureF) < 0)
                                    {
                                        isDisponible = 0;
                                        break;
                                    }
                                    else
                                    {
                                        if (cours.HeureD.CompareTo(heureD) < 0 && heureD.CompareTo(heureF) < 0 && heureF.CompareTo(cours.HeureF) < 0)
                                        {
                                            isDisponible = 0;
                                            break;
                                        }
                                        else
                                        {
                                            if (cours.HeureD.CompareTo(heureD) == 0 && heureF.CompareTo(cours.HeureF) == 0)
                                            {
                                                isDisponible = 0;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (isDisponible == 1)
                {
                    classesDisponibles.Add(classe);
                }
            }
            return classesDisponibles;
        }

       
    }
}
