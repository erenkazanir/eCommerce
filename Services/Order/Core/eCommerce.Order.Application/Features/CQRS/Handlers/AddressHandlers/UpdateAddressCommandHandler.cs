using eCommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using eCommerce.Order.Application.Interfaces;
using eCommerce.Order.Domain.Entities;

namespace eCommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers {
    public class UpdateAddressCommandHandler {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository) {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand command) {
            var value = await _repository.GetByIdAsync(command.AddressId);
            value.UserId = command.UserId;
            value.District = command.District;
            value.City = command.City;
            value.Detail = command.Detail;
            await _repository.UpdateAsync(value);
        }
    }
}