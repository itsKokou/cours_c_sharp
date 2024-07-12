using Gestion_Cours.back.core.impl;
using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.data.repositories.impl
{
    public class CoursRepository : DataBase, ICoursRepository
    {
        public CoursRepository()
        {
        }

        public int archivate(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable findAll()
        {
            throw new NotImplementedException();
        }

        public Cours findById(int id)
        {
            throw new NotImplementedException();
        }

        public int insert(Cours entity)
        {
            throw new NotImplementedException();
        }

        public int update(Cours entity)
        {
            throw new NotImplementedException();
        }
    }
}
