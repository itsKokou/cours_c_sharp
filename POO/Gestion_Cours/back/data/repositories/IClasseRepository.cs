using Gestion_Cours.back.core;
using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.data.repositories
{
    public interface IClasseRepository : IRepository<Classe>
    {
        DataTable findByNiveauAndFiliere(int niveauId, int filiereId);//Test si 0 pour prendre en cpte
    }
}
