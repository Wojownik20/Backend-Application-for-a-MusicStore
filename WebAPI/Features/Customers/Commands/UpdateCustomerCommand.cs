﻿using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using System;

namespace MusicStore.WebAPI.Features.Customers.Commands
{
    public class UpdateCustomerCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public UpdateCustomerCommand(int id, string name, DateTime birthDate)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
        }
    }
}