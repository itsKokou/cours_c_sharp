using Exam.back.data.entities;
using Exam.back.data.repositories;
using Exam.back.data.repositories.impl;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.back.services.impl
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public Article getByReference(string reference)
        {
            Article article = null;
            DataTable dataTable = articleRepository.findByReference(reference);
            foreach (DataRow row in dataTable.Rows)
            {
                article = new Article()
                {
                    Id = int.Parse(row.ItemArray[0].ToString()),
                    Reference = row.ItemArray[1].ToString(),
                    Name = row.ItemArray[2].ToString(),
                    Prix =(double) row.ItemArray[3],
                    QteCmd =int.Parse (row.ItemArray[4].ToString()),
                    QteStock =int.Parse (row.ItemArray[5].ToString()),
                    Montant =(double)row.ItemArray[6],
                };
            }
            return article;
        }

        public int update(Article article)
        {
            return this.articleRepository.update(article);
        }
    }
}
