using System;
using System.Collections.Generic;

namespace Estadistica_IncendiosForestales.Model
{
    public partial class Incendios
    {
        public int ID { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Region { get; set; }
        public string Provincia { get; set; }
        public string Comuna { get; set; }
        public double? Sup_Afectada { get; set; }
        public double? Temperatura { get; set; }
        public double? Vel_Viento { get; set; }
        public DateTime? Fecha_Inicio { get; set; }
        public DateTime? Fecha_Fin { get; set; }
    }
}
