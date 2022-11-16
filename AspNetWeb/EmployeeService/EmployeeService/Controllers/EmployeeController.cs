using EmployeeService.Data;
using EmployeeService.Models.Dto;
using EmployeeService.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        
        #region Services 

        private readonly IEmployeeRepository _employeeRepository;

        #endregion

        #region Constructors

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        #endregion

        #region Public Methods

        [HttpGet("employees/all")]
        public ActionResult<IList<EmployeeDto>> GetAllEmployees()
        {
            return Ok(_employeeRepository.GetAll().Select(e =>
               new EmployeeDto
               {
                   Id = e.Id,
                   EmployeeTypeId = e.EmployeeTypeId,
                   DepartmentId = e.DepartmentId,
                   FirstName = e.FirstName,
                   Surname = e.Surname,
                   Patronymic = e.Patronymic,
                   Salary = e.Salary
               }
                ).ToList());
        }


        [HttpPost("employees/create")]
        public ActionResult<int> CreateEmployee([FromBody] EmployeeDto employee)
        {
            return Ok(_employeeRepository.Create(new Employee
            {
                EmployeeTypeId = employee.EmployeeTypeId,
                DepartmentId = employee.DepartmentId,
                FirstName = employee.FirstName,
                Surname = employee.Surname,
                Patronymic = employee.Patronymic,
                Salary = employee.Salary
            }));
        }

        [HttpDelete("employees/delete")]
        public ActionResult<bool> DeleteEmployeeType([FromQuery] int id)
        {
            return Ok(_employeeRepository.Delete(id));
        }

        #endregion

        //TODO: Доработать самостоятельно

    }
}
