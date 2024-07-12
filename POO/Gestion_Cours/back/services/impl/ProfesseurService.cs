using Gestion_Cours.back.data.entities;
using Gestion_Cours.back.data.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.services.impl
{
    public class ProfesseurService : IProfesseurService
    {
        private readonly IProfesseurRepository professeurRepository;

        public ProfesseurService(IProfesseurRepository professeurRepository)
        {
            this.professeurRepository = professeurRepository;
        }

        public int add(Professeur entity)
        {
            throw new NotImplementedException();
        }

        public int archivate(int id)
        {
            throw new NotImplementedException();
        }

        public Professeur findById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Professeur> getAll()
        {
            throw new NotImplementedException();
        }

        public int update(Professeur entity)
        {
            throw new NotImplementedException();
        }
    }
}
