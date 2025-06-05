using MediatR;

namespace MusicStore.WebAPI.Features.Employees.Commands
{
    public class DeleteEmployeeDapperCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteEmployeeDapperCommand(int id)
        {
            Id = id;
        }
    }
}