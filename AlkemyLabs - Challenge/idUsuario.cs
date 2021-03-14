using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AlkemyLabs___Challenge
{
    public class idUsuario
    {
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataReader dr;
        dao obDao = new dao();
        public MySqlConnection connection;

        public static string traerID(string usser)
        {
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString()))
            {
                MySqlCommand cmd = new MySqlCommand();
                string MySQL = "SELECT stu.id_student FROM student stu INNER JOIN users us ON " +
                    "us.id_user = stu.id_user " +
                    "WHERE us.dni ="+ usser;
                try
                {
                    cmd = new MySqlCommand(MySQL, con);
                    con.Open();
                    MySqlDataReader Leer = cmd.ExecuteReader();

                    if (Leer.Read())
                    {
                        string idString = Leer["id_student"].ToString();
                        string id = idString;
                        Leer.Close();
                        con.Close();
                        return id;
                    }
                    else
                    {
                        Leer.Close();
                        con.Close();
                        return "0";
                    }
                }
                catch
                {
                    return "0";
                }
            }
        }
    }
}