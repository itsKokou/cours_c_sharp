using Exam.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.back.services
{
    public interface IArticleService
    {
        Article getByReference(string reference);
        int update(Article article);
    }
}
