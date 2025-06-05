using MediatR;
using MusicStore.Core.Data;
using System.Collections.Generic;

namespace MusicStore.WebAPI.Features.Employees.Queries
{
    public class GetAllEmployeesQuery : IRequest<IEnumerable<Employee>>
    {
    }
}