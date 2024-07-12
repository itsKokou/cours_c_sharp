using Gestion_Etudiant.back.core.impl;
using Gestion_Etudiant.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiant.back.data.repositories.impl
{
    public class ProfesseurRepository : DataBase, IProfesseurRepository
    {
        public int add(Professeur entity)
        {
            string SQL_INSERT = string.Format("INSERT INTO professeur ([nomComplet],[login],[password],[id_grade]) OUTPUT INSERTED.ID VALUES ('{0}','{1}',ENCRYPTBYCERT(CERT_ID('CERT'),N'{2}'),{3})", entity.NomComplet, entity.Login, entity.Password,entity.Grade.Id);
            return ExecuteUpdate(SQL_INSERT);
        }

        public int delete(int id)
        {
            string SQL_DELETE = string.Format("DELETE FROM professeur WHERE [id] = {0}", id);
            return ExecuteUpdate(SQL_DELETE);
        }

        public DataTable GetAll()
        {
            string SQL_SELECT = "select professeur.id, professeur.nomComplet,professeur.login,grade.name as grade from professeur left join grade on professeur.id_grade=grade.id";
            this.tableName = "ALLPROFESSEUR";
            return ExecuteSelect(SQL_SELECT);
        }

        public Professeur GetValue(int id)
        {
            throw new NotImplementedException();
        }

        public int update(Professeur entity)
        {
            string SQL_UPDATE = string.Format("UPDATE professeur SET [nomComplet] = '{0}',[login] = '{1}',[password] =ENCRYPTBYCERT(CERT_ID('CERT'),N'{2}'),[id_grade] = {3} WHERE [id] = {4}", entity.NomComplet, entity.Login, entity.Password, entity.Grade.Id,entity.Id);
            return ExecuteUpdate(SQL_UPDATE);
        }
    }
}
