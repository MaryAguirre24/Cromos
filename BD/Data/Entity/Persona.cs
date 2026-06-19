using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BD.Data.Entity
{
    public class Persona : EntityBase
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "El nombre no puede exceder los {1} caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es obligatorio")]
        [MaxLength(50, ErrorMessage = "El apellidono puede exceder los {1} caracteres")]
        public string Apellido { get; set; }
        public int? Telefono { get; set; }
    }
}

