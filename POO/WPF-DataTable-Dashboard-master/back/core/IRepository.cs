using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours_Projet.core
{
    public interface IRepository<T>
    {
        DataTable findAll();
        T findById(int id);
        int add(T entity);
        int update(T entity);
        int Archivate(int id);
    }

}
