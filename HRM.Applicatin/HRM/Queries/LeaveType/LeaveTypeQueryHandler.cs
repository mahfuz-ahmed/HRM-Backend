using HRM.Domain;
using MediatR;

namespace HRM.Applicatin
{
    public class LeaveTypeQueryHandler : IRequestHandler<LeaveTypeQuery, IEnumerable<LeaveType>>
    {
        public readonly ILeaveTypeRepository _leaveTypeRepository;

        public LeaveTypeQueryHandler(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<IEnumerable<LeaveType>> Handle(LeaveTypeQuery query, CancellationToken cancellationToken)
        {
            return await _leaveTypeRepository.GetLeaveTypeAsync();
        }

        public class GetLeaveTypeByIdQueryHandler(ILeaveTypeRepository leaveTypeRepository) : IRequestHandler<GetLeaveTypeByIdQuery, LeaveType>
        {
            public async Task<LeaveType> Handle(GetLeaveTypeByIdQuery query, CancellationToken cancellationToken)
            {
                return await leaveTypeRepository.GetLeaveTypeByIdAsync(query.id);
            }
        }
    }
}
