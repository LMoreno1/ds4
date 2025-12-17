using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Models.Entities
{
    public class Inscripcion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Estudiante es requerido")]
        [Display(Name = "Estudiante")]
        public int EstudianteId { get; set; }

        [Required(ErrorMessage = "Actividad es requerida")]
        [Display(Name = "Actividad")]
        public int ActividadId { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; } = "Activa";

        public virtual Estudiante Estudiante { get; set; }
        public virtual Actividad Actividad { get; set; }
    }
}