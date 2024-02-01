using Microsoft.AspNetCore.Mvc;

namespace datetimeproj.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    /*private static readonly string[] Summaries = new[]
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
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }*/

    CitiesDictionary _citiesDictionary;
    public WeatherForecastController(CitiesDictionary citiesDictionary)
    {
        _citiesDictionary = citiesDictionary;
    }


    [HttpPost("GetCitiesDateTime")]
    public IActionResult GetCitiesDateTime([FromBody] string cityName)
    {
        
        if (_citiesDictionary.CityUTC.ContainsKey(cityName))
        {
            int utcOffset = _citiesDictionary.CityUTC[cityName];
            DateTime cityTime = DateTime.UtcNow.AddHours(utcOffset);
            int value = _citiesDictionary.CityUTC[cityName];

            return Ok(new
            {
                cityName = cityName,
                cityTime = cityTime.ToString("UTC: " + value + ", yyyy-dd-MM HH:mm:ss")
            });
        }
        else
        {
            int defaultUtcOffset = _citiesDictionary.CityUTC["London"];
            DateTime defaultCityTime = DateTime.UtcNow.AddHours(defaultUtcOffset);
            int value = _citiesDictionary.CityUTC["London"];

            return Ok(new
            {
                cityName = "London", // Set the default city name
                 // Get the corresponding value for the default city
                cityTime = defaultCityTime.ToString("UTC: " + value + ", yyyy-dd-MM HH:mm:ss")
            });
        };
    }
    [HttpGet("GetCitiesDictionary")]
    public IActionResult GetCitiesDictionary() { 
            return Ok(new
            {
                cities = _citiesDictionary
            });
        }
    }