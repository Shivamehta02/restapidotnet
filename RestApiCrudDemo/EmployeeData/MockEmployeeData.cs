using RestApiCrudDemo.Data;
using RestApiCrudDemo.Models;

namespace RestApiCrudDemo.EmployeeData;

public class MockEmployeeData : IEmployeeData
{
	private List<Employee> employees = new List<Employee>()
	{
		new Employee()
		{
			Id = Guid.NewGuid(),
			Name = "Test 1"
		},
		new Employee()
		{
			Id =  Guid.NewGuid(),
			Name = "Test 2"
		}
	};

	private readonly EmployeeContext _context;
    public MockEmployeeData(EmployeeContext context)
    {
		_context = context;
    }
    public Employee AddEmployee(Employee employee)
	{
		employee.Id = Guid.NewGuid();
		_context.Employees.Add(employee);
		_context.SaveChanges();
		return employee;
	}

	public void DeleteEmployee(Employee employee)
	{
		var existemployee = _context.Employees.Find(employee.Id);
		
		_context.Employees.Remove(existemployee);
		_context.SaveChanges();
		//var existemployee = GetEmployee(employee.Id);//before sqlserver use only this line
		//employees.Remove(employee);
	}

	public Employee EditEmployee(Employee employee)
	{
		var existemployee =  _context.Employees.Find(employee.Id);
        if (existemployee != null)
        {
			existemployee.Name = employee.Name;
			_context.Employees.Update(existemployee);
			_context.SaveChanges();
        }
		//var existemployee = GetEmployee(employee.Id);//before sqlserver use only this line
		//existemployee.Name = employee.Name;
		//return existemployee;

		return employee;
	}

	public Employee GetEmployee(Guid id)
	{
		var employee = _context.Employees.Find(id);
		return employee;
		//return employees.SingleOrDefault(x => x.Id == id);//before sqlserver use only this line
	}

	public List<Employee> GetEmployees()
	{
		return _context.Employees.ToList();
		// return employees; //before sqlserver use only this line
		
	}
}
