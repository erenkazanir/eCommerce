using eCommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using eCommerce.Order.Application.Interfaces;
using eCommerce.Order.Domain.Entities;

namespace eCommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers {
    public class RemoveOrderDetailCommandHandler {
        private readonly IRepository<OrderDetail> _repository;
        public RemoveOrderDetailCommandHandler(IRepository<OrderDetail> repository) {
            _repository = repository;
        }
        public async Task Handle(RemoveOrderDetailCommand query) {
            var value = await _repository.GetByIdAsync(query.OrderDetailId);
            await _repository.DeleteAsync(value);
        }
    }
}