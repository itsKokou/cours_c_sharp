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
    public class SalleRepository : DataBase, ISalleRepository
    {
        public SalleRepository()
        {
        }

        public int archivate(int id)
        {
            string SQL_DELETE = string.Format("UPDATE salles SET [isArchived] = '{0}' WHERE [id] = {1}", 1, id);
            return ExecuteUpdate(SQL_DELETE);
        }

        public DataTable findAll()
        {
            string SQL_SELECT = string.Format("select * from salles where isArchived like {0}", 0);
            this.tableName = "ALLSALLE";
            return ExecuteSelect(SQL_SELECT);
        }

        public Salle findById(int id)
        {
            throw new NotImplementedException();
        }

        public int insert(Salle entity)
        {
            string SQL_INSERT = string.Format("INSERT INTO salles ([name],[nbrePlace]) OUTPUT INSERTED.ID VALUES ('{0}',{1})", entity.Name, entity.NbrePlace);
            return ExecuteUpdate(SQL_INSERT);
        }

        public int update(Salle entity)
        {
            string SQL_UPDATE = string.Format("UPDATE salles SET [name] = '{0}',[nbrePlace] = {1} WHERE [id] = {2}", entity.Name, entity.NbrePlace, entity.Id);
            return ExecuteUpdate(SQL_UPDATE);
        }
    }
}
