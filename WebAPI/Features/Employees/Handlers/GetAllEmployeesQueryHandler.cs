﻿using MediatR;
using MusicStore.Core.Data;
using MusicStore.Platform.Repositories.Interfaces.EntityFramework;
using MusicStore.WebAPI.Features.Employees.Queries;

namespace LeverX.WebAPI.Features.Employees.Handlers
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetAllAsync();
        }
    }
}