using eCommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using eCommerce.Order.Application.Interfaces;
using eCommerce.Order.Domain.Entities;

namespace eCommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers {
    public class CreateAddressCommandHandler {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository) {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand createAddressCommand) {
            await _repository.CreateAsync(new Address {
                UserId = createAddressCommand.UserId,
                District = createAddressCommand.Disctrict,
                City = createAddressCommand.City,
                Detail = createAddressCommand.Detail
            });
        }
    }
}