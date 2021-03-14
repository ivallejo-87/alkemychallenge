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
    public partial class ConsultarMateriasInscriptas : System.Web.UI.Page
    {
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataReader dr;
        dao obDao = new dao();
        public MySqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            traerMateriasInscriptas(idUsuario.traerID(Thread.CurrentPrincipal.Identity.Name));
        }
        private void traerMateriasInscriptas(string idUsuario)
        {
            dao obDao = new dao();
            connection = obDao.conexion();
            string MySQL = @"SELECT s.name AS Subject, s.horary, Concat(us.name,' ', us.surname) AS Teacher FROM student_subjects ss INNER JOIN subjects s ON 
                            ss.id_subject = s.id_subjects INNER JOIN teacher t ON
                            s.id_teacher = t.id_teacher INNER JOIN users us ON
                            t.id_user = us.id_user
                            WHERE ss.id_student ="+ idUsuario;
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
    }
}