using GreyApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace GreyApi.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetStudent/{name}/{uniname}")]
        public string GetStudent(string name , string uniname)
        {
            return "My name is "+ name + " and i am from "+ uniname;
        }

        [HttpPost("SaveStudent")]
        public string SaveStudent(Student student)
        {

            return "My name is " + student.Name + " and i am from " + student.Uni;
        }


    }
}