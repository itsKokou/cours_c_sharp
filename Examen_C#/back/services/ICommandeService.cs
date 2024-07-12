using Examen_C_.back.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_C_.back.services
{
    public interface ICommandeService
    {
        int save(Commande commande);
    }
}
