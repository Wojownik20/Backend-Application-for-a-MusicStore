using MediatR;
using MusicStore.Core.Data;

namespace MusicStore.WebAPI.Features.Customers.Commands
{
    public class CreateCustomerDapperCommand : IRequest<int>
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public CreateCustomerDapperCommand(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
    }
}