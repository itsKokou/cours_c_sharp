using Gestion_Cours.back.data.dto;
using Gestion_Cours.back.data.entities;
using Gestion_Cours.back.data.repositories;
using System;
using System.Collections.Generic;
using System.Data;

namespace Gestion_Cours.back.services.impl
{
    public class ProfesseurService : IProfesseurService
    {
        private readonly IProfesseurRepository professeurRepository;
        private  ICoursService coursService;
        public ICoursService CoursService { get => coursService; set => coursService = value; }

        private ProfesseurService(IProfesseurRepository professeurRepository)
        {
            this.professeurRepository = professeurRepository;
        }

        //==============================================================

        public static IProfesseurService professeurService = null;
        public static IProfesseurService GetInstance(IProfesseurRepository professeurRepository)
        {
            if (professeurService == null)
            {
                professeurService = new ProfesseurService(professeurRepository);
            }
            return professeurService;
        }
        //===============================================================

        public int add(Professeur entity)
        {
            return this.professeurRepository.insert(entity);
        }

        public int archivate(int id)
        {
            return this.professeurRepository.archivate(id);
        }

        public Professeur findById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Professeur> getAll()
        {
            List<Professeur> professeurs = new List<Professeur>();
            DataTable dataTable = professeurRepository.findAll();
            foreach (DataRow row in dataTable.Rows)
            {
                professeurs.Add(new Professeur()
                {
                    Id = int.Parse(row.ItemArray[0].ToString()),
                    NomComplet = row.ItemArray[1].ToString(),
                    Portable = row.ItemArray[2].ToString(),
                    Login = row.ItemArray[3].ToString(),
                });
            }
            return professeurs;
        }

        public List<Enseignement> getEnseignementsByClasse(int classeID)
        {
            List<Enseignement> enseignements = new List<Enseignement>();
            DataTable dataTable = professeurRepository.findEnseignementsByClasse(classeID);
            foreach (DataRow row in dataTable.Rows)
            {
                enseignements.Add(new Enseignement()
                {
                    Id = int.Parse(row.ItemArray[0].ToString())
                });
            }
            return enseignements;
        }

        public List<Enseignement> getEnseignementsByProfesseur(int profID)
        {
            List<Enseignement> enseignements = new List<Enseignement>();
            DataTable dataTable = professeurRepository.findEnseignementsByProfesseur(profID);
            foreach (DataRow row in dataTable.Rows)
            {
                enseignements.Add(new Enseignement()
                {
                    Id = int.Parse(row.ItemArray[0].ToString()),
                    Classe = new Classe()
                    {
                        Id = int.Parse(row.ItemArray[1].ToString()),
                        Name = row.ItemArray[2].ToString(),
                        Effectif = int.Parse(row.ItemArray[3].ToString()),
                        Niveau = new Niveau(){Id=int.Parse(row.ItemArray[4].ToString()), Name= row.ItemArray[5].ToString(),},
                        Filiere = new Filiere(){Id=int.Parse(row.ItemArray[6].ToString()), Name= row.ItemArray[7].ToString(),},
                    }
                });
            }
            return enseignements;
        }

        public List<Module> getModulesByEnseignement(int enseignementID)
        {
            List<Module> modules = new List<Module>();
            DataTable dataTable = professeurRepository.findModulesByEnseignement(enseignementID);
            foreach (DataRow row in dataTable.Rows)
            {
                modules.Add(new Module()
                {
                    Id = int.Parse(row.ItemArray[0].ToString()),
                    Name = row.ItemArray[1].ToString(),
                    IsArchived = Convert.ToBoolean(row.ItemArray[2]),
                });
            }
            return modules; 
        }

        public List<Professeur> getProfesseurByPortable(string portable)
        {
            List<Professeur> professeurs = new List<Professeur>();
            DataTable dataTable = professeurRepository.findProfesseurByPortable(portable);
            foreach (DataRow row in dataTable.Rows)
            {
                professeurs.Add(new Professeur()
                {
                    Id = int.Parse(row.ItemArray[0].ToString()),
                    NomComplet = row.ItemArray[1].ToString(),
                    Portable = row.ItemArray[2].ToString(),
                    Login = row.ItemArray[3].ToString(),
                });
            }
            return professeurs;
        }

        public int update(Professeur entity)
        {
            return this.professeurRepository.update(entity);
        }

        private List<Professeur> getByModule(Module module) // Les professeur d'un module
        {
            List<Professeur> professeurs = getAll();
            List<Professeur> professeursModules = new List<Professeur>();

            foreach (var professeur in professeurs)
            {
                List<Enseignement> enseignements = getEnseignementsByProfesseur(professeur.Id);
                foreach (var ens in enseignements)
                {
                    List<Module> modulesEnseignes = getModulesByEnseignement(ens.Id);
                    if (modulesEnseignes.Contains(module))
                    {
                        professeursModules.Add(professeur);
                        break;
                    }
                }
            } 
            
            return professeursModules;
        }

        public List<Professeur> getProfDisponibles(Module module, DateTime date, DateTime heureD, DateTime heureF)
        {
            List<Professeur> professeurs = new List<Professeur>();
            professeurs = getByModule(module);
            List<Professeur> professeursDisponibles = new List<Professeur>();
            if (professeurs != null || professeurs.Count != 0)
            {
                foreach (Professeur professeur in professeurs)
                {
                    int isDisponible = 1;
                    List<CoursDto5Attributs> listCours = coursService.getAllByProfesseurAndClasse(professeur.Id, 0);
                    if (listCours != null || listCours.Count != 0)
                    {
                        foreach (CoursDto5Attributs cours in listCours)
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
                        if (isDisponible == 1)
                        {
                            professeursDisponibles.Add(professeur);
                        }
                    }
                }
            }
            return professeursDisponibles;
        }

        public List<Classe> getClassesEnseigneesByProfesseurAndModule(int professeur, Module module)
        {
            List<Classe> classes = new List<Classe>();
            List<Enseignement> Enseignements = this.getEnseignementsByProfesseur(professeur);

            foreach (var ens in Enseignements)
            {
                List<Module> modules = this.getModulesByEnseignement(ens.Id);
                if (modules.Contains(module))
                {
                    classes.Add(ens.Classe);
                }
            }
            return classes;
        }
        public List<Classe> getClassesEnseigneesByProfesseur(int professeur)
        {
            List<Classe> classes = new List<Classe>();
            List<Enseignement> Enseignements = this.getEnseignementsByProfesseur(professeur);

            foreach (var ens in Enseignements)
            {
                classes.Add(ens.Classe);
            }
            return classes;
        }
    }
}
