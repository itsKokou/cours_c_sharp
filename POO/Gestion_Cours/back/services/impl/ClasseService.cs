using Gestion_Cours.back.data.entities;
using Gestion_Cours.back.data.repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.services.impl
{
    public class ClasseService : IClasseService
    {
        private readonly IClasseRepository classeRepository;
        private readonly INiveauRepository niveauRepository;
        private readonly IFiliereRepository filiereRepository;

        public ClasseService(IClasseRepository classeRepository, INiveauRepository niveauRepository, IFiliereRepository filiereRepository)
        {
            this.classeRepository = classeRepository;
            this.niveauRepository = niveauRepository;
            this.filiereRepository = filiereRepository;
        }

        public int add(Classe entity)
        {
            return this.classeRepository.insert(entity);
        }

        public int archivate(int id)
        {
            throw new NotImplementedException();
        }

        public Classe findById(int id)
        {
            throw new NotImplementedException();
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

        public int update(Classe entity)
        {
            throw new NotImplementedException();
        }
    }
}
