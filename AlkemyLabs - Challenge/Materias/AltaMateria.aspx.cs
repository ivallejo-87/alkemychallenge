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

namespace AlkemyLabs___Challenge.Materias
{
    public partial class AltaMateria : System.Web.UI.Page
    {
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataReader dr;
        dao obDao = new dao();
        public MySqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            traerProfesores();
        }
        private void traerProfesores()
        {
            dao obDao = new dao();
            connection = obDao.conexion();
            string ConsultaSQL = @"SELECT us.id_user, CONCAT(us.surname,' ', us.name) AS Profesor FROM teacher t INNER JOIN users us ON 
                                 t.id_user = us.id_user";
            try
            {
                MySqlCommand cmd = new MySqlCommand(ConsultaSQL, connection);
                MySqlDataAdapter da1 = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                ddlProfesor.DataValueField = "id_user";
                ddlProfesor.DataTextField = "Profesor";
                ddlProfesor.DataSource = dt;
                ddlProfesor.DataBind();
                ddlProfesor.SelectedIndex = 0;
                connection.Close();
            }
            catch (Exception error)
            {
                LabelError.Visible = true;
                LabelError.Text = "Error 01:" + error.Message;
            }
            finally
            {
                connection.Close();
            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            altaMateria();
            txtNombreMateria.Text = "";
            txtHorario.Text = "";
            txtCupos.Text = "";
        }
        private void altaMateria()
        {
            int idprofesor = Convert.ToInt32(ddlProfesor.SelectedValue.ToString());
            dao obDao = new dao();
            connection = obDao.conexion();
            string mysql = "INSERT INTO subjects(name, horary, id_teacher, maximum_quotas)VALUES(@name, @horary, @id_teacher, @maximum_quotas)";
            try
            {
                MySqlCommand command = new MySqlCommand(mysql, connection);
                command.Parameters.AddWithValue("@name", txtNombreMateria.Text);
                command.Parameters.AddWithValue("@horary", txtHorario.Text);
                command.Parameters.AddWithValue("@id_teacher", idprofesor);
                command.Parameters.AddWithValue("@maximum_quotas", txtCupos.Text);
                command.ExecuteNonQuery();
                connection.Close();
                obDao.cerrar();
                LabelError.Visible = true;
                LabelError.Text = "La materia se dio de alta correctamente.";
            }
            catch (Exception ex)
            {
                LabelError.Visible = true;
                LabelError.Text = "Error: " + ex;
                connection.Close();
                obDao.cerrar();
            }
            finally
            {
                connection.Close();
                obDao.cerrar();
            }
        }
    }
}