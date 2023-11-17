using MediatR;
using RestApiCrudDemo.EmployeeData;
using RestApiCrudDemo.Models;
using System.ComponentModel.DataAnnotations;

namespace RestApiCrudDemo.Query
{
    public class AddEmpQuery:IRequest<Employee>
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;


        public AddEmpQuery(int id, string name)
        {
            Id = id;
            Name = name;
        }

        
    }

    public class AddEmployeeQueryHandler : IRequestHandler<AddEmpQuery, Employee>
    {
        IEmployeeData _employeeData;
        public AddEmployeeQueryHandler(IEmployeeData employeeData)
        {

            _employeeData = employeeData;

        }

        public Task<Employee> Handle(AddEmpQuery request, CancellationToken cancellationToken)
        {
            Employee emp = new Employee();
            emp.Id = request.Id;
            emp.Name = request.Name;

            return Task.FromResult(_employeeData.AddEmployee(emp));
        }
    }
}
