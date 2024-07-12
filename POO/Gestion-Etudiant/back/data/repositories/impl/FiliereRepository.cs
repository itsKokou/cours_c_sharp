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
using System.Xml.Linq;

namespace Gestion_Etudiant.back.data.repositories.impl
{
    public class FiliereRepository :DataBase, IFiliereRepository
    {
        public FiliereRepository() 
        {
        }

        public int add(Filiere entity)
        {
            
            return 1;
        }

        public int delete(int id)
        {
            Filiere? filiere = GetValue(id);
            if (filiere != null)
            {
                
            }
            return 1;
        }

        public DataTable GetAll()
        {
            string SQL_SELECT = "select * from filiere";
            this.tableName = "ALLFILIERE";
            return ExecuteSelect(SQL_SELECT);
        }

        public Filiere GetValue(int id)
        {
            throw new NotImplementedException();
        }

        public int update(Filiere entity)
        {
            throw new NotImplementedException();
        }
    }
}

