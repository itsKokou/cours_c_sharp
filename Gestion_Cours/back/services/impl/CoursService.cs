using Gestion_Cours.back.data.dto;
using Gestion_Cours.back.data.entities;
using Gestion_Cours.back.data.repositories;
using Gestion_Cours.back.data.repositories.impl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Module = Gestion_Cours.back.data.entities.Module;

namespace Gestion_Cours.back.services.impl
{
    public class CoursService : ICoursService
    {
        private readonly ICoursRepository coursRepository;
        private readonly ISalleService salleService;

        private CoursService(ICoursRepository coursRepository, ISalleService salleService)
        {
            this.coursRepository = coursRepository;
            this.salleService = salleService;
        }

        //==============================================================

        public static ICoursService coursService = null;
        public static ICoursService GetInstance(ICoursRepository coursRepository, ISalleService salleService)
        {
            if (coursService == null)
            {
                coursService = new CoursService(coursRepository, salleService);
            }
            return coursService;
        }
        //===============================================================

        public int add(Cours entity)
        {
            int id = this.coursRepository.insert(entity);
            foreach (var classe in entity.Classes)
            {
                this.coursRepository.insertClasse(id, classe.Id);
            }
            return id;
        }

        public int archivate(int id)
        {
            return this.coursRepository.archivate(id);
        }

        public Cours findById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cours> getAll()
        {
            throw new NotImplementedException();
        }

        public List<CoursDto5Attributs> getAllByProfesseurAndClasse(int professeur, int classe)
        {
            List<CoursDto5Attributs> courss = new List<CoursDto5Attributs>();
            DataTable dataTable = this.coursRepository.findAllByProfesseurAndClasse(professeur,classe);
            if (dataTable.Rows.Count !=0)
            {
                foreach (DataRow row in dataTable.Rows)
                {

                    courss.Add(new CoursDto5Attributs()
                    {
                        Id = int.Parse(row.ItemArray[0].ToString()),
                        Date = DateTime.Parse(row.ItemArray[1].ToString()),
                        HeureD = DateTime.Parse(row.ItemArray[2].ToString()),
                        HeureF = DateTime.Parse(row.ItemArray[3].ToString()),
                        Module = new Module() { Id = int.Parse(row.ItemArray[8].ToString()), Name = row.ItemArray[7].ToString() }
                    });
                }
            }
            
            return courss;
        }

        public List<CoursDto> getAllDto()
        {
            List<CoursDto> courss = new List<CoursDto>();
            DataTable dataTable = this.coursRepository.findAll();
            foreach (DataRow row in dataTable.Rows)
            {
                Salle salle = null;
                string strId = row.ItemArray[6].ToString();
                if (!string.IsNullOrEmpty(strId))
                {
                    salle = salleService.findById(int.Parse(strId));
                }
                string strSalle = " - ";
                string strCode = " - ";
                if (salle == null)
                {
                    strCode = row.ItemArray[4].ToString();
                }
                else
                {
                    strSalle = salle.Name;
                } 

                courss.Add(new CoursDto()
                {
                    Id = int.Parse(row.ItemArray[0].ToString()),
                    Date = DateTime.Parse(row.ItemArray[1].ToString()).ToString("dd-MM-yyyy"),
                    Code = strCode,
                    Module = row.ItemArray[7].ToString(),
                    Professeur = row.ItemArray[5].ToString(),
                    Salle = strSalle,
                    Horaire = string.Format("{0} à {1}", DateTime.Parse(row.ItemArray[2].ToString()).ToString("HH:mm"), DateTime.Parse(row.ItemArray[3].ToString()).ToString("HH:mm")),
                    Classes = ChangeClasseListToString(this.getCoursClasses(int.Parse(row.ItemArray[0].ToString())))
                });
            }
            return courss;
        }

        public List<CoursDto> getAllDtoByProfesseurAndClasse(int professeur, int classe)
        {
            List<CoursDto> courss = new List<CoursDto>();
            DataTable dataTable = this.coursRepository.findAllByProfesseurAndClasse(professeur,classe);
            foreach (DataRow row in dataTable.Rows)
            {
                Salle salle = null;
                string strId = row.ItemArray[6].ToString();
                if (!string.IsNullOrEmpty(strId))
                {
                    salle = salleService.findById(int.Parse(strId));
                }
                string strSalle = " - ";
                string strCode = " - ";
                if (salle == null)
                {
                    strCode = row.ItemArray[5].ToString();
                }
                else
                {
                    strSalle = salle.Name;
                }
                 
                
                courss.Add(new CoursDto()
                {
                    Id = int.Parse(row.ItemArray[0].ToString()),
                    Date = DateTime.Parse(row.ItemArray[1].ToString()).ToString("dd-MM-yyyy"),
                    Code = strCode,
                    Module = row.ItemArray[7].ToString(),
                    Professeur = row.ItemArray[5].ToString(),
                    Salle = strSalle,
                    Horaire = string.Format("{0} à {1}", DateTime.Parse(row.ItemArray[2].ToString()).ToString("HH:mm"), DateTime.Parse(row.ItemArray[3].ToString()).ToString("HH:mm")),
                    Classes = ChangeClasseListToString(this.getCoursClasses(int.Parse(row.ItemArray[0].ToString())))
                });
            }
            return courss;
        }

        private string ChangeClasseListToString(List<Classe> classes)
        {
            string strClasses = "| ";
            foreach (var classe in classes)
            {
                strClasses += classe.ToString();
                strClasses += " | ";
            }
            return strClasses;
        }

        public List<CoursDto4Attributs> getCoursBySalle(int salleID)
        {
            List<CoursDto4Attributs> courss = new List<CoursDto4Attributs>();
            DataTable dataTable = this.coursRepository.findCoursBySalle(salleID);
            foreach (DataRow row in dataTable.Rows)
            {

                courss.Add(new CoursDto4Attributs()
                {
                    Id = int.Parse(row.ItemArray[0].ToString()),
                    Date = DateTime.Parse(row.ItemArray[1].ToString()),
                    HeureD = DateTime.Parse(row.ItemArray[2].ToString()),
                    HeureF = DateTime.Parse(row.ItemArray[3].ToString())
                });
            }
            return courss;
        }

        public List<Classe> getCoursClasses(int cours)
        {
            List<Classe> classes = new List<Classe>();
            DataTable dataTable = coursRepository.findCoursClasses(cours);
            foreach (DataRow row in dataTable.Rows)
            {
                classes.Add(new Classe()
                {
                    Id = int.Parse(row.ItemArray[0].ToString()),
                    Name = row.ItemArray[1].ToString(),
                });
            }
            return classes;
        }

        
        public int update(Cours entity)
        {
            throw new NotImplementedException();
        }
    }
}
