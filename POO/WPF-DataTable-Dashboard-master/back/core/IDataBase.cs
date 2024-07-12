using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours_Projet.back.core
{
    public interface IDataBase
    {
        void OpenConnexion();
        void CloseConnexion();
        int ExecuteUpdate(string sql);
        DataTable ExecuteSelect(string sql);//table de base => table de memoire
    }
}
