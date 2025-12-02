using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Parcial3.Models
{
    [Table("LM_Calendario")]
    public class Calendario
    {
        [Key]
        public int EventoID { get; set; }

        [Required]
        [StringLength(200)]
        public string TituloEvento { get; set; }

        [Column(TypeName = "text")]
        public string Descripcion { get; set; }

        public DateTime FechaHora { get; set; }

        [StringLength(50)]
        public string TipoEvento { get; set; }

        [ForeignKey("Caso")]
        public int? CasoID { get; set; }
        public virtual Casos Caso { get; set; }

        [ForeignKey("Usuario")]
        public int? UsuarioID { get; set; }
        public virtual Usuarios Usuario { get; set; }

        public bool Notificado { get; set; }

        public DateTime? FechaRecordatorio { get; set; }
    }
}