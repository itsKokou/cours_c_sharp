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
        
        private ClasseRepository()  {  }

        public static IClasseRepository classeRepository = null;
        public static IClasseRepository GetInstance()
        {
            if (classeRepository == null)
            {
                classeRepository = new ClasseRepository();
            }
            return classeRepository;
        }

        public int insert(Classe entity)
        {
            string SQL_INSERT = string.Format("INSERT INTO classes ([name],[effectif],[niveauID],[filiereID]) OUTPUT INSERTED.ID VALUES ('{0}',{1},{2},{3})", entity.Name,entity.Effectif ,entity.Niveau.Id, entity.Filiere.Id);
            return ExecuteUpdate(SQL_INSERT);
        }

        public int insertModule(int classeID, int moduleID)
        {
            string SQL_INSERT_MODULE = string.Format("INSERT INTO classe_modules ([classeID],[moduleID]) OUTPUT INSERTED.ID VALUES ({0},{1})", classeID, moduleID);
            return ExecuteUpdate(SQL_INSERT_MODULE);
        }

        public int archivate(int id)
        {
            string SQL_DELETE = string.Format("UPDATE classes SET [isArchived] = {0} WHERE [id] = {1}", 1,id);
            return ExecuteUpdate(SQL_DELETE);
        }

        public DataTable findClasseModules(int classeID)
        {
            string SQL_SELECT_CLASSEMODULES = string.Format("select m.* from classe_modules cm, modules m where cm.moduleID=m.id and cm.classeID={0}", classeID);
            this.tableName = "CLASSEMODULES";
            return ExecuteSelect(SQL_SELECT_CLASSEMODULES);
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

        public DataTable findById(int id)
        {
            string SQL_SELECT = string.Format("select c.id,c.name,c.effectif,c.isArchived,n.*,f.* from classes c, niveaux n, filieres f where c.niveauID=n.id and c.filiereID=f.id and c.isArchived like {0} and c.id ={1}", 0, id);
            this.tableName = "ALLCLASSE_BY_ID";
            return ExecuteSelect(SQL_SELECT);
        }

     
        public int update(Classe entity)
        {
            string SQL_UPDATE = string.Format("UPDATE classes SET [name] = '{0}',[effectif] = {1} ,[niveauID] = {2} ,[filiereID] = {3} WHERE [id] = {4}", entity.Name,entity.Effectif,entity.Niveau.Id,entity.Filiere.Id,entity.Id);
            return ExecuteUpdate(SQL_UPDATE);
        }

        
    }
}
