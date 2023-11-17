using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestApiCrudDemo.EmployeeData;
using RestApiCrudDemo.Models;
using RestApiCrudDemo.Query;

namespace RestApiCrudDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
        private IEmployeeData _employeeData;
        private readonly ISender _mediator;
        public EmployeesController(IEmployeeData employeeData, ISender mediator)
        {
            _employeeData = employeeData;
			_mediator = mediator;
        }

        [HttpGet]
		public  IActionResult GetEmployees()
        {
            var res =  _mediator.Send(new GetQuery());
			return Ok(res);
            //return Ok(_employeeData.GetEmployees());
        }

		[HttpGet]
		[Route("{id:int}")]
		public IActionResult GetEmployee(int id)
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
            var res = _mediator.Send<Employee>(new AddEmpQuery(employee.Id, employee.Name));
			// _employeeData.AddEmployee(employee);
			return Ok(res);
		}

		[HttpDelete]
		[Route("{id:int}")]
		public IActionResult DeleteEmployee(int id)
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
		[Route("{id:int}")]
		public IActionResult UpdateEmployee(int id, Employee employee)
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
