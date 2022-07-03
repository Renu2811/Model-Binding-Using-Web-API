using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        public List<Employee> employeeList = new List<Employee>()
        {
             new Employee()
               {
                   EmpId =100, EmpName="Manoj", EmpAddress ="Banglore",EmpAge=25
               },
             new Employee()
               {
                   EmpId =101,  EmpName="Yash" ,EmpAddress="Delhi",EmpAge=32
               },
             new Employee()
               {
                   EmpId=103,  EmpName="Ram",EmpAddress="Hyderabad",EmpAge=23
               },
             new Employee()
               {
                   EmpId =106, EmpName="Parnitha" ,EmpAddress="Banglore",EmpAge=27
               },
        };

        [HttpPost]
        public ActionResult Post()
        {
            employeeList.Add(new Employee { EmpId = 32, EmpName = "Manasa", EmpAddress = "Hyderabad", EmpAge = 35 });
            return Ok(employeeList);
        }

        [HttpGet]
        public ActionResult GetEmployeeDetails()
        {
            employeeList = new List<Employee>();
            employeeList.Add(new Employee { EmpId = 34, EmpName = "Ravali", EmpAddress = "Banglore", EmpAge = 25 });
            employeeList.Add(new Employee { EmpId = 37, EmpName = "Tanusri", EmpAddress = "Chennai", EmpAge = 27 });
            employeeList.Add(new Employee { EmpId = 39, EmpName = "Ram", EmpAddress = "Hyderabad", EmpAge = 23 });

            return Ok(employeeList);

        }

        [HttpPut]
        public ActionResult Update(int id)
        {
            var emp = employeeList.Where(x => x.EmpId == id).FirstOrDefault();
            emp.EmpId = 23;
            emp.EmpName = "Manisha";
            emp.EmpAddress = "Delhi";
            emp.EmpAge = 22;
            return Ok(employeeList);
        }
        [HttpPatch]
        public ActionResult UpdatePartially(int id)
        {
            var emp = employeeList.Where(x => x.EmpId == id).FirstOrDefault();
            emp.EmpId = 20;
            return Ok(employeeList);

        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {


            var emp = employeeList.Where(x => x.EmpId == id).FirstOrDefault();
            employeeList.Remove(emp);


            return Ok(employeeList);
        }



        [HttpGet]
        public ActionResult GetFromUri([FromQuery] string name, [FromQuery] string address)
        {
            Employee employee = new Employee();
            employee.EmpName = name;
            employee.EmpAddress = address;

            var serializedOutput = JsonConvert.SerializeObject(employee);
            return Ok(serializedOutput);
        }

        [HttpGet]
        public ActionResult GetFromBody([FromBody] Employee employee)
        {
            return Ok($"Employee name is {employee.EmpName}, employee Address is {employee.EmpAddress}" +
                $" and Employee Age is {employee.EmpAge} ");
        }

        [HttpPost]

        public ActionResult Add([FromBody] Employee employee)
        {
            employeeList.Add(employee);
            return Ok(employeeList);
        }

        [HttpPut]

        public ActionResult UpdateEmployeeDetails(int id, [FromBody] Employee employee)
        {
            var emp = employeeList.Where(x => x.EmpId == id).FirstOrDefault();
            if (emp == null)
            {
                return Ok("Employee  record not found!");

            }
            else
            {
                emp.EmpId = employee.EmpId;
                emp.EmpName = employee.EmpName;
                emp.EmpAddress = employee.EmpAddress;
                emp.EmpAge = employee.EmpAge;
                return Ok(employeeList);
            }
        }

        [HttpPatch]

        public ActionResult UpdateEmployeePatch(int id, [FromBody] Employee employee)
        {
            var emp = employeeList.Where(x => x.EmpId == id).FirstOrDefault();
            if (emp == null)
            {
                return Ok("Employee  record not found!");

            }
            else
            {
                emp.EmpName = employee.EmpName;
                return Ok(employeeList);

            }
        }

        [HttpDelete]

        public ActionResult DeleteEmployee([FromQuery] int id)
        {
            var emp = employeeList.Where(x => x.EmpId == id).FirstOrDefault();
            if (emp == null)
            {
                return Ok("Employee record not found!");

            }
            else
            {
                employeeList.Remove(emp);
                return Ok(employeeList);

            }
        }

        [HttpGet]

        public ActionResult ReadFromBody(string name, Employee employee)
        {
            return Ok($"Name is {name} and Employee Name is {employee.EmpName} and Employee Address is {employee.EmpAddress}");

        }


        [HttpPost]
        public ActionResult ReadFromQuery([FromQuery] string name, [FromQuery] string address, Employee employee)
        {
            return Ok($" Name is {name} , Address is {address}  and Employee Name is {employee.EmpName} , Employee Address is {employee.EmpAddress}");

        }

        [HttpGet]

        public ActionResult ReadFromHeader([FromHeader] string name, [FromHeader] string address)
        {
            return Ok($"Name is {name} and Address is {address} ");
        }

        [HttpGet("{name}/{address}")]
        public ActionResult ReadFromRoute([FromRoute] string name, [FromRoute] string address)
        {
            return Ok($"Employee Name is {name} and Employee Address is {address}");
        }

    }
}

