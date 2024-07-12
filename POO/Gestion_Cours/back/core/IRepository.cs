using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.core
{
    public interface IRepository<T>
    {
        DataTable findAll();
        T findById(int id);
        int insert(T entity);
        int update(T entity);
        int archivate(int id);
    }

}
