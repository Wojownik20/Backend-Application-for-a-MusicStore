using MediatR;
using MusicStore.Core.Data;
using System.Collections.Generic;

namespace MusicStore.WebAPI.Features.Employees.Queries
{
    public class GetEmployeeByIdDapperQuery : IRequest<Employee>
    {
        public int Id { get; }

        public GetEmployeeByIdDapperQuery(int id)
        {
            Id = id;
        }
    }
}