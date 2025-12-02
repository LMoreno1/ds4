using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Parcial3.Models
{
    [Table("LM_Clientes")]
    public class Clientes
    {
        [Key]
        public int ClienteID { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Apellido { get; set; }

        [StringLength(50)]
        public string Identificacion { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [StringLength(150)]
        public string Email { get; set; }

        [Column(TypeName = "text")]
        public string Direccion { get; set; }

        [StringLength(50)]
        public string TipoCliente { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}