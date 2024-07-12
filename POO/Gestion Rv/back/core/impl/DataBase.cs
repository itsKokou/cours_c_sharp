using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Rv.back.core.impl
{
    public class DataBase:IDataBase
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["GESTION_RV"].ConnectionString;
        private SqlConnection connection = new SqlConnection();
        //Convertir les formats de données :
        //prends ligne de table puis convertir en objet
        private SqlDataAdapter adapter = new SqlDataAdapter();
        protected string tableName;
        public void CloseConnexion()
        {
            if (connection.State == ConnectionState.Open || connection.State == ConnectionState.Connecting)
            {
                connection.Close();
            }
        }

        public DataTable ExecuteSelect(string sql)
        {
            try
            {
                OpenConnexion();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = sql;
                adapter.SelectCommand = command;//Donnée en objet ici
                DataSet ds = new DataSet(); //La base de donnée en mémoire
                                            //Les données tables seront stockées dans tableName
                if (ds.Tables[tableName] != null)
                {
                    ds.Tables[tableName].Clear();
                }
                adapter.Fill(ds, tableName);
                CloseConnexion();

                return ds.Tables[tableName];
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int ExecuteUpdate(string sql)
        {
            try
            {
                int nbreLigne;
                OpenConnexion();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = sql;

                if (sql.ToLower().StartsWith("insert"))
                {
                    nbreLigne = Convert.ToInt32(command.ExecuteScalar());//return last Id
                }
                else
                {
                    nbreLigne = command.ExecuteNonQuery();
                }

                CloseConnexion();
                return nbreLigne;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void OpenConnexion()
        {
            if (connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken)
            {
                connection.ConnectionString = connectionString;
                connection.Open();
            }
        }
    }
}
