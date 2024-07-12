using Gestion_Etudiant.back.core.impl;
using Gestion_Etudiant.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.back.data.repositories.impl
{
    public class GradeRepository :DataBase, IGradeRepository
    {
        public int add(Grade entity)
        {
            string SQL_INSERT = string.Format("INSERT INTO grade ([name]) OUTPUT INSERTED.ID VALUES ('{0}')", entity.Name);
            return ExecuteUpdate(SQL_INSERT);
        }

        public int delete(int id)
        {
            string SQL_DELETE = string.Format("DELETE FROM grade OUTPUT DELETED.ID WHERE [id] = {0}", id);
            return ExecuteUpdate(SQL_DELETE);
        }

        public DataTable GetAll()
        {
            string SQL_SELECT = "select * from grade";
            this.tableName = "ALLGRADE";
            return ExecuteSelect(SQL_SELECT);
        }

        public Grade GetValue(int id)
        {
            throw new NotImplementedException();
        }

        public int update(Grade entity)
        {
            string SQL_UPDATE = string.Format("UPDATE grade SET [name] = '{0}' WHERE [id] = {1}", entity.Name, entity.Id);
            return ExecuteUpdate(SQL_UPDATE);
        }
    }
}
