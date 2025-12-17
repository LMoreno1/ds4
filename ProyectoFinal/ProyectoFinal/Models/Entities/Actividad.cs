using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models.Entities
{
    public class Actividad
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        [Display(Name = "Nombre de la Actividad")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha es requerida")]
        [Display(Name = "Fecha y Hora")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El cupo máximo es requerido")]
        [Range(1, 100, ErrorMessage = "El cupo debe estar entre 1 y 100")]
        [Display(Name = "Cupo Máximo")]
        public int CupoMaximo { get; set; }

        [StringLength(100, ErrorMessage = "El lugar no puede exceder 100 caracteres")]
        [Display(Name = "Lugar")]
        public string Lugar { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; } = "Disponible";

        [Display(Name = "Cupos Disponibles")]
        public int CuposDisponibles { get; set; }
    }
}