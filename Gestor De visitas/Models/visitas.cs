//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gestor_De_visitas.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class visitas
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public Nullable<System.DateTime> FechaEntrada { get; set; }
        public string Departamento { get; set; }
        public Nullable<bool> Estatus { get; set; }
        public Nullable<System.DateTime> FechaSalida { get; set; }
    }
}
