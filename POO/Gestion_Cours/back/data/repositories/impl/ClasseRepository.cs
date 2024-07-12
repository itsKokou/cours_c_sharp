using Gestion_Cours.back.core;
using Gestion_Cours.back.data.entities;
using Gestion_Cours.back.data.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Gestion_Cours.back.core.impl;

namespace Gestion_Cours.back.data.repositories.impl
{
    public class ClasseRepository : DataBase,IClasseRepository
    {
        
        public ClasseRepository()
        {
        }

        public int insert(Classe entity)
        {
            string SQL_INSERT = string.Format("INSERT INTO classes ([name],[effectif],[niveauID],[filiereID]) OUTPUT INSERTED.ID VALUES ('{0}',{1},{2},{3})", entity.Name,entity.Effectif ,entity.Niveau.Id, entity.Filiere.Id);
            return ExecuteUpdate(SQL_INSERT);
        }

        public int archivate(int id)
        {
            string SQL_DELETE = string.Format("UPDATE classe SET [isArchived] = '{0}' WHERE [id] = {1}", 1,id);
            return ExecuteUpdate(SQL_DELETE);
        }

        public DataTable findAll()
        {
            string SQL_SELECT = string.Format("select c.id,c.name,c.effectif,c.isArchived,n.*,f.* from classes c, niveaux n, filieres f where c.niveauID=n.id and c.filiereID=f.id and c.isArchived like {0}", 0);
            this.tableName = "ALLCLASSE";
            return ExecuteSelect(SQL_SELECT);
        }

        public DataTable findByNiveau(int niveauId)
        {
            string SQL_SELECT = string.Format("select c.id,c.name,c.effectif,c.isArchived,n.*,f.* from classes c, niveaux n, filieres f where c.niveauID=n.id and c.filiereID=f.id and c.isArchived like {0} and n.id ={1}", 0,niveauId);
            this.tableName = "ALLCLASSE_BY_NIVEAU";
            return ExecuteSelect(SQL_SELECT);
        }

        public DataTable findByFiliere(int filiereId)
        {
            string SQL_SELECT = string.Format("select c.id,c.name,c.effectif,c.isArchived,n.*,f.* from classes c, niveaux n, filieres f where c.niveauID=n.id and c.filiereID=f.id and c.isArchived like {0} and f.id ={1}", 0,filiereId);
            this.tableName = "ALLCLASSE_BY_FILIERE";
            return ExecuteSelect(SQL_SELECT);
        }

        public DataTable findByNiveauAndFiliere(int niveauId, int filiereId)
        {
            string SQL_SELECT_BY = "";
            if (niveauId == 0 && filiereId == 0)
            {
                SQL_SELECT_BY = string.Format("select c.id,c.name,c.effectif,c.isArchived,n.*,f.* from classes c, niveaux n, filieres f where c.niveauID=n.id and c.filiereID=f.id and c.isArchived like {0}", 0);
                this.tableName = "ALLCLASSE";
            }
            else if (filiereId == 0 && niveauId !=0) 
            {
                SQL_SELECT_BY = string.Format("select c.id,c.name,c.effectif,c.isArchived,n.*,f.* from classes c, niveaux n, filieres f where c.niveauID=n.id and c.filiereID=f.id and c.isArchived like {0} and n.id ={1}", 0, niveauId);
                this.tableName = "ALLCLASSE_BY_NIVEAU";
            }
            else if (filiereId != 0 && niveauId ==0) 
            {
                SQL_SELECT_BY = string.Format("select c.id,c.name,c.effectif,c.isArchived,n.*,f.* from classes c, niveaux n, filieres f where c.niveauID=n.id and c.filiereID=f.id and c.isArchived like {0} and f.id ={1}", 0, filiereId);
                this.tableName = "ALLCLASSE_BY_NIVEAU";
            }
            else if(filiereId != 0 && niveauId != 0)
            {
                SQL_SELECT_BY = string.Format("select c.id,c.name,c.effectif,c.isArchived,n.*,f.* from classes c, niveaux n, filieres f where c.niveauID=n.id and c.filiereID=f.id and c.isArchived like {0} and n.id ={1} and f.id={2}", 0, niveauId, filiereId);
                this.tableName = "ALLCLASSE_BY_NIVEAU_AND_FILIERE";
            }

            return ExecuteSelect(SQL_SELECT_BY);
        }

        public Classe findById(int id)
        {
            throw new NotImplementedException();
        }

     
        public int update(Classe entity)
        {
            //string SQL_UPDATE = string.Format("UPDATE classe SET [name] = '{0}',[id_niveau] = {1}  ,[id_filiere] = {2} WHERE [id] = {3}",entity.Name,entity.Niveau.Id,entity.Filiere.Id,entity.Id);
            //return ExecuteUpdate(SQL_UPDATE);
            return 0;
        }

        
    }
}
