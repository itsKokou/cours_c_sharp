using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.services
{
    public interface IService<T>
    {
        int add(T entity);
        List<T> getAll();
        T findById(int id);
        int update(T entity);
        int archivate(int id);
    }
}
