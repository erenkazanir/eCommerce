using eCommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using eCommerce.Order.Application.Interfaces;
using eCommerce.Order.Domain.Entities;

namespace eCommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers {
    public class UpdateOrderDetailCommandHandler {
        private readonly IRepository<OrderDetail> _repository;
        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository) {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderDetailCommand command) {
            var value = await _repository.GetByIdAsync(command.OrderDetailId);
            value.OrderingId = command.OrderingId;
            value.ProductId = command.ProductId;
            value.ProductPrice = command.ProductPrice;
            value.ProductTotalPrice = command.ProductTotalPrice;
            value.ProductName = command.ProductName;
            value.ProductAmount = command.ProductAmount;
            await _repository.UpdateAsync(value);
        }
    }
}