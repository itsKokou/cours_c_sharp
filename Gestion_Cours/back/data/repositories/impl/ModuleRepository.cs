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
    public class ModuleRepository : DataBase, IModuleRepository
    {
        private ModuleRepository()
        {
        }

        public static IModuleRepository moduleRepository = null;
        public static IModuleRepository GetInstance()
        {
            if (moduleRepository == null)
            {
                moduleRepository = new ModuleRepository();
            }
            return moduleRepository;
        }

        public int archivate(int id)
        {
            string SQL_DELETE = string.Format("UPDATE modules SET [isArchived] = '{0}' WHERE [id] = {1}", 1, id);
            return ExecuteUpdate(SQL_DELETE);
        }

        public DataTable findAll()
        {
            string SQL_SELECT = string.Format("select * from modules where isArchived like {0}", 0);
            this.tableName = "ALLMODULE";
            return ExecuteSelect(SQL_SELECT);
        }

        public DataTable findById(int id)
        {
            throw new NotImplementedException();
        }

        public int insert(Module entity)
        {
            string SQL_INSERT = string.Format("INSERT INTO modules ([name]) OUTPUT INSERTED.ID VALUES ('{0}')", entity.Name);
            return ExecuteUpdate(SQL_INSERT);
        }

        public int update(Module entity)
        {
            string SQL_UPDATE = string.Format("UPDATE modules SET [name] = '{0}' WHERE [id] = {1}", entity.Name, entity.Id);
            return ExecuteUpdate(SQL_UPDATE);
        }
    }
}
