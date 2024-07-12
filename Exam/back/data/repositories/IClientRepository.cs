using Exam.back.core;
using Exam.back.core.impl;
using Exam.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.back.data.repositories
{
    public interface IClientRepository 
    {
        DataTable findByPortable(string portable);
    }
}
