using BL;
using EL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilidades;

namespace Login
{
    public partial class Login : Form
    {

        private bool isDragging = false;
        private Point lastCursorPos;
        private Point lastFormPos;

        public Login()
        {
            InitializeComponent();
        }
        #region Metodos y Funciones
        private bool validarAccesos()
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Ingrese el user name", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Ingrese la contraseña del usuario", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!BL_Usuarios.ExisteUserName(txtUsuario.Text))
            {
                MessageBox.Show("Credenciales incorrectas", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (BL_Usuarios.VerificarCuentaBloqueada(txtUsuario.Text))
            {
                MessageBox.Show("Su cuenta ha sido bloqueada por multiples intentos de inicio de sesión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            byte[] password = BL_Usuarios.Encrypt(txtPassword.Text);
            if (!BL_Usuarios.ValidarCredenciales(txtUsuario.Text, password))
            {
                MessageBox.Show("Credenciales Incorrectas, si supera 3 intentos fallidos de inicio de sesion su cuenta será bloqueada", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Usuarios user = BL_Usuarios.ExisteUsuario_x_UserName(txtUsuario.Text);
                if (BL_Usuarios.CantidadIntentosFallidos(txtUsuario.Text) >= 2)
                {
                    BL_Usuarios.BloquearCuentaUsuario(user.IdUsuario, true, user.IdUsuario);
                    Mensaje(Justify("Su cuenta ha sido bloqueada por multiples intentos fallidos de iniciar sesion, porfavor comuniquese con un admin. del sistema"), eMessage.Error, "", true, true, false, "", false);
                }
                if (user != null)
                {
                    BL_Usuarios.SumarIntentosFallido(user.IdUsuario);
                }
                return false;
            }
            Usuarios usuarioautenticado = BL_Usuarios.ExisteUsuario_x_UserName(txtUsuario.Text);
            if (usuarioautenticado != null)
            {
                if (usuarioautenticado.IntentosFallidos > 0)
                {
                    BL_Usuarios.RestablecerIntentosFallido(usuarioautenticado.IdUsuario, usuarioautenticado.IdUsuario);
                }
                if (!(usuarioautenticado.IdRol > 0))
                {
                    Mensaje("Estimado usuario usted no cuenta con un rol en el sistema, comuniquese con el administrador", eMessage.Alerta);
                    return false;
                }
                Session["IdUsuarioGl"] = usuarioautenticado.IdUsuario;
                Session["IdRolGl"] = usuarioautenticado.IdRol;
                Mensaje("Acceso Correcto", eMessage.Exito);
                Response.Redirect("~/Principal.aspx");
            }
            return true;
        }
        #endregion
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            

            
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Registro re = new Registro();
            re.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                lastCursorPos = Cursor.Position;
                lastFormPos = Location;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                int deltaX = Cursor.Position.X - lastCursorPos.X;
                int deltaY = Cursor.Position.Y - lastCursorPos.Y;

                Location = new Point(lastFormPos.X + deltaX, lastFormPos.Y + deltaY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
    }
}
