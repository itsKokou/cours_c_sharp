using Exam.back.core.impl;
using Exam.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.back.data.repositories.impl
{
    public class ArticleRepository : DataBase, IArticleRepository
    {
        public DataTable findByReference(string reference)
        {
            string SQL_SELECT = string.Format("select * from articles where refrerence like '%{0}%' ",reference);
            this.tableName = "UNARTICLE";
            return ExecuteSelect(SQL_SELECT);
        }

        public int update(Article article)
        {
            string SQL_UPDATE = string.Format("UPDATE articles SET [qteCmd] = {0},[qteStock] = {1},[montant] = {2} WHERE [id] = {3}", article.QteCmd,article.QteStock,article.Montant,article.Id);
            return ExecuteUpdate(SQL_UPDATE);
        }
    }
}
