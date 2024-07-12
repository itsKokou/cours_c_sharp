using Examen_C_.back.core.impl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_C_.back.data.repositories.impl
{
    public class ClientRepositoryImpl : DataBase, IClientRepository
    {
        public ClientRepositoryImpl()
        {
        }

        public DataTable findClientByPortable(string portable)
        {
            string SQL_SELECT = String.Format("SELECT * FROM clients WHERE portable like '%{0}%'", portable);
            this.tableName = "CLIENT";
            return ExecuteSelect(SQL_SELECT);
        }
    }
}
