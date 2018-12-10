using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Alumnos.Models
{
    public class PacienteCE
    {
    }

    public partial class paciente
    {
        public int Estado { get; set; }
        public String NombreCompleto { get { return nombre + " " + apellido; } }

    }
}