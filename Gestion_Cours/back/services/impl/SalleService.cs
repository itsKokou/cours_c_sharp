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

namespace Gestion_Cours.back.services.impl
{
    public class SalleService : ISalleService
    {
        private readonly ISalleRepository salleRepository;
        private ICoursService coursService;
        public ICoursService CoursService { get => coursService; set => coursService = value; }

        private SalleService(ISalleRepository salleRepository)
        {
            this.salleRepository = salleRepository;
        }

        //==============================================================

        public static ISalleService salleService = null;
        public static ISalleService GetInstance(ISalleRepository salleRepository)
        {
            if (salleService == null)
            {
                salleService = new SalleService(salleRepository);
            }
            return salleService;
        }
        //===============================================================

        public int add(Salle entity)
        {
            return salleRepository.insert(entity);
        }

        public int archivate(int id)
        {
            return salleRepository.archivate(id);
        }

        public Salle findById(int id)
        {
            Salle salle = null;
            DataTable dataTable = salleRepository.findAll();
            foreach (DataRow row in dataTable.Rows)
            {
                salle = new Salle()
                {
                    Id = int.Parse(row.ItemArray[0].ToString()),
                    Name = row.ItemArray[1].ToString(),
                    NbrePlace = int.Parse(row.ItemArray[2].ToString()),
                    IsArchived = Convert.ToBoolean(row.ItemArray[3]),
                };
            }
            return salle;
        }

        public List<Salle> getAll()
        {
            List<Salle> salles = new List<Salle>();
            DataTable dataTable = salleRepository.findAll();
            foreach (DataRow row in dataTable.Rows)
            {
                salles.Add(new Salle()
                {
                    Id = int.Parse(row.ItemArray[0].ToString()),
                    Name = row.ItemArray[1].ToString(),
                    NbrePlace = int.Parse(row.ItemArray[2].ToString()),
                    IsArchived = Convert.ToBoolean(row.ItemArray[3]),     
               });
            }
            return salles;
        }

        public int update(Salle entity)
        {
            return salleRepository.update(entity);
        }

        public List<Salle> getSalleDisponibles(int nbrePlace,Module module, DateTime date, DateTime heureD, DateTime heureF)
        {
            List<Salle> salles = getAll();
            List<Salle> sallesDisponibles = new List<Salle>();
            int isDisponible;
            foreach (Salle salle in salles)
            {
                isDisponible = 1;
                if (salle.NbrePlace >= nbrePlace)
                {
                    List<CoursDto4Attributs> listCours = coursService.getCoursBySalle(salle.Id);
                    foreach (CoursDto4Attributs cours in listCours)
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
                        sallesDisponibles.Add(salle);
                    }
                }  
            }
            return sallesDisponibles;
        }
    }
}
