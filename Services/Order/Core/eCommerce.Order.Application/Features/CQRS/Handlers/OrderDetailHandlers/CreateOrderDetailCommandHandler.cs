﻿using eCommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using eCommerce.Order.Application.Interfaces;
using eCommerce.Order.Domain.Entities;

namespace eCommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers {
    public class CreateOrderDetailCommandHandler {
        private readonly IRepository<OrderDetail> _repository;

        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository) {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand command) {
            await _repository.CreateAsync(new OrderDetail {
                ProductId = command.ProductId,
                ProductName = command.ProductName,
                ProductPrice = command.ProductPrice,
                ProductAmount = command.ProductAmount,
                ProductTotalPrice = command.ProductTotalPrice,
                OrderingId = command.OrderingId
            });
        }
    }
}