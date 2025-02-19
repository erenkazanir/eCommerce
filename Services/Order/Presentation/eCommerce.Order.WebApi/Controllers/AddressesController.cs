using eCommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using eCommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using eCommerce.Order.Application.Features.CQRS.Queries.AddressQueries;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Order.WebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase {
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;

        public AddressesController(GetAddressQueryHandler getAddressQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, RemoveAddressCommandHandler removeAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler) {
            _getAddressQueryHandler = getAddressQueryHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddressList() {
            var result = await _getAddressQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int addressId) {
            var result = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(addressId));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command) {
            await _createAddressCommandHandler.Handle(command);
            return Ok("Adres bilgisi eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command) {
            await _updateAddressCommandHandler.Handle(command);
            return Ok("Adres bilgisi güncellendi.");
        }

        [HttpDelete("{addressId}")]
        public async Task<IActionResult> RemoveAddress(int addressId) {
            await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(addressId));
            return Ok("Adres bilgisi silindi.");
        }
    }
}