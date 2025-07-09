using HRM.Applicatin.Common.Exceptions;
using HRM.Domain;
using MediatR;


namespace HRM.Applicatin
{
    public class DepartmentQueryHandler : IRequestHandler<DepartmentQuery, IEnumerable<Department>>
    {
        public readonly IDepartmentRepository _departmentRepository;

        public DepartmentQueryHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public async Task<IEnumerable<Department>> Handle(DepartmentQuery query, CancellationToken cancellationToken)
        {
            return await _departmentRepository.GetDepartmentsAsync();
        }

        public class GetDeartmentByIdQueryHandler(IDepartmentRepository departmentRepository) : IRequestHandler<GetDepartmentByIdQuery, Department>
        {
            public async Task<Department> Handle(GetDepartmentByIdQuery query, CancellationToken cancellationToken)
            {
                
                
                var department = await departmentRepository.GetDepartmentByIdAsync(query.id);

                if (department==null)
                {
                    throw new NotFoundException("Department Not Found");

                }

                return department;
            }
        }
    }
}
