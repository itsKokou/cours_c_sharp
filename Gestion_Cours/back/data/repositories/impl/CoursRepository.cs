using Gestion_Cours.back.core.impl;
using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.data.repositories.impl
{
    public class CoursRepository : DataBase, ICoursRepository
    {
        private CoursRepository() { }

        public static ICoursRepository coursRepository = null;
        public static ICoursRepository GetInstance()
        {
            if (coursRepository == null)
            {
                coursRepository = new CoursRepository();
            }
            return coursRepository;
        }

        public int insert(Cours entity)
        {
            string SQL_INSERT;
            if (entity.Salle == null)
            {
                SQL_INSERT = string.Format("INSERT INTO courss ([date],[heureD],[heureF],[codeCours],[professeurID],[moduleID]) OUTPUT INSERTED.ID VALUES ('{0}','{1}','{2}','{3}',{4},{5})", entity.Date.ToString("yyyy-MM-dd"), entity.HeureD.ToString("HH:mm"), entity.HeureF.ToString("HH:mm"), entity.Code,entity.Professeur.Id,entity.Module.Id);
            }
            else
            {
                SQL_INSERT = string.Format("INSERT INTO courss ([date],[heureD],[heureF],[salleID],[professeurID],[moduleID]) OUTPUT INSERTED.ID VALUES ('{0}','{1}','{2}',{3},{4},{5})", entity.Date.ToString("yyyy-MM-dd"), entity.HeureD.ToString("HH:mm"), entity.HeureF.ToString("HH:mm"), entity.Salle.Id,entity.Professeur.Id,entity.Module.Id);
            }
            return ExecuteUpdate(SQL_INSERT);
        }

        public int insertClasse(int coursID, int classeID)
        {
            string SQL_INSERT_MODULE = string.Format("INSERT INTO cours_classes ([coursID],[classeID]) OUTPUT INSERTED.ID VALUES ({0},{1})", coursID, classeID);
            return ExecuteUpdate(SQL_INSERT_MODULE);
        }

        public int archivate(int id)
        {
            string SQL_DELETE = string.Format("UPDATE courss SET [isArchived] = {0} WHERE [id] = {1}", 1, id);
            return ExecuteUpdate(SQL_DELETE);
        }

        public DataTable findAll()
        {
            string SQL_SELECT = string.Format("SELECT c.id,c.date,c.heureD,c.heureF,c.codeCours,p.nomComplet,c.salleID,m.name FROM courss c, users p, modules m WHERE c.professeurID=p.id and c.moduleID=m.id and c.isArchived like {0}", 0);
            this.tableName = "ALLCOURS";
            return ExecuteSelect(SQL_SELECT);
        }

        public DataTable findAllByProfesseurAndClasse(int professeur, int classe)
        {
            string SQL_SELECT_BY = "";
            
            if (professeur == 0 && classe != 0)
            {
                SQL_SELECT_BY = string.Format("SELECT c.id,c.date,c.heureD,c.heureF,c.codeCours,p.nomComplet,c.salleID,m.name,m.id FROM courss c, users p, modules m,cours_classes cc WHERE c.professeurID=p.id and c.moduleID=m.id and cc.coursID=c.id  and c.isArchived like {0} and cc.classeID={1}", 0, classe);
                this.tableName = "ALLCOURS_BY_CLASSE";
            }
            else if (professeur != 0 && classe == 0)
            {
                SQL_SELECT_BY = string.Format("SELECT c.id,c.date,c.heureD,c.heureF,c.codeCours,p.nomComplet,c.salleID,m.name,m.id FROM courss c, users p, modules m WHERE c.professeurID=p.id and c.moduleID=m.id and c.isArchived like {0} and c.professeurID={1}", 0, professeur);
                this.tableName = "ALLCOURS_BY_PROFESSEUR";
            }
            else if (professeur != 0 && classe != 0)
            {
                SQL_SELECT_BY =  string.Format("SELECT c.id,c.date,c.heureD,c.heureF,c.codeCours,p.nomComplet,c.salleID,m.name,m.id FROM courss c, users p, modules m,cours_classes cc WHERE c.professeurID=p.id and c.moduleID=m.id and cc.coursID=c.id  and c.isArchived like {0} and cc.classeID={1} and c.professeurID={2}", 0, classe,professeur);
                this.tableName = "ALLCOURS_BY_PROFESSEUR_CLASSE";
            }

            return ExecuteSelect(SQL_SELECT_BY);
        }

        public DataTable findById(int id)
        {
            throw new NotImplementedException();
        }


        public int update(Cours entity)
        {
            throw new NotImplementedException();
        }

        public DataTable findCoursClasses(int cours)
        {
            string SQL_SELECT = string.Format("SELECT cl.id, cl.name FROM cours_classes cc, classes cl WHERE cc.classeID=cl.id and cc.coursID={0}",cours);
            this.tableName = "ALL_COURS_CLASSES";
            return ExecuteSelect(SQL_SELECT);
        }

        public DataTable findCoursBySalle(int salleID)
        {
            string SQL_SELECT = string.Format("SELECT c.id,c.date,c.heureD,c.heureF FROM courss c WHERE c.isArchived like {0} and c.salleID={1}", 0,salleID);
            this.tableName = "ALLCOURS_BY_SALLE";
            return ExecuteSelect(SQL_SELECT);
        }
    }
}
