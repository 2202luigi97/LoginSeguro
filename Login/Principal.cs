using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        #region Metodos y Funciones
        public Principal()
        {
            InitializeComponent();

        }
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
                int IdUsuarioSesión = (int)General.ValidarEnteros(IdUsuario);
                int IdRolSesión = (int)General.ValidarEnteros(IdRol);
                if (!(IdUsuarioSesión > 0))
                {
                    AbandonarSesión();
                    return false;
                }
                if (!(IdRolSesión > 0))
                {
                    AbandonarSesión();
                    return false;
                }

                Usuarios user = BL_Usuarios.Registro(IdUsuarioSesión);
                if (user == null)
                {
                    AbandonarSesión();
                    return false;
                }

                if (user.IdRol != IdRolSesión)
                {
                    AbandonarSesión();
                    return false;
                }

                List<RolFormulario> FormularioUser = BL_RolFormulario.List(IdRolSesión);
                if (!(FormularioUser.Count > 0))
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
        private void EstiloFormulario()
        {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                                  (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
        }
        #endregion
        #region Eventos
        private void Principal_Load(object sender, EventArgs e)
        {
            EstiloFormulario();
            ValidarSesión();
            lbnombre.Text = NombreRol;

        }
        private void btnlogout_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Esta seguro de cerrar la sesión?", "cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                AbandonarSesión();
            }

        }
        private void btnVentas_Click(object sender, EventArgs e)
        {
            Ventas ven = new Ventas();
            ven.IdUsuario = IdUsuario;
            ven.IdRol = IdRol;
            ven.ShowDialog();
           
        }
        private void btnInventario_Click(object sender, EventArgs e)
        {
            Inventario inv = new Inventario();
            inv.IdUsuario = IdUsuario;
            inv.IdRol = IdRol;
            inv.ShowDialog();
        }
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminUsuarios admin = new AdminUsuarios();
            admin.IdUsuario = IdUsuario;
            admin.ShowDialog();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMnmize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnReporte_Click(object sender, EventArgs e)
        {
            Reporte re = new Reporte();
            re.IdUsuario = IdUsuario;
            re.IdRol = IdRol;
            re.ShowDialog();
        }
        #endregion
    }
}
