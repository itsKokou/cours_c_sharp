using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.back.core
{
    public interface IRepository<T>
    {
        DataTable GetAll();
        T GetValue(int id);
        int add(T entity);
        int update(T entity);
        int delete(int id);
    }
}
