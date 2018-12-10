//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRUD_Alumnos.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class paciente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public paciente()
        {
            this.pacienteEnfermedad = new HashSet<pacienteEnfermedad>();
        }
    
        public long id { get; set; }
        [Required]
        [Display(Name = "Nombre del Paciente")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "Apellido del Paciente")]
        public string apellido { get; set; }
        public System.DateTime fechaNacimiento { get; set; }
        public decimal peso { get; set; }
        public decimal altura { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pacienteEnfermedad> pacienteEnfermedad { get; set; }
    }
}