using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gestor_De_visitas.Models
{
    public class Modelovisitas
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public Nullable<System.DateTime> FechaEntrada { get; set; }
        public string Departamento { get; set; }
        public Nullable<bool> Estatus { get; set; }
        public Nullable<System.DateTime> FechaSalida { get; set; }
        public Nullable<TimeSpan> Duracion { get; set; }
    }
}