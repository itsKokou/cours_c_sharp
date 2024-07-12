using Examen_C_.back.data.entities;
using Examen_C_.back.data.repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_C_.back.services.impl
{
    public class ArticleServiceImpl : IArticleService
    {
        private readonly IArticleRepository articleRepository;

        public ArticleServiceImpl(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public Article getArticleByReference(string reference)
        {
            Article article = null;
            DataTable dataTable = articleRepository.findArticleByReference(reference);
            foreach (DataRow row in dataTable.Rows)
            {
                article = new Article() 
                { 
                    Id = int.Parse(row.ItemArray[0].ToString()),
                    Reference = row.ItemArray[1].ToString(),
                    Libelle = row.ItemArray[2].ToString(),
                    Prix = (double)row.ItemArray[3],
                    QteStock = int.Parse(row.ItemArray[4].ToString())
                };
            }

            return article;
        }

        public int update(Article article)
        {
            return articleRepository.update(article);
        }
    }
}
