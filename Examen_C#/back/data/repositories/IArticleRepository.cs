using Examen_C_.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_C_.back.data.repositories
{
    public interface IArticleRepository
    {
        DataTable findArticleByReference(string reference);
        int update(Article article);//Mettre à jour la qteStock après enregistrement de commande
    }
}
