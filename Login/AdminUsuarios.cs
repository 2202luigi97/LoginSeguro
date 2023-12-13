﻿using BL;
using EL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilidades;

namespace Login
{
    public partial class AdminUsuarios : Form
    {
        public int IdUsuario { get; set; }
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        int IdUsuarioSeleccionado = 0;
        public AdminUsuarios()
        {
            InitializeComponent();
        }

        #region Métodos
        private void CargarGrid()
        {
            List<vUsuarios> ListaUsuarios;
            if (!(string.IsNullOrEmpty(txtBuscar.Text) || string.IsNullOrWhiteSpace(txtBuscar.Text)) && txtBuscar.Text.Length > 2)
            {
                ListaUsuarios = BL_Usuarios.vUsuarios().Where(a => a.Nombre.ToLower().Contains(txtBuscar.Text.ToLower()) || a.Correo.ToLower().Contains(txtBuscar.Text.ToLower()) || a.UserName.ToLower().Contains(txtBuscar.Text.ToLower())).ToList();

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
            foreach (DataGridViewRow row in dgvUsuario.Rows)
            {
                row.Height = 30;
            }
        }
        private void CargarRoles()
        {
            try
            {
                List<Roles> roles = BL_Roles.List();
                roles.Insert(0, new Roles { IdRol = 0, Rol = "--Seleccione--" });

                cmbRoles.DisplayMember = "Rol";
                cmbRoles.ValueMember = "IdRol";
                cmbRoles.DataSource = roles;
                cmbRoles.SelectedIndex = 0;

            }
            catch { }
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
            if (cmbRoles.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione el rol del usuario", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;

        }
        private bool ValidarActualizar(int IdRegistro)
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
            if (BL_Usuarios.ExisteUserNameUpdate(txtUsuario.Text, IdRegistro))
            {
                MessageBox.Show("El Username ya existe en el sistema", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!(string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrWhiteSpace(txtPassword.Text)))
            {
                if (!General.validarComplejidadPassword(txtPassword.Text))
                {
                    MessageBox.Show("La contraseña no cumple con los requisitos", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (!General.ValidarSinEspacios(txtPassword.Text))
            {
                MessageBox.Show("La contraseña no debe contener espacios", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (cmbRoles.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione el rol del usuario", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
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
                IdUsuarioSeleccionado = vusuario.IdUsuario;
                txtBuscar.Text = vusuario.IdUsuario.ToString();
                txtNombre.Text = vusuario.Nombre;
                txtCorreo.Text = vusuario.Correo;
                txtUsuario.Text = vusuario.UserName;
                txtPassword.Text = string.Empty;


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar controles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarControles()
        {
            txtNombre.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtUsuario.Text= string.Empty;
            cmbRoles.SelectedIndex = 0;
            IdUsuarioSeleccionado = 0;
            btnBloquear.Text = "Bloquear";
        }
        private void Guardar()
        {
            try
            {
                int IdRegistro = (int)General.ValidarEnteros(IdUsuarioSeleccionado);
                Usuarios user = new Usuarios();
                if (IdRegistro > 0)
                {
                    //Actualizará
                    if (ValidarActualizar(IdRegistro))
                    {
                        bool UpdatePassword = false;
                        user.IdUsuario = IdRegistro;
                        user.Nombre = txtNombre.Text;
                        user.Correo = txtCorreo.Text;
                        user.UserName = txtUsuario.Text;
                        if (!(string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrWhiteSpace(txtPassword.Text)))
                        {
                            user.Password = BL_Usuarios.Encrypt(txtPassword.Text);
                            UpdatePassword = true;
                        }
                        user.IdRol = (int)General.ValidarEnteros(cmbRoles.SelectedValue);
                        user.UsuarioActualiza = IdUsuario;
                        if (BL_Usuarios.Update(user, UpdatePassword))
                        {
                            LimpiarControles();
                            //CargarGrid();
                            MessageBox.Show("Registro actualizado correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        MessageBox.Show("Registro no actualizado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    return;

                }
                //agregará
                if (ValidarGuardar())
                {
                    user.Nombre = txtNombre.Text;
                    user.Correo = txtCorreo.Text;
                    user.UserName = txtUsuario.Text;
                    user.Password = BL_Usuarios.Encrypt(txtPassword.Text);
                    user.IdRol = (int)General.ValidarEnteros(cmbRoles.SelectedValue);
                    user.UsuarioRegistra = IdUsuario;
                    if (BL_Usuarios.Insert(user).IdUsuario > 0)
                    {
                        LimpiarControles();
                        //CargarGrid();
                        MessageBox.Show("Registro guardado correctamente", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    MessageBox.Show("Registro no actualizado", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show("No se realizó ninguna operación", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch
            {
                MessageBox.Show("Error en el sistema", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Eventos
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AdminUsuarios_Load(object sender, EventArgs e)
        {
            CargarGrid();
            CargarRoles();
        }
        private void AdminUsuarios_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }
        private void AdminUsuarios_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }
        private void AdminUsuarios_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        #endregion

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void pbMostrarConstraseña_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;

            if (txtPassword.UseSystemPasswordChar)
            {
                pbMostrarConstraseña.Image = Properties.Resources.PhEyeThin;
            }
            else
            {
                pbMostrarConstraseña.Image = Properties.Resources.PhEyeSlashThin;
            }
        }
    }
}