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
        public int IdUsuario {  get; set; }
        public int IdRol {  get; set; }
        public string Nombre { get; set; }
        public string NombreRol {  get; set; }
        public int IdUsuarioSeleccionado = 0;

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
        private void CargarGrid()
        {
            List<vUsuarios> ListaUsuarios;
            if (!(string.IsNullOrEmpty(txtBuscar.Text)||string.IsNullOrWhiteSpace(txtBuscar.Text))&&txtBuscar.Text.Length>2)
            {
                ListaUsuarios = BL_Usuarios.vUsuarios().Where(a=>a.Nombre.ToLower().Contains(txtBuscar.Text.ToLower()) || a.Correo.ToLower().Contains(txtBuscar.Text.ToLower()) || a.UserName.ToLower().Contains(txtBuscar.Text.ToLower())).ToList();
                
            }
            else
            {
                ListaUsuarios = BL_Usuarios.vUsuarios();
            }
            
            dgvUsuario.AutoGenerateColumns = true;
            dgvUsuario.DataSource = ListaUsuarios;
            dgvUsuario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuario.Columns["Nombre"].HeaderText = "Nombre";
            dgvUsuario.Columns["Correo"].HeaderText = "Correo";
            dgvUsuario.Columns["UserName"].HeaderText = "Usuario";
            dgvUsuario.Columns["CuentaBloqueada"].HeaderText = "Bloqueado";
            dgvUsuario.Columns["Contador"].HeaderText = "Contador";
            dgvUsuario.Columns["Rol"].HeaderText = "Rol";
            dgvUsuario.Columns["Nombre"].Width = 185;
            dgvUsuario.Columns["Correo"].Width = 208;
            dgvUsuario.Columns["UserName"].Width = 100;
            dgvUsuario.Columns["CuentaBloqueada"].Width = 100;
            dgvUsuario.Columns["Contador"].Width = 75;
            dgvUsuario.Columns["Rol"].Width = 130;
            dgvUsuario.Columns["IdUsuario"].Visible = false;
            dgvUsuario.Columns["Bloqueo"].Visible = false;
            dgvUsuario.Columns["IdRol"].Visible = false;
            dgvUsuario.RowTemplate.Height = 30;
            dgvUsuario.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            foreach (DataGridViewRow row in dgvUsuario.Rows )
            {
                row.Height = 30;
            }
        }
        private void CargarRoles()
        {
            try
            {
                //var itemSeleccionado = cmbRoles.SelectedItem;
                //cmbRoles.Items.Clear();
                //cmbRoles.DisplayMember = "Rol";
                //cmbRoles.ValueMember = "IdRol";
                //cmbRoles.Items.Add(new Roles { IdRol = 0, Rol = "--Seleccione--" });
                //cmbRoles.Items.AddRange(BL_Roles.List().ToArray());

                List<Roles> roles = BL_Roles.List();

                // Agrega manualmente el ítem "--Seleccione--" al principio de la lista
                roles.Insert(0, new Roles { IdRol = 0, Rol = "--Seleccione--" });

                cmbRoles.DisplayMember = "Rol";
                cmbRoles.ValueMember = "IdRol";
                cmbRoles.DataSource = roles;
                cmbRoles.SelectedIndex = 0;

            }
            catch { }
        }
        private void CargarControles(int IdRegistro)
        {
            try
            {
                vUsuarios vusuario = BL_Usuarios.vUsuario(IdRegistro);

                if (vusuario == null)
                {
                    MessageBox.Show("No se encontró datos para el registro seleccionado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                cmbRoles.SelectedValue = vusuario.IdRol;

                txtBuscar.Text = vusuario.IdUsuario.ToString();
                txtNombre.Text = vusuario.Nombre;
                txtCorreo.Text = vusuario.Correo;
                txtUsuario.Text = vusuario.UserName;

                //if (cmbRoles.Items.Cast<Roles>().Any(x => x.IdRol == vusuario.IdRol))
                //{
                //    Console.WriteLine("IdRol encontrado en la lista de roles");

                //    txtBuscar.Text = vusuario.IdUsuario.ToString();
                //    txtNombre.Text = vusuario.Nombre;
                //    txtCorreo.Text = vusuario.Correo;
                //    txtUsuario.Text = vusuario.UserName;
                //    cmbRoles.SelectedValue = vusuario.IdRol;
                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar controles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Eventos
        private void Principal_Load(object sender, EventArgs e)
        {
            ValidarSesión();
            lbnombre.Text = "Bienvenid@ " + Nombre;
            lbrol.Text = NombreRol;

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
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tbpageAdmin;
            CargarGrid();
            CargarRoles();
        }
        private void dgvUsuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int IdRegistro = (int)General.ValidarEnteros(dgvUsuario.SelectedRows[0].Cells["IdUsuario"].Value);
                if (!(IdRegistro > 0))
                {
                    MessageBox.Show("El ID del registro seleccionado fue cero", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                CargarControles(IdRegistro);
            }
            catch 
            {
                MessageBox.Show("Error al seleccionar registro", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion


    }
}
