using Examen_C_.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_C_.back.services
{
    public interface IArticleService
    {
        Article getArticleByReference(string reference);
        int update(Article article);//Mettre à jour la qteStock après enregistrement de commande
    }
}
