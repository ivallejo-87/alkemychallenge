using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace AlkemyLabs___Challenge.Profesores
{
    public partial class AltaProfesores : System.Web.UI.Page
    {
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataReader dr;
        dao obDao = new dao();
        public MySqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            AltaUser();
            int iduser = traerUltimoID();
            altaProfesor(iduser);
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtDNI.Text = "";
        }
        private void AltaUser()
        {
            int dni = Convert.ToInt32(txtDNI.Text);
            dao obDao = new dao();
            connection = obDao.conexion();
            string mysql = "INSERT INTO users(surname, name, dni, active, file, role)VALUES(@surname, @name, @dni, 1, @file, 2)";
            //string mysql2 = "SELECT LAST_INSERT_ID()";
            try
            {
                MySqlCommand command = new MySqlCommand(mysql, connection);
                command.Parameters.AddWithValue("@surname", txtApellido.Text);
                command.Parameters.AddWithValue("@name", txtNombre.Text);
                command.Parameters.AddWithValue("@dni", dni);
                command.Parameters.AddWithValue("@file", dni);
                command.ExecuteNonQuery();
                connection.Close();
                obDao.cerrar();
                Label4.Visible = true;
                Label4.Text = "El profesor se dio de alta correctamente.";
            }
            catch (Exception ex)
            {
                Label4.Visible = true;
                Label4.Text = "Error: " + ex;
                connection.Close();
                obDao.cerrar();
            }
            finally
            {
                connection.Close();
                obDao.cerrar();
            }
        }
        private void altaProfesor(int idusuario)
        {
            dao obDao = new dao();
            connection = obDao.conexion();
            string mysql = "INSERT INTO teacher(id_role, id_user)VALUES(2, @id_user)";
            try
            {
                MySqlCommand command = new MySqlCommand(mysql, connection);
                command.Parameters.AddWithValue("@id_user", idusuario);
                command.ExecuteNonQuery();
                connection.Close();
                obDao.cerrar();
                Label4.Visible = true;
                Label4.Text = "El profesor se dio de alta correctamente.";
            }
            catch (Exception ex)
            {
                Label4.Visible = true;
                Label4.Text = "Error: " + ex;
                connection.Close();
                obDao.cerrar();
            }
            finally
            {
                connection.Close();
                obDao.cerrar();
            }
        }
        private int traerUltimoID()
        {
            int idUltimo = 0;
            dao obDao = new dao();
            connection = obDao.conexion();
            string mysql = "SELECT id_user FROM users ORDER by id_user DESC LIMIT 1";
            try
            {
                MySqlCommand cmd = new MySqlCommand(mysql, connection);
                MySqlDataReader Leer = cmd.ExecuteReader();

                if (Leer.Read())
                {
                    idUltimo = Convert.ToInt32(Leer["id_user"].ToString());
                    Leer.Close();
                    obDao.cerrar();
                    return idUltimo;
                }
                else
                {
                    Leer.Close();
                    obDao.cerrar();

                    return idUltimo;
                }
            }
            catch (Exception ex)
            {
                Label4.Visible = true;
                Label4.Text = "Error: " + ex;
                connection.Close();
                obDao.cerrar();
                return idUltimo;
            }
            finally
            {
                connection.Close();
                obDao.cerrar();
            }
        }
    }
}