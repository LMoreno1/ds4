using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Parcial3.Models
{
    [Table("LM_Seguimiento")]
    public class Seguimiento
    {
        [Key]
        public int SeguimientoID { get; set; }

        [ForeignKey("Caso")]
        public int? CasoID { get; set; }
        public virtual Casos Caso { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string Descripcion { get; set; }

        [ForeignKey("Usuario")]
        public int? UsuarioID { get; set; }
        public virtual Usuarios Usuario { get; set; }

        public DateTime FechaCambio { get; set; }

        [StringLength(50)]
        public string TipoCambio { get; set; }
    }
}