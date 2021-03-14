using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

namespace AlkemyLabs___Challenge
{
    public partial class MenuPrincipal : System.Web.UI.MasterPage
    {
        string user;
        string principalType = Thread.CurrentPrincipal.GetType().Name;
        public string nombre;
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataReader dr;
        dao obDao = new dao();
        public MySqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            string user = Thread.CurrentPrincipal.Identity.Name;
            int rolUsuario = verificarId(user);
            int idRol = verificarRoles(rolUsuario);
            habilitarSegunRol(idRol);
            obDao.cerrar();
        }
        private int verificarId(string dni)
        {
            dao obDao = new dao();
            connection = obDao.conexion();
            string MySQL = @"SELECT id_user FROM users WHERE dni =" + dni;
            try
            {

                MySqlCommand sqla = new MySqlCommand(MySQL, connection);
                MySqlDataReader Leer = sqla.ExecuteReader();

                if (Leer.Read())
                {
                    int iduser = Convert.ToInt32(Leer["id_user"].ToString());
                    Leer.Close();
                    obDao.cerrar();
                    return iduser;
                }
                else
                {
                    Leer.Close();
                    obDao.cerrar();
                    return 0;
                }
            }
            catch (Exception)
            {
                connection.Close();
                return 0;
            }
        }
        private int verificarRoles(int idUsuario)
        {
            dao obDao = new dao();
            connection = obDao.conexion();
            string MySQL = @"SELECT role FROM users WHERE id_user =" + idUsuario;
            try
            {

                MySqlCommand sqla = new MySqlCommand(MySQL, connection);
                MySqlDataReader Leer = sqla.ExecuteReader();

                if (Leer.Read())
                {
                    int Id_Rol = Convert.ToInt32(Leer["role"].ToString());
                    Leer.Close();
                    obDao.cerrar();
                    return Id_Rol;
                }
                else
                {
                    Leer.Close();
                    obDao.cerrar();
                    return 0;
                }
            }
            catch (Exception)
            {
                connection.Close();
                return 0;
            }
        }
        private void habilitarSegunRol(int rolUsuario)
        {
            if (rolUsuario == 1)
            {
                LiInscripcionACursada.Visible = false;
            }
            if (rolUsuario == 2)
            {
                LiInscripcionACursada.Visible = false;
                Li4.Visible = false;
                Li3.Visible = false;
            }
            if (rolUsuario == 3)
            {
                LiABMMaterias.Visible = false;
                Li4.Visible = false;
                Li3.Visible = false;
            }

        }
    }
}