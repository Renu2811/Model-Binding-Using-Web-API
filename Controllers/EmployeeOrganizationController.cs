using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeOrganizationController : Controller
    {
        private readonly ILogger<EmployeeOrganizationController> _logger;
        public EmployeeOrganizationController(ILogger<EmployeeOrganizationController> logger)
        {
            _logger = logger;
        }

        public List<EmployeeOrganization> employeeOrganization = new List<EmployeeOrganization>
        {
            new EmployeeOrganization()
            {
                OrgId=107,OrgName="Wipro",OrgLocation="Hyderabad"
            },
            new EmployeeOrganization()
            {
                 OrgId=110,OrgName="Infosys",OrgLocation="Banglore"

            },
             new EmployeeOrganization()
            {
                 OrgId=134,OrgName="Capgemini",OrgLocation="Hyderabad"

            },
        };


        [HttpGet]
        public ActionResult GetFromEmpOrganization([FromQuery] string OrgName, [FromQuery] string OrgLocation)
        {
            EmployeeOrganization organization = new EmployeeOrganization();
            organization.OrgName = OrgName;
            organization.OrgLocation = OrgLocation;

            var serializedOutput = JsonConvert.SerializeObject(organization);
            return Ok(serializedOutput);
        }


        [HttpGet]
        public ActionResult GetorganizationFromBody([FromBody] EmployeeOrganization organization)
        {
            return Ok($"Organization name is {organization.OrgName}, Location name is {organization.OrgLocation} ");

        }

        [HttpPost]

        public ActionResult Addorganization([FromBody] EmployeeOrganization organization)
        {
            employeeOrganization.Add(organization);
            return Ok(employeeOrganization);
        }

        [HttpPut]

        public ActionResult UpdateorganizationDetails(int id, [FromBody] EmployeeOrganization organization)
        {
            var emp = employeeOrganization.Where(x => x.OrgId == id).FirstOrDefault();
            if (emp == null)
            {
                return Ok("Employee organization record not found!");

            }
            else
            {
                emp.OrgId = organization.OrgId;
                emp.OrgName = organization.OrgName;
                emp.OrgLocation = organization.OrgLocation;
                return Ok(employeeOrganization);
            }
        }

        [HttpPatch]
        public ActionResult UpdateorganizationPatch(int id, [FromBody] EmployeeOrganization organization)
        {
            var emp = employeeOrganization.Where(x => x.OrgId == id).FirstOrDefault();
            if (emp == null)
            {
                return Ok("Employee organization record not found!");

            }
            else
            {
                emp.OrgName = organization.OrgName;

                return Ok(employeeOrganization);
            }
        }

        [HttpDelete]

        public ActionResult DeleteEmployeeOrganization([FromQuery] int id)
        {
            var emp = employeeOrganization.Where(x => x.OrgId == id).FirstOrDefault();
            if (emp == null)
            {
                return Ok("Employee organization record not found!");

            }
            else
            {
                employeeOrganization.Remove(emp);
                return Ok(employeeOrganization);

            }
        }

        [HttpPost]

        public ActionResult Adding([FromBody] EmployeeOrganization organization)
        {
            employeeOrganization.Add(organization);
            return Ok(employeeOrganization);
        }

        [HttpDelete]

        public ActionResult DeleteFromHeader([FromHeader] int id)
        {
            var emp = employeeOrganization.Where(x => x.OrgId == id).FirstOrDefault();
            if (emp == null)
            {
                return Ok("Employee Organization record not found!");

            }
            else
            {
                employeeOrganization.Remove(emp);

                return Ok(employeeOrganization);
            }
        }

        [HttpPut("{OrgId}/{OrgName}/{OrgLocation}")]

        public ActionResult UpdateFromRoute(int id,[FromRoute] EmployeeOrganization organization)
        {
            var emp = employeeOrganization.Where(x => x.OrgId == id).FirstOrDefault();
            if (emp == null)
            {
                return Ok("Employee organization record not found!");

            }
            else
            {
                emp.OrgId = organization.OrgId;
                emp.OrgName = organization.OrgName;
                emp.OrgLocation = organization.OrgLocation;
                return Ok(employeeOrganization);

            }

        }

        [HttpGet]

        public ActionResult GetOrganizationDetails([FromQuery] EmployeeOrganization organization)
        {
            return Ok($"Organization name is {organization.OrgName}, Location name is {organization.OrgLocation}");
        }

    }
}





