using BL;
using EL;
using System;
using System.Drawing;
using System.Windows.Forms;
using Utilidades;

namespace Login
{
    public partial class Registro : Form
    {
        private bool isDragging = false;
        private Point lastCursorPos;
        private Point lastFormPos;

        #region Metodos y Funciones
        public Registro()
        {
            InitializeComponent();
        }
        private void ResetControles()
        {
            txtNombre.Text=string.Empty;
            txtCorreo.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }
        private bool ValidarGuardar()
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingrese el nombre completo", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!General.ValidarSoloLetras(txtNombre.Text)) 
            {
                MessageBox.Show("Ingrese un nombre válido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtCorreo.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Ingrese un correo", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!General.CorreoEsValido(txtCorreo.Text))
            {
                MessageBox.Show("Ingrese un correo válido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("Ingrese el user name", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!General.ValidarSinEspacios(txtUsuario.Text))
            {
                MessageBox.Show("El Username no debe contener espacios", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (BL_Usuarios.ExisteUserName(txtUsuario.Text)) 
            {
                MessageBox.Show("El Username ya existe en el sistema", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Ingrese la contraseña del usuario", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!General.validarComplejidadPassword(txtPassword.Text)) 
            {
                MessageBox.Show("La contraseña no cumple con los requisitos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!General.ValidarSinEspacios(txtPassword.Text))
            {
                MessageBox.Show("La contraseña no debe contener espacios", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;

        }
        private void GuardarUsuarioInvitado()
        {
            try
            {
                Usuarios user = new Usuarios();
                if (ValidarGuardar())
                {
                    user.Nombre = txtNombre.Text;
                    user.Correo = txtCorreo.Text;
                    user.UserName = txtUsuario.Text;
                    user.Password = BL_Usuarios.Encrypt(txtPassword.Text);

                    if (BL_Usuarios.RegistrarUsuarioInvitado(user).IdUsuario>0) 
                    {
                        ResetControles();
                        MessageBox.Show($"Usuario {user.UserName} creado con exito, pongase en contacto con el admin para que le asigne un rol", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Login lo = new Login();
                        lo.Show();
                        return;
                    }
                    MessageBox.Show("Usuario no registrado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                
            }
        }
        #endregion
        #region Eventos
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
        private void button1_Click(object sender, EventArgs e)
        {
            Login lo = new Login();
            lo.Show();
            this.Close();
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            GuardarUsuarioInvitado();
        }
        private void txtNombre_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = General.FormatearNombre(textBox.Text);
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMnmize_Click(object sender, EventArgs e)
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
        #endregion
    }
}
