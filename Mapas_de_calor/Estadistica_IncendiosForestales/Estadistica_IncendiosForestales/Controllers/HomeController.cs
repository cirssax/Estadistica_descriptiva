using Estadistica_IncendiosForestales.Context;
using Estadistica_IncendiosForestales.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Estadistica_IncendiosForestales.Controllers
{
    public class HomeController : Controller
    {
        private readonly AplicationDbContext _db;

        public HomeController(AplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Visualizador")]
        public IActionResult Visualizador()
        {
            return View();
        }

        [Route("Clustering")]
        public IActionResult Clustering()
        {
            return View();
        }

        [Route("Datos")]
        public IActionResult Datos()
        {
            var listado = _db.Incendios.ToList();

            List<IncendioHeat> listaHeatMap = new List<IncendioHeat>();
            IncendioHeat nodo;
            propiedades properties;
            geometry data;

            foreach (var inc in listado)
            {
                List<double> puntos = new List<double>();
                puntos.Add(inc.Longitud);
                puntos.Add(inc.Latitud);

                data = new geometry()
                {
                    type = "Point",
                    coordinates = puntos
                };

                properties = new propiedades()
                {
                   id = inc.ID,
                   region = inc.Region,
                   provincia = inc.Provincia,
                   comuna = inc.Comuna,
                   sup_afectada = inc.Sup_Afectada,
                   temperatura = inc.Temperatura,
                   vel_viento = inc.Vel_Viento,
                   fecha_inicio = inc.Fecha_Inicio,
                   fecha_fin = inc.Fecha_Fin
                };

                nodo = new IncendioHeat()
                {
                    type = "Feature",
                    geometry = data,
                    id = inc.ID,
                    properties = properties
                };

                listaHeatMap.Add(nodo);
            }

            var metadata = new metaData()
            {
                title = "Incidents reported",
                status = "200",
                count = listaHeatMap.Count.ToString()
            };

            return Ok(new
            {
                type = "FeatureCollection",
                metadata = metadata,
                features = listaHeatMap
            });
        }
    }
}
