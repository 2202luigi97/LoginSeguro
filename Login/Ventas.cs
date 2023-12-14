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
    public partial class Ventas : Form
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }
        public Ventas()
        {
            InitializeComponent();
        }
        #region Métodos
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
                        if (PermisoUser.IdPermiso==(int)ePermisos.CrearFactura)
                        {
                            btnNueva.Enabled = true;
                        }
                        if (PermisoUser.IdPermiso == (int)ePermisos.EditarFactura)
                        {
                            btnEditar.Enabled = true;
                        }
                        if (PermisoUser.IdPermiso == (int)ePermisos.AnularFactura)
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
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Ventas_Load(object sender, EventArgs e)
        {
            ValidarSesion();
        }
        #endregion


    }
}
