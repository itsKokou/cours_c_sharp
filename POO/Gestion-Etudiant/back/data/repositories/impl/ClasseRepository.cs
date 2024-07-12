using Gestion_Etudiant.back.core;
using Gestion_Etudiant.back.data.entities;
using Gestion_Etudiant.back.data.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Gestion_Etudiant.back.core.impl;

namespace Gestion_Etudiant.back.data.repositories.impl
{
    public class ClasseRepository : DataBase,IClasseRepository
    {
        
        public ClasseRepository()
        {
        }

        public int add(Classe entity)
        {
            string SQL_INSERT = string.Format("INSERT INTO classe ([name],[id_niveau],[id_filiere]) OUTPUT INSERTED.ID VALUES ('{0}',{1},{2})", entity.Name, entity.Niveau.Id, entity.Filiere.Id);
            return ExecuteUpdate(SQL_INSERT);
        }

        public int delete(int id)
        {
            string SQL_DELETE = string.Format("DELETE FROM classe WHERE [id] = {0}", id);
            return ExecuteUpdate(SQL_DELETE);
        }

        public DataTable GetAll()
        {
            string SQL_SELECT = "select classe.id, classe.name,niveau.name as niveau, filiere.name as filiere from classe left join niveau on niveau.id=classe.id_niveau left join filiere on filiere.id=classe.id_filiere";
            this.tableName = "ALLCLASSE";
            return ExecuteSelect(SQL_SELECT);
        }

        public Classe GetValue(int id)
        {
            throw new NotImplementedException();
        }

        public int update(Classe entity)
        {
            string SQL_UPDATE = string.Format("UPDATE classe SET [name] = '{0}',[id_niveau] = {1}  ,[id_filiere] = {2} WHERE [id] = {3}",entity.Name,entity.Niveau.Id,entity.Filiere.Id,entity.Id);
            return ExecuteUpdate(SQL_UPDATE);
        }
    }
}
