using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_C_.back.data.repositories
{
    public interface IClientRepository
    {
        DataTable findClientByPortable(string portable);
    }
}
