using BL;
using EL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilidades;
using static EL.Enums;

namespace Login
{
    public partial class Principal : Form
    {
        public int IdUsuario {  get; set; }
        public int IdRol {  get; set; }
        public string Nombre { get; set; }
        public string NombreRol {  get; set; }

        private bool isDragging = false;
        private Point lastCursorPos;
        private Point lastFormPos;
        public Principal()
        {
            InitializeComponent();
            
        }
        #region Metodos y Funciones
        private void VerificarPermisosFormularios(List<RolFormulario> rolForms)
        {
            btnAdmin.Enabled = false;
            btnInventario.Enabled = false;
            btnVentas.Enabled = false;
            btnReporte.Enabled = false;
            foreach (var rolFormulario in rolForms)
            {
                if (rolFormulario.IdFormulario == (int)eFormulario.AdministracionUsuario)
                {
                    btnAdmin.Enabled = true;
                }
                if (rolFormulario.IdFormulario == (int)eFormulario.Ventas)
                {
                    btnVentas.Enabled = true;
                }
                if (rolFormulario.IdFormulario == (int)eFormulario.Inventario)
                {
                    btnInventario.Enabled = true;
                }
                if (rolFormulario.IdFormulario == (int)eFormulario.Reportes)
                {
                    btnReporte.Enabled = true;
                }
            }
        }
        private void LimpiarVariablesSesión()
        {
            IdUsuario = 0;
            Nombre = string.Empty;
            IdRol = 0;
            NombreRol = string.Empty;
        }
        private void AbandonarSesión()
        {
            LimpiarVariablesSesión();
            this.Dispose();
            Login lo = new Login();
            lo.Show();
        }
        private bool ValidarSesión()
        {


            try
            {
                if (IdUsuario <= 0 || IdRol <= 0)
                {
                    AbandonarSesión();
                    return false;
                }

                Usuarios user = BL_Usuarios.Registro(IdUsuario);
                if (user == null)
                {;
                    AbandonarSesión();
                    return false;
                }

                if (user.IdRol != IdRol)
                {
                    AbandonarSesión();
                    return false;
                }

                List<RolFormulario> FormularioUser = BL_RolFormulario.List(IdRol);
                if (FormularioUser == null || FormularioUser.Count == 0)
                {
                    AbandonarSesión();
                    MessageBox.Show("Estimado usuario, No cuenta con permisos necesarios para ingresar a ningun formulario", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                VerificarPermisosFormularios(FormularioUser);
                return true;
            }
            catch (Exception ex)
            {
                AbandonarSesión();
                return false;
            }
        }
        #endregion
        #region Eventos
        private void Principal_Load(object sender, EventArgs e)
        {
            ValidarSesión();
            lbNombreyRol.Text = "Bienvenid@ " + Nombre + " " + NombreRol;

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        private void btnlogout_Click(object sender, EventArgs e)
        {
            AbandonarSesión();
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

        private void btnVentas_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tbpageVentas;
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tbpageInventario;
        }
        #endregion


    }
}
