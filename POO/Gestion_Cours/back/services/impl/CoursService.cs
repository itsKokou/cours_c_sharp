using Gestion_Cours.back.data.entities;
using Gestion_Cours.back.data.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.services.impl
{
    public class CoursService : ICoursService
    {
        private readonly ICoursRepository coursRepository;

        public CoursService(ICoursRepository coursRepository)
        {
            this.coursRepository = coursRepository;
        }

        public int add(Cours entity)
        {
            throw new NotImplementedException();
        }

        public int archivate(int id)
        {
            throw new NotImplementedException();
        }

        public Cours findById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cours> getAll()
        {
            throw new NotImplementedException();
        }

        public int update(Cours entity)
        {
            throw new NotImplementedException();
        }
    }
}
