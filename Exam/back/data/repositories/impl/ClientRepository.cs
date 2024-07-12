using Exam.back.core.impl;
using Exam.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.back.data.repositories.impl
{
    internal class ClientRepository : DataBase, IClientRepository
    {
        public DataTable findByPortable(string portable)
        {
                string SQL_SELECT = string.Format("select * from clients where portable like '%{0}%' ",portable);
                this.tableName = "UNCLIENT";
                return ExecuteSelect(SQL_SELECT);
        }
    }
}
