using MediatR;
using MusicStore.Core.Data;

namespace MusicStore.WebAPI.Features.Customers.Commands
{
    public class CreateCustomerCommand : IRequest<int> 
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public CreateCustomerCommand(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
    }
}