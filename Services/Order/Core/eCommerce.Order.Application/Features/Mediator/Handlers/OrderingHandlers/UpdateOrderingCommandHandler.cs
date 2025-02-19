using eCommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using eCommerce.Order.Application.Interfaces;
using eCommerce.Order.Domain.Entities;
using MediatR;

namespace eCommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers {
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand> {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository) {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken) {
            var value = await _repository.GetByIdAsync(request.OrderingId);
            value.OrderDate = request.OrderDate;
            value.TotalPrice = request.TotalPrice;
            value.UserId = request.UserId;
            await _repository.UpdateAsync(value);
        }
    }
}