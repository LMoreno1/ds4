using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models.Entities
{
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El código es requerido")]
        [StringLength(20, ErrorMessage = "El código no puede exceder 20 caracteres")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        [Display(Name = "Nombre Completo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "Email no válido")]
        [StringLength(100, ErrorMessage = "El email no puede exceder 100 caracteres")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La carrera es requerida")]
        [StringLength(50, ErrorMessage = "La carrera no puede exceder 50 caracteres")]
        [Display(Name = "Carrera")]
        public string Carrera { get; set; }

        [Required(ErrorMessage = "El semestre es requerido")]
        [Range(1, 12, ErrorMessage = "El semestre debe estar entre 1 y 12")]
        [Display(Name = "Semestre")]
        public int Semestre { get; set; }

    }
}