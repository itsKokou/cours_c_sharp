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
using System.Xml.Linq;

namespace Gestion_Cours.back.data.repositories.impl
{
    public class FiliereRepository :DataBase, IFiliereRepository
    {
        private FiliereRepository() { }

        public static IFiliereRepository filiereRepository = null;
        public static IFiliereRepository GetInstance()
        {
            if (filiereRepository == null)
            {
                filiereRepository = new FiliereRepository();
            }
            return filiereRepository;
        }

        public int insert(Filiere entity)
        {
            
            return 1;
        }

        public int archivate(int id)
        {
            return 1;
        }

        public DataTable findAll()
        {
            string SQL_SELECT = "select * from filieres";
            this.tableName = "ALLFILIERE";
            return ExecuteSelect(SQL_SELECT);
        }

        public DataTable findById(int id)
        {
            throw new NotImplementedException();
        }

        public int update(Filiere entity)
        {
            throw new NotImplementedException();
        }

    }
}

