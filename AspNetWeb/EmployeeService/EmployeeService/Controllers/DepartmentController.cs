using EmployeeService.Data;
using EmployeeService.Models.Dto;
using EmployeeService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        #region Services 

        private readonly IDepartmentRepository _departmentRepository;

        #endregion

        #region Constructors

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        #endregion
        #region Public Methods

        [HttpGet("departments/all")]
        public ActionResult<IList<DepartmentDto>> GetAllDepartments()
        {
            return Ok(_departmentRepository.GetAll().Select(d =>
               new EmployeeTypeDto
               {
                   Id = d.Id,
                   Description = d.Description
               }
                ).ToList());
        }


        [HttpPost("departments/create")]
        public ActionResult<int> CreateDepartment([FromQuery] string description)
        {
            return Ok(_departmentRepository.Create(new Department
            {
                Description = description
            }));
        }

        [HttpDelete("departments/delete")]
        public ActionResult<bool> DeleteDepartment([FromQuery] int id)
        {
            return Ok(_departmentRepository.Delete(id));
        }

        #endregion
        //TODO: Доработать самостоятельно+641

    }
}
