using Gestion_Cours.back.core.impl;
using Gestion_Cours.back.data.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Cours.back.data.repositories.impl
{
    public class ProfesseurRepository : DataBase, IProfesseurRepository
    {
        private ProfesseurRepository() { }

        public static IProfesseurRepository professeurRepository = null;
        public static IProfesseurRepository GetInstance()
        {
            if (professeurRepository == null)
            {
                professeurRepository = new ProfesseurRepository();
            }
            return professeurRepository;
        }


        public int insert(Professeur entity)
        {
            string SQL_INSERT = string.Format("INSERT INTO users ([nomComplet],[portable],[login],[password],[roleID]) OUTPUT INSERTED.ID VALUES ('{0}','{1}','{2}',ENCRYPTBYCERT(CERT_ID('CERT'),N'{3}'),{4})", entity.NomComplet, entity.Portable,entity.Login, entity.Password,2);
            int profID = ExecuteUpdate(SQL_INSERT);
            foreach (var ens in entity.Enseignements)
            {
               int ensID = insertEnseignement(profID, ens);
                foreach (var mod in ens.Modules)
                {
                    insertEnseignementModule(ensID, mod.Id);
                }
            }
            return profID;
        }

        private int insertEnseignement(int profID, Enseignement enseignement)
        {
            string SQL_INSERT = string.Format("INSERT INTO enseignements ([professeurID],[classeID]) OUTPUT INSERTED.ID VALUES ({0},{1})",profID, enseignement.Classe.Id);
            return ExecuteUpdate(SQL_INSERT);
        }

        private int insertEnseignementModule(int enseignementID, int moduleID)
        {
            string SQL_INSERT = string.Format("INSERT INTO enseignement_modules ([enseignementID],[moduleID]) OUTPUT INSERTED.ID VALUES ({0},{1})", enseignementID,moduleID);
            return ExecuteUpdate(SQL_INSERT);
        }

        public int archivate(int id)
        {
            string SQL_DELETE = string.Format("UPDATE users set [isArchived]={0} WHERE [id] = {1}", 1,id);
            return ExecuteUpdate(SQL_DELETE);
        }

        public DataTable findAll()
        {
            string SQL_SELECT = string.Format("select id, nomComplet,portable,login,isArchived from users where roleID= {0} and isArchived={1}",2,0);
            this.tableName = "ALLPROFESSEUR";
            return ExecuteSelect(SQL_SELECT);
        }

        public DataTable findById(int id)
        {
            throw new NotImplementedException();
        }

        public int update(Professeur entity)
        {
            string SQL_UPDATE = string.Format("UPDATE users SET [nomComplet] = '{0}',[portable] = '{1}',[login] = '{2}',[password] =ENCRYPTBYCERT(CERT_ID('CERT'),N'{3}') WHERE [id] = {4}", entity.NomComplet, entity.Portable, entity.Login, entity.Password,entity.Id);
            return ExecuteUpdate(SQL_UPDATE);
        }

        public DataTable findProfesseurByPortable(string portable)
        {
            string SQL_SELECT = string.Format("select id, nomComplet,portable,login,isArchived from users where roleID = {0} and isArchived={1} and portable like '%{2}%' ", 2, 0,portable);
            this.tableName = "PROFESSEUR_BY_PORTABLE";
            return ExecuteSelect(SQL_SELECT);
        }

        public DataTable findEnseignementsByClasse(int classeID)
        {
            string SQL_SELECT = string.Format("select * from enseignements where classeID = {0}", classeID);
            this.tableName = "ENSEIGNEMENTS_BY_CLASSE";
            return ExecuteSelect(SQL_SELECT);
        }
        public DataTable findEnseignementsByProfesseur(int profID)
        {
            string SQL_SELECT = string.Format("select e.id,cl.id,cl.name,cl.effectif,n.id,n.name,f.id,f.name from enseignements e,classes cl, niveaux n, filieres f where e.classeID=cl.id and cl.niveauID=n.id and cl.filiereID=f.id and e.professeurId={0}", profID);
            this.tableName = "ENSEIGNEMENTS_BY_CLASSE";
            return ExecuteSelect(SQL_SELECT);
        }
        public DataTable findModulesByEnseignement(int enseignementID)
        {
            string SQL_SELECT = string.Format("select m.* from enseignement_modules em, modules m where em.moduleID = m.id and em.enseignementID={0} ", enseignementID);
            this.tableName = "MODULE_BY_ENSEIGNEMENT";
            return ExecuteSelect(SQL_SELECT);
        }



        //Recuperer les enseignements de classe 
        //recuperer les modules un a un
    }
}
