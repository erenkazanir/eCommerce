﻿using MediatR;

namespace eCommerce.Order.Application.Features.Mediator.Commands.OrderingCommands {
    public class RemoveOrderingCommand : IRequest {
        public int OrderingId { get; set; }

        public RemoveOrderingCommand(int orderingId) {
            OrderingId = orderingId;
        }
    }
}