using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace AlkemyLabs___Challenge
{
    public class dao
    {
        private MySqlConnection miConexion;
        //internal class CrearConexion
        //{
        public dao()
        {
            ConnectionStringSettings ConnectionSettings = ConfigurationManager.ConnectionStrings["con"];
            string conexionstring = ConnectionSettings.ConnectionString;
            miConexion = new MySqlConnection(conexionstring);
            miConexion.Open();
        }

        // destructor del acceso a datos MySql
        ~dao()
        {
            miConexion.Close();
        }

        public void cerrar()
        {
            miConexion.Close();
        }
        public MySqlConnection conexion()
        {
            return miConexion;
        }

        // realiza el query devuelve un DataTable
        public DataTable QueryDb_DataTable(string comando)
        {
            // genero un MySqlAdapter con la quyery recibida 
            MySqlDataAdapter queryAdapter = new MySqlDataAdapter(comando, miConexion);
            // creo el datatable
            DataTable querytable = new DataTable();
            // lleno el datatable con los datos
            queryAdapter.Fill(querytable);
            return querytable;// devuelvo el datatable
        }

        // realiza el query devuelve un MySqlDataReader 
        public MySqlDataReader QueryDb_MySqlDataReader(string comando)
        {
            MySqlCommand comandoMySql = new MySqlCommand(comando, miConexion);
            MySqlDataReader lectorDeDatos;
            lectorDeDatos = comandoMySql.ExecuteReader();
            while (lectorDeDatos.Read())
            {
            }
            return lectorDeDatos;
        }

        // realiza el query, es para updates, deletes o inserts
        public Boolean QueryDb_SinResultados(string comando)
        {

            MySqlCommand comandoMySql = new MySqlCommand(comando, miConexion);
            MySqlDataReader lectorDeDatos;
            lectorDeDatos = comandoMySql.ExecuteReader();
            while (lectorDeDatos.Read())
            {
            }
            lectorDeDatos.Close();
            return true;
        }



    }






}