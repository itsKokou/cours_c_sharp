using Gestion_Etudiant.back.core;
using Gestion_Etudiant.back.core.impl;
using Gestion_Etudiant.back.data.entities;
using Gestion_Etudiant.back.data.repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.back.data.repositories.impl
{
    public class NiveauRepository :DataBase, INiveauRepository
    {
        public NiveauRepository() 
        {
        }

        public int add(Niveau entity)
        {
            
            return 1;
        }

        public int delete(int id)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAll()
        {
            string SQL_SELECT = "select * from niveau";
            this.tableName = "ALLNIVEAU";
            return ExecuteSelect(SQL_SELECT);
        }

        public Niveau GetValue(int id)
        {
            throw new NotImplementedException();
    }

        public int update(Niveau entity)
        {
            throw new NotImplementedException();
        }
    }
}
