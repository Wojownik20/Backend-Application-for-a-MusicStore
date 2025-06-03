﻿using MediatR;

namespace MusicStore.WebAPI.Features.Orders.Commands
{
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteOrderCommand(int id)
        {
            Id = id;
        }
    }
}