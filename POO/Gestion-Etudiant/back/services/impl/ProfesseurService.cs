using Gestion_Etudiant.back.data.entities;
using Gestion_Etudiant.back.data.repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.back.services.impl
{
    public class ProfesseurService : IProfesseurService
    {
        private IProfesseurRepository professeurRepository;
        private IGradeRepository gradeRepository;

        public ProfesseurService(IProfesseurRepository professeurRepository, IGradeRepository gradeRepository)
        {
            this.professeurRepository = professeurRepository;
            this.gradeRepository = gradeRepository;
        }

        public int addProfesseur(Professeur prof)
        {
           return professeurRepository.add(prof);
        }

        public int deleteProfesseur(int id)
        {
           return professeurRepository.delete(id);
        }

        public List<Grade> getAllGrade()
        {
            DataTable dataTable = gradeRepository.GetAll();
            List<Grade> grades = new List<Grade>();
            foreach (DataRow row in dataTable.Rows)
            {
                grades.Add(new Grade() { Id = (int)row.ItemArray[0], Name = row.ItemArray[1].ToString() });
            }
            return grades;
        }

        public DataTable getAllProfesseur()
        {
            /*DataTable dataTable = professeurRepository.GetAll();
            List<Professeur> professeurs = new List<Professeur>();
            foreach (DataRow row in dataTable.Rows)
            {
                professeurs.Add(new Professeur() { 
                    Id = int.Parse(row.ItemArray[0].ToString()), 
                    NomComplet = row.ItemArray[1].ToString(),
                    Login = row.ItemArray[2].ToString(),
                    Grade = new Grade() { Name = row.ItemArray[3].ToString()}
                });
            }
            return professeurs;*/
            return professeurRepository.GetAll();
        }

        public int updateProfesseur(Professeur prof)
        {
            return professeurRepository.update(prof);
        }
    }
}
