using Examen_C_.back.core.impl;
using Examen_C_.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_C_.back.data.repositories.impl
{
    public class ArticleRepositoryImpl : DataBase, IArticleRepository
    {
        public ArticleRepositoryImpl()
        {
        }

        public DataTable findArticleByReference(string reference)
        {
            string SQL_SELECT = String.Format("SELECT * FROM articles WHERE reference like '%{0}%'", reference);
            this.tableName = "ARTICLE";
            return ExecuteSelect(SQL_SELECT);
        }

        public int update(Article article)
        {
            string SQL_UPDATE = string.Format("UPDATE articles SET [qteStock] = {0} WHERE [id] = {1}", article.QteStock, article.Id);
            return ExecuteUpdate(SQL_UPDATE);
        }
    }
}
