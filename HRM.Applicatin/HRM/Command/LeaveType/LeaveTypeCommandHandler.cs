using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public class AddLeaveTypeCommandHandler : IRequestHandler<AddLeaveTypeCommand, LeaveType>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public AddLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<LeaveType> Handle(AddLeaveTypeCommand command, CancellationToken cancellationToken)
        {
            var addLeaveType = await _leaveTypeRepository.AddLeaveTypeAsync(command.leaveType);

            return addLeaveType;
        }

        public class UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository) : IRequestHandler<UpdateLeaveTypeCommand, LeaveType>
        {
            public async Task<LeaveType> Handle(UpdateLeaveTypeCommand command, CancellationToken cancellationToken)
            {
                return await leaveTypeRepository.UpdateLeaveTypeAsync(command.leaveTypeId, command.leaveType);
            }
        }

        public class DeleteLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository) : IRequestHandler<DeleteLeaveTypeCommand, bool>
        {
            public async Task<bool> Handle(DeleteLeaveTypeCommand command, CancellationToken cancellationToken)
            {
                return await leaveTypeRepository.DeleteLeaveTypeAsync(command.leaveTypeId);
            }
        }
    }
}
