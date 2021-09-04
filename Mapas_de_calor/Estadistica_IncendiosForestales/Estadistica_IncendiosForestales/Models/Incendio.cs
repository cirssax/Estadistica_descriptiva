using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estadistica_IncendiosForestales.Models
{
    public class metaData
    {
        public string title { get; set; }
        public string status { get; set; }
        public string count { get; set; }
    }

    public class geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class propiedades
    {
        public long id { get; set; }
        public string region { get; set; }
        public string provincia { get; set; }
        public string comuna { get; set; }
        public double? sup_afectada { get; set; }
        public double? temperatura { get; set; }
        public double? vel_viento { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
    }
    public class IncendioHeat
    {
        public string type { get; set; }
        public geometry geometry { get; set; }
        public long id { get; set; }
        public propiedades properties { get; set; }
    }
}
