using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EL.Enums;
using Utilidades;

namespace Login
{
    public partial class Inventario : Form
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        #region Métodos
        public Inventario()
        {
            InitializeComponent();
        }
        private bool ValidarSesion()
        {
            try
            {
                int IdUsuarioSistema = (int)General.ValidarEnteros(IdUsuario);
                int IdRolSistema = (int)General.ValidarEnteros(IdRol);


                List<RolPermiso> PermisosUser = BL_RolPermisos.List(IdRolSistema);
                btnAnular.Enabled = false;
                btnEditar.Enabled = false;
                btnNueva.Enabled = false;

                if (PermisosUser.Count > 0)
                {
                    foreach (var PermisoUser in PermisosUser)
                    {
                        if (PermisoUser.IdPermiso == (int)ePermisos.AgregarInventario)
                        {
                            btnNueva.Enabled = true;
                        }
                        if (PermisoUser.IdPermiso == (int)ePermisos.EditarInventario)
                        {
                            btnEditar.Enabled = true;
                        }
                        if (PermisoUser.IdPermiso == (int)ePermisos.AnularInventario)
                        {
                            btnAnular.Enabled = true;
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
        #region Eventos
        private void Inventario_Load(object sender, EventArgs e)
        {
            ValidarSesion();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
