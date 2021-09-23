﻿using BatallaDeLosPenales.Models;
using BatallaDeLosPenales.Servicios.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BatallaDeLosPenales.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

		public IActionResult Ganador()
		{
			try
			{
				return View(DirectorTecnicoServicio.ObtenerTecnicoGanador());
			}
			catch (Exception)
			{
				ViewBag.NoGanador = "Todavia no hay directores tecnicos agregados, no hay ganador";
				return View();
			}
		}

		public IActionResult DirectoresTecnicos()
		{
			return View(DirectorTecnicoServicio.ObtenerTodos().OrderBy(dt => dt.NombreUsuario).ToList());
		}

		public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
