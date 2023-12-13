using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Utilidades;
using static EL.Enums;

namespace Login
{
    public partial class Principal : Form
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public string Nombre { get; set; }
        public string NombreRol { get; set; }
        public int IdUsuarioSeleccionado = 0;
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
                {
                    ;
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
            EstiloFormulario();
            ValidarSesión();
            lbnombre.Text = "Bienvenid@ " + Nombre + "   " + NombreRol;

        }
        private void EstiloFormulario()
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                                  (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
        }
        private void btnlogout_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Esta seguro de cerrar la sesión?", "cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                MessageBox.Show("Sesión cerrada");
                AbandonarSesión();
            }

        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            //tabControl1.SelectedTab = tbpageVentas;
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            //tabControl1.SelectedTab = tbpageInventario;
        }
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminUsuarios admin = new AdminUsuarios();
            admin.IdUsuario = IdUsuario;
            admin.ShowDialog();
        }
        private void dgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }


        #endregion

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }

        private void pbMostrarConstraseña_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMnmize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
