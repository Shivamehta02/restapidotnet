using Microsoft.AspNetCore.Mvc;
using RestApiCrudDemo.Models;

namespace RestApiCrudDemo.EmployeeData
{
	public interface IEmployeeData
	{
		List<Employee> GetEmployees();
		Employee GetEmployee(int id);

		//Employee AddEmployee(Employee employee);
		Employee AddEmployee(Employee employee);

		void DeleteEmployee(Employee employee);

		Employee EditEmployee(Employee employee);
	}
}

 