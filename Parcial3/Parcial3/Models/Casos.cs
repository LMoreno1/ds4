using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Parcial3.Models
{
    [Table("LM_Casos")]
    public class Casos
    {
        [Key]
        public int CasoID { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroCaso { get; set; }

        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }

        [Column(TypeName = "text")]
        public string Descripcion { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime? FechaVencimiento { get; set; }

        [StringLength(50)]
        public string Estado { get; set; }

        [StringLength(20)]
        public string Prioridad { get; set; }

        [ForeignKey("Abogado")]
        public int? AbogadoID { get; set; }
        public virtual Usuarios Abogado { get; set; }

        [ForeignKey("Cliente")]
        public int? ClienteID { get; set; }
        public virtual Clientes Cliente { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaModificacion { get; set; }
    }
}