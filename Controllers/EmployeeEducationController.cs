using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class EmployeeEducationController : Controller
    {
        private readonly ILogger<EmployeeEducationController> _logger;
        public EmployeeEducationController(ILogger<EmployeeEducationController> logger)
        {
            _logger = logger;
        }


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


        [HttpGet]
        public ActionResult GetFromEmpEducation([FromQuery] string courseName, [FromQuery] string universityName)
        {
            EmployeeEducation education = new EmployeeEducation();
            education.CourseName = courseName;
            education.UniversityName = universityName;

            var serializedOutput = JsonConvert.SerializeObject(education);
            return Ok(serializedOutput);
        }


        [HttpGet]
        public ActionResult GetEducationFromBody([FromBody] EmployeeEducation education)
        {
            return Ok($"Course name is {education.CourseName}, University name is {education.UniversityName}" +
                $" and Marks Percentage is {education.MarksPercent} ");

        }

        [HttpPost]

        public ActionResult AddEducation([System.Web.Http.FromBody] EmployeeEducation education)
        {
            employeeEducation.Add(education);
            return Ok(employeeEducation);
        }

        [HttpPut]

        public ActionResult UpdateEducationDetails(int id, [FromBody] EmployeeEducation education)
        {
            var emp = employeeEducation.Where(x => x.EduId == id).FirstOrDefault();
            if (emp == null)
            {
                return Ok("Employee education record not found!");

            }
            else
            {
                emp.EduId = education.EduId;
                emp.CourseName = education.CourseName;
                emp.UniversityName = education.UniversityName;
                emp.MarksPercent = education.MarksPercent;
                return Ok(employeeEducation);
            }
        }

        [HttpPatch]
        public ActionResult UpdateEducationPatch(int id, [FromBody] EmployeeEducation education)
        {
            var emp = employeeEducation.Where(x => x.EduId == id).FirstOrDefault();
            if (emp == null)
            {
                return Ok("Employee education record not found!");

            }
            else
            {
                emp.CourseName = education.CourseName;

                return Ok(employeeEducation);
            }
        }

        [HttpDelete]

        public ActionResult DeleteEmployeeEducation([FromQuery] int id)
        {
            var emp = employeeEducation.Where(x => x.EduId == id).FirstOrDefault();
            if (emp == null)
            {
                return Ok("Employee education record not found!");

            }
            else
            {
                employeeEducation.Remove(emp);
                return Ok(employeeEducation);

            }
        }

        [HttpPost]

        public ActionResult Adding([FromBody] EmployeeEducation education)
        {
            employeeEducation.Add(education);
            return Ok(employeeEducation);
        }

        [HttpDelete]

        public ActionResult DeleteFromHeader([FromHeader] int id)
        {
            var emp = employeeEducation.Where(x => x.EduId == id).FirstOrDefault();
            if (emp == null)
            {
                return Ok("Employee education record not found!");

            }
            else
            {
                employeeEducation.Remove(emp);

                return Ok(employeeEducation);
            }
        }

        [HttpPut("{EduId}/{CourseName}/{UniversityName}/{MarksPercent}")]

        public ActionResult UpdateFromRoute(int id,[FromRoute] EmployeeEducation education)

        {

            var emp = employeeEducation.Where(x => x.EduId == id).FirstOrDefault();
            if (emp == null)
            {
                return Ok("Employee education record not found!");

            }
            else
            {
                emp.EduId = education.EduId;
                emp.CourseName = education.CourseName;
                emp.UniversityName = education.UniversityName;
                emp.MarksPercent = education.MarksPercent;
                return Ok(employeeEducation);
            }
        }

        [HttpGet]

        public ActionResult GetEducationDetails([FromQuery] EmployeeEducation education)
        {
            return Ok($"Course name is {education.CourseName}, University name is {education.UniversityName}" +
                $" and Marks Percent is {education.MarksPercent} ");
        }





    }
}







