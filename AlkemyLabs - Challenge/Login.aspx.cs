using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.Web.Security;

namespace AlkemyLabs___Challenge
{
    public partial class Login : System.Web.UI.Page
    {
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataReader dr;
        public MySqlConnection miConexion;
        protected void Page_Load(object sender, EventArgs e)
        {
            ConnectionStringSettings ConnectionSettings = ConfigurationManager.ConnectionStrings["con"];
            string conexionstring = ConnectionSettings.ConnectionString;
            miConexion = new MySqlConnection(conexionstring);

            string clickHandler = string.Format("document.body.style.cursor = 'wait'; this.value='INGRESANDO...'; this.disabled = true; {0};",
            this.ClientScript.GetPostBackEventReference(btnIniciarSesion, string.Empty));
            btnIniciarSesion.Attributes.Add("onclick", clickHandler);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            miConexion.Open();
            validarUsuario();
            miConexion.Close();
        }
        public void validarUsuario()
        {
            if (txtUsuario.Text.Trim() == "") { Response.Write("<script>window.alert('Error: Debe ingresar un Usuario');</script>"); return; }
            if (txtContraseña.Text.Trim() == "") { Response.Write("<script>window.alert('Error: Debe ingresar una contraseña');</script>"); return; }
            int dni = Convert.ToInt32(txtUsuario.Text);
            string MySQL = "SELECT dni, file FROM users Where dni = '" + dni + "' AND file = '" + txtContraseña.Text + "'";

            try
            {
                cmd = new MySqlCommand(MySQL, miConexion);
                cmd.Parameters.AddWithValue("username", txtUsuario.Text);
                cmd.Parameters.AddWithValue("password", txtContraseña.Text);

                MySqlDataReader Leer = cmd.ExecuteReader();

                if (Leer.Read())
                {
                    Leer.Close();
                    miConexion.Close();
                    FormsAuthentication.RedirectFromLoginPage(txtUsuario.Text, true);
                    Response.Redirect("MenuInicio.aspx");
                }
                else
                {
                    Label3.Visible = true;
                    Label3.Text = "Error en usuario o contraseña.";
                    Leer.Close();
                    miConexion.Close();
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "Error " + ex;
                miConexion.Close();
            }
        }
    }
}