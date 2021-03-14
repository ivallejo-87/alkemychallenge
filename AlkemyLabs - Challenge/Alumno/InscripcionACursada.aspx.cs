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

namespace AlkemyLabs___Challenge.Alumno
{
    public partial class InscripcionACursada : System.Web.UI.Page
    {
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataReader dr;
        dao obDao = new dao();
        public MySqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            traerMateria(idUsuario.traerID(Thread.CurrentPrincipal.Identity.Name));
        }
        public void traerMateria(string matricula)
        {

            dao obDao = new dao();
            connection = obDao.conexion();
            string MySQL = @"SELECT s.name AS Subject, s.id_subjects FROM student stu, subjects s WHERE stu.id_student = " + matricula +" AND NOT EXISTS " +
                            "(SELECT * FROM student_subjects ss " +
                            "WHERE stu.id_student = ss.id_student AND s.id_subjects = ss.id_subject ORDER BY name)";
            try
            {
                MySqlCommand comando = new MySqlCommand(MySQL, connection);
                MySqlDataAdapter dataAdaptador = new MySqlDataAdapter(comando);
                DataTable dt = new DataTable();
                dataAdaptador.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                obDao.cerrar();
                connection.Close();
            }
            catch (Exception ex)
            {
                Label1.Visible = true;
                Label1.Text = "Error: " + ex;
                obDao.cerrar();
                connection.Close();
            }
            finally
            {
                connection.Close();
                obDao.cerrar();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int traerIDMateria = Convert.ToInt32(GridView1.SelectedDataKey.Value.ToString());
            GridView2.Visible = true;
            btnInscribirse.Visible = true;
            infoMateria(traerIDMateria);
        }

        private void infoMateria(int idMateria)
        {
            dao obDao = new dao();
            connection = obDao.conexion();
            string MySQL = @"SELECT s.name, s.horary, s.maximum_quotas, CONCAT(us.name,' ', us.surname) AS Teacher FROM subjects s INNER JOIN teacher t ON " +
                "s.id_teacher = t.id_teacher INNER JOIN users us ON " +
                "t.id_user = us.id_user WHERE s.id_subjects ="+ idMateria;
            try
            {
                MySqlCommand comando = new MySqlCommand(MySQL, connection);
                MySqlDataAdapter dataAdaptador = new MySqlDataAdapter(comando);
                DataTable dt = new DataTable();
                dataAdaptador.Fill(dt);
                GridView2.DataSource = dt;
                GridView2.DataBind();
                obDao.cerrar();
                connection.Close();
            }
            catch (Exception ex)
            {
                Label1.Visible = true;
                Label1.Text = "Error: " + ex;
                obDao.cerrar();
                connection.Close();
            }
            finally
            {
                connection.Close();
                obDao.cerrar();
            }
        }

        protected void btnInscribirse_Click(object sender, EventArgs e)
        {
            int traerIDMateria = Convert.ToInt32(GridView1.SelectedDataKey.Value.ToString());
            inscribirse(idUsuario.traerID(Thread.CurrentPrincipal.Identity.Name), traerIDMateria);
            actualizarCupos(traerIDMateria);
        }
        private void inscribirse(string idusuario, int idMateria)
        {
            dao obDao = new dao();
            connection = obDao.conexion();
            string mysql = "INSERT INTO student_subjects(id_student, id_subject)VALUES(@id_student, @id_subject)";
            try
            {
                MySqlCommand command = new MySqlCommand(mysql, connection);
                command.Parameters.AddWithValue("@id_student", idusuario);
                command.Parameters.AddWithValue("@id_subject", idMateria);
                command.ExecuteNonQuery();
                connection.Close();
                obDao.cerrar();
                Label1.Visible = true;
                Label1.Text = "Su solicitud ha sido enviado correctamente.";
                traerMateria(idUsuario.traerID(Thread.CurrentPrincipal.Identity.Name));
            }
            catch (Exception ex)
            {
                Label1.Visible = true;
                Label1.Text = "Error: " + ex;
                connection.Close();
                obDao.cerrar();
            }
            finally
            {
                connection.Close();
                obDao.cerrar();
            }
        }
        private void actualizarCupos(int idMateria)
        {
            dao obDao = new dao();
            connection = obDao.conexion();

            string insert = @"UPDATE subjects SET maximum_quotas = maximum_quotas - 1 WHERE id_subjects = "+ idMateria;
            try
            {

                MySqlCommand sqla = new MySqlCommand(insert, connection);
                sqla.ExecuteNonQuery();
                //GridView1.DataBind();
                obDao.cerrar();
                connection.Close();
            }
            catch (Exception error)
            {
                obDao.cerrar();
                connection.Close();
                Label1.Visible = true;
                Label1.Text = "Error: "+error;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}