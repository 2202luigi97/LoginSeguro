using BL;
using EL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static EL.Enums;
using Utilidades;

namespace Login
{
    public partial class Reporte : Form
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        #region Métodos
        public Reporte()
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
                btnVenta.Enabled = false;
                btnInventario.Enabled = false;

                if (PermisosUser.Count > 0)
                {
                    foreach (var PermisoUser in PermisosUser)
                    {
                        if (PermisoUser.IdPermiso == (int)ePermisos.ReporteVenta)
                        {
                            btnVenta.Enabled = true;
                        }
                        if (PermisoUser.IdPermiso == (int)ePermisos.ReporteInventario)
                        {
                            btnInventario.Enabled = true;
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
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Reporte_Load(object sender, EventArgs e)
        {
            ValidarSesion();
        }
        #endregion
    }
}
