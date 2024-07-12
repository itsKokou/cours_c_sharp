using Gestion_Cours.back.core;
using Gestion_Cours.back.core.impl;
using Gestion_Cours.back.data.entities;
using Gestion_Cours.back.data.repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.data.repositories.impl
{
    public class NiveauRepository :DataBase, INiveauRepository
    {
        private NiveauRepository() 
        {
        }

        public static INiveauRepository niveauRepository = null;
        public static INiveauRepository GetInstance()
        {
            if (niveauRepository == null)
            {
                niveauRepository = new NiveauRepository();
            }
            return niveauRepository;
        }

        public int insert(Niveau entity)
        {
            
            return 1;
        }

        public int archivate(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable findAll()
        {
            string SQL_SELECT = "select * from niveaux";
            this.tableName = "ALLNIVEAU";
            return ExecuteSelect(SQL_SELECT);
        }

        public DataTable findById(int id)
        {
            throw new NotImplementedException();
    }

        public int update(Niveau entity)
        {
            throw new NotImplementedException();
        }
    }
}
