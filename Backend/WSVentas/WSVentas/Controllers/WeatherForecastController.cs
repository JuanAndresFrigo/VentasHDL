using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WSVentas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            List<WeatherForecast> lst = new List<WeatherForecast>();

            lst.Add(new WeatherForecast() { Id = 5, Nombre = "Juan" });
            lst.Add(new WeatherForecast() { Id = 6, Nombre = "Andres" });
            lst.Add(new WeatherForecast() { Id = 7, Nombre = "Pedro" });
            lst.Add(new WeatherForecast() { Id = 8, Nombre = "Mario" });
            return lst;
        }
    }
}
