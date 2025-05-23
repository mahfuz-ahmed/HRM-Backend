using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public class AddDepartmentCommandHandler : IRequestHandler<AddDepartmentCommand, Department>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public AddDepartmentCommandHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public async Task<Department> Handle(AddDepartmentCommand command, CancellationToken cancellationToken)
        {
            var addDepartment = await _departmentRepository.AddDepartmentAsync(command.department);

            return addDepartment;
        }

        public class UpdateDepartmentCommandHandler(IDepartmentRepository departmentRepository) : IRequestHandler<UpdateDepartmentCommand, Department>
        {
            public async Task<Department> Handle(UpdateDepartmentCommand command, CancellationToken cancellationToken)
            {
                return await departmentRepository.UpdateDepartmentAsync(command.departmentId, command.department);
            }
        }

        public class DeleteDepartmentCommandHandler(IDepartmentRepository departmentRepository) : IRequestHandler<DeleteDepartmentCommand, bool>
        {
            public async Task<bool> Handle(DeleteDepartmentCommand command, CancellationToken cancellationToken)
            {
                return await departmentRepository.DeleteDepartmentAsync(command.departmentId);
            }
        }
    }
}
