using Microsoft.AspNetCore.Mvc;
using RestApiCrudDemo.EmployeeData;
using RestApiCrudDemo.Models;

namespace RestApiCrudDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
        private IEmployeeData _employeeData;
        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet]
		public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

		[HttpGet]
		[Route("{id:guid}")]
		public IActionResult GetEmployee(Guid id)
		{
			var employee = _employeeData.GetEmployee(id);
			if (employee == null)
			{
				return NotFound("employee not found");
			}
			return Ok(employee);
		}

		[HttpPost]
		public IActionResult AddEmployee(Employee employee)
		{
			 _employeeData.AddEmployee(employee);
			
			return Ok(employee);
		}

		[HttpDelete]
		[Route("{id:guid}")]
		public IActionResult DeleteEmployee(Guid id)
		{
			var employee = _employeeData.GetEmployee(id);
			if (employee != null)
			{
			_employeeData.DeleteEmployee(employee);
			return Ok();
			}
			return NotFound("employee not found");
		}

		[HttpPut]
		[Route("{id:guid}")]
		public IActionResult UpdateEmployee(Guid id, Employee employee)
		{
			var existemployee = _employeeData.GetEmployee(id);
			if (existemployee != null)
			{
				employee.Id = existemployee.Id;
				_employeeData.EditEmployee(employee);
				return Ok();
			}
			return NotFound("employee not found");
		}
	}
}
