using eCommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using eCommerce.Order.Application.Interfaces;
using eCommerce.Order.Domain.Entities;

namespace eCommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers {
    public class RemoveAddressCommandHandler {
        private readonly IRepository<Address> _repository;
        public RemoveAddressCommandHandler(IRepository<Address> repository) {
            _repository = repository;
        }
        public async Task Handle(RemoveAddressCommand command) {
            var value = await _repository.GetByIdAsync(command.AddressId);
            await _repository.DeleteAsync(value);
        }
    }
}