using eCommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using eCommerce.Order.Application.Interfaces;
using eCommerce.Order.Domain.Entities;
using MediatR;

namespace eCommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers {
    public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommand> {
        private readonly IRepository<Ordering> _repository;

        public RemoveOrderingCommandHandler(IRepository<Ordering> repository) {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken) {
            var value = await _repository.GetByIdAsync(request.OrderingId);
            await _repository.DeleteAsync(value);
        }
    }
}