using MediatR;
using RestApiCrudDemo.EmployeeData;
using RestApiCrudDemo.Models;

namespace RestApiCrudDemo.Query
{
    public class GetQuery:IRequest<List<Employee>>
    {
    }

    public class GetEmployeeQueryHandler : IRequestHandler<GetQuery, List<Employee>>
    {
        private readonly IEmployeeData _employeeData;
        public GetEmployeeQueryHandler(IEmployeeData employeeData)
        {
            _employeeData = employeeData;   
        }

        public Task<List<Employee>> Handle(GetQuery request, CancellationToken cancellationToken)
        {
                //var resut = _employeeData.GetEmployees();
                //return Task.FromResult(resut);
                var res = _employeeData.GetEmployees();
                 return Task.FromResult(res);
                
        }
    }
}
