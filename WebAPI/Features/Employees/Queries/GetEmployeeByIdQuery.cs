using MediatR;
using MusicStore.Core.Data;
using System.Collections.Generic;

namespace MusicStore.WebAPI.Features.Employees.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public int Id { get; }

        public GetEmployeeByIdQuery(int id)
        {
            Id = id;
        }
    }
}