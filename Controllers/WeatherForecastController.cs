using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {

        public List<EmployeeEducation> employeeEducation = new List<EmployeeEducation>
        {
            new EmployeeEducation()
            {
                EduId=1,CourseName="IT",UniversityName="Jntuh",MarksPercent=60
            },
            new EmployeeEducation()
            {
                EduId=4,CourseName="Java",UniversityName="Manipal",MarksPercent=69

            },
             new EmployeeEducation()
            {
                EduId=8,CourseName="Python",UniversityName="Bhopal",MarksPercent=71

            },
        };
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
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        //[HttpGet]
        //public ActionResult Get()
        //{
        //    return Ok(employeeList);

        //}

        private string SayHi(string name)
        {
            return $"Hi {name}";

        }
        [HttpGet]
        public ActionResult GetName()
        {
            return Ok(SayHi("Sruthi"));
        }


    }
}

       
       

       
      
          
         

        

