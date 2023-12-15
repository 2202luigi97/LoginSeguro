using BL;
using EL;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Login
{
    public partial class Login : Form
    {

        private bool isDragging = false;
        private Point lastCursorPos;
        private Point lastFormPos;

        #region Metodos y Funciones
        public Login()
        {
            InitializeComponent();
        }
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
                int intentosFallidos = BL_Usuarios.CantidadIntentosFallidos(txtUsuario.Text);
                MessageBox.Show($"Credenciales Incorrectas. lleva {intentosFallidos + 1} intentos. si llega a los 3 intentos su cuenta será bloqueada", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Usuarios user = BL_Usuarios.ExisteUsuario_x_UserName(txtUsuario.Text);
                if (BL_Usuarios.CantidadIntentosFallidos(txtUsuario.Text) >= 2)
                {
                    BL_Usuarios.BloquearCuentaUsuario(user.IdUsuario, true, user.IdUsuario);
                    MessageBox.Show("Su cuenta ha sido bloqueada por multiples intentos de inicio de sesión", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (usuarioautenticado.Contador > 0)
                {
                    BL_Usuarios.RestablecerIntentosFallido(usuarioautenticado.IdUsuario, usuarioautenticado.IdUsuario);
                }
                if (!(usuarioautenticado.IdRol > 0))
                {
                    MessageBox.Show("Estimado usuario usted no cuenta con un rol en el sistema, comuniquese con el administrador", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                this.Hide();
                Principal re = new Principal();
                re.IdUsuario = usuarioautenticado.IdUsuario;
                re.Nombre = usuarioautenticado.Nombre;
                re.IdRol = usuarioautenticado.IdRol;
                Roles rol = BL_Roles.ObtenerRolPorId(usuarioautenticado.IdRol);
                re.NombreRol = rol != null ? rol.Rol : "Rol no encontrado";
                re.Show();
            }
            return true;
        }
        #endregion
        #region Eventos


        private void btnlogin_Click(object sender, EventArgs e)
        {
            validarAccesos();
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
        private void pbMostrarConstraseña_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;

            if (txtPassword.UseSystemPasswordChar)
            {
                pbMostrarConstraseña.Image = Properties.Resources.MdiEyeOutline;
            }
            else
            {
                pbMostrarConstraseña.Image = Properties.Resources.MdiEyeOffOutline;
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMnmize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Nombre de usuario")
            {
                txtUsuario.Text = string.Empty;
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == string.Empty)
            {
                txtUsuario.Text = "Nombre de usuario";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Contraseña")
            {
                txtPassword.Text = string.Empty;
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == string.Empty)
            {
                txtPassword.Text = "Contraseña";
                txtPassword.ForeColor = Color.LightGray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }
        #endregion
    }
}
