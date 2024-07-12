using Examen_C_.back.core.impl;
using Examen_C_.back.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_C_.back.data.repositories.impl
{
    public class CommandeRepositoryImpl : DataBase,ICommandeRepository
    {
        private readonly IArticleRepository articleRepository; // Couplage faible
        public CommandeRepositoryImpl(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository; // Injection de dependance
        }

        public int insert(Commande commande)
        {
            string SQL_INSERT = string.Format("INSERT INTO commandes ([qteCmde],[montant],[client_id]) OUTPUT INSERTED.ID VALUES ({0},{1},{2})", commande.QteCmde,commande.Montant,commande.Client.Id);
            int commande_id = ExecuteUpdate(SQL_INSERT);

            foreach (var article in commande.Articles)
            {
                insertCommandeArticle(commande_id, article.Id);
                //Mise à jour de l'article (QteStock)
                articleRepository.update(article);
            }
            return commande_id;
        }

        private int insertCommandeArticle(int commande_id, int article_id)
        {
            string SQL_INSERT = string.Format("INSERT INTO commandes_articles ([article_id],[commande_id]) VALUES ({0},{1})", article_id, commande_id);
            return ExecuteUpdate(SQL_INSERT);
        }
    }
}
