using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EL
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        public int IdUsuario { get; set; }

        [MaxLength(200)]
        [Required]
        public string Nombre { get; set; }

        [MaxLength(200)]
        [Required]
        public string Correo { get; set; }

        [MaxLength(50)]
        [Required]
        public string UserName { get; set; }

        [Required]
        public byte[] Password { get; set; }

        [Required]
        public short Contador { get; set; }

        [Required]
        public bool Bloqueo { get; set; } 

        [Required]
        public int IdRol { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Required]
        public int UsuarioRegistra { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }

        public int? UsuarioActualiza { get; set; }

        public DateTime? FechaActualizacion { get; set; }
    }

    public class vUsuarios
    {
        [Key]
        public int IdUsuario { get;set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string UserName { get; set; }
        public bool Bloqueo { get; set; }
        public string CuentaBloqueada { get; set; }
        public short Contador { get; set; }
        public int IdRol { get; set; }
        public string Rol { get; set; }

    }
}
