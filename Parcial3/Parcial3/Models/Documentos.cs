using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Parcial3.Models
{
    [Table("LM_Documentos")]
    public class Documentos
    {
        [Key]
        public int DocumentoID { get; set; }

        [Required]
        [StringLength(255)]
        public string NombreArchivo { get; set; }

        [Required]
        [StringLength(500)]
        public string RutaArchivo { get; set; }

        [StringLength(100)]
        public string TipoDocumento { get; set; }

        [Column(TypeName = "text")]
        public string Descripcion { get; set; }

        [ForeignKey("Caso")]
        public int? CasoID { get; set; }
        public virtual Casos Caso { get; set; }

        [ForeignKey("Usuario")]
        public int? UsuarioID { get; set; }
        public virtual Usuarios Usuario { get; set; }

        public DateTime FechaSubida { get; set; }

        public long? TamanoArchivo { get; set; }
    }
}