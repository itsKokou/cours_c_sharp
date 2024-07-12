using Gestion_Etudiant.back.data.entities;
using Gestion_Etudiant.back.data.repositories;
using Gestion_Etudiant.back.services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.back.services.impl
{
    public class ClasseService : IClasseService
    {
        private IClasseRepository classeRepository;
        private IFiliereRepository filiereRepository;
        private INiveauRepository niveauRepository;

        public ClasseService(IClasseRepository classeRepository, IFiliereRepository filiereRepository, INiveauRepository niveauRepository)
        {
            this.classeRepository = classeRepository;
            this.filiereRepository = filiereRepository;
            this.niveauRepository = niveauRepository;
        }

        public int addClasse(Classe classe)
        {
            return classeRepository.add(classe);
        }

        public int deleteClasse(int id)
        {
            return classeRepository.delete(id);
        }


        public DataTable getAllClasse()
        {
            /*List<Classe> classes = new List<Classe>();
            DataTable dataTable = classeRepository.GetAll();
            foreach (DataRow row in dataTable.Rows)
            {
                classes.Add(new Classe() 
                { 
                    Id = int.Parse(row.ItemArray[0].ToString()), 
                    Name = row.ItemArray[1].ToString(),
                    Niveau = new Niveau() { Name = row.ItemArray[2].ToString() },
                    Filiere = new Filiere() { Name = row.ItemArray[3].ToString() }
                });
            }
            return classes;*/
            return classeRepository.GetAll();
        }

        public List<Filiere> getAllFiliere()
        {
            List<Filiere> filieres = new List<Filiere>();
            DataTable dataTable = filiereRepository.GetAll();
            foreach (DataRow row in dataTable.Rows)
            {
                filieres.Add(new Filiere() { Id = int.Parse(row.ItemArray[0].ToString()), Name = row.ItemArray[1].ToString() });
            }
            return filieres;
        }

        public List<Niveau> getAllNiveau()
        {
            List<Niveau> niveaux = new List<Niveau>();
            DataTable dataTable = niveauRepository.GetAll();
            foreach (DataRow row in dataTable.Rows)
            {
                niveaux.Add(new Niveau() { Id = int.Parse(row.ItemArray[0].ToString()), Name = row.ItemArray[1].ToString() });
            }
            return niveaux;
        }

        public int updateClasse(Classe classe)
        {
            return classeRepository.update(classe);
        }
    }
}
