using eCommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using eCommerce.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Order.WebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator) {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetOrderingList() {
            var result = await _mediator.Send(new GetOrderingQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderingById(int orderingId) {
            var result = await _mediator.Send(new GetOrderingByIdQuery(orderingId));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command) {
            await _mediator.Send(command);
            return Ok("Sipariş eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command) {
            await _mediator.Send(command);
            return Ok("Sipariş güncellendi.");
        }

        [HttpDelete("{orderingId}")]
        public async Task<IActionResult> RemoveOrdering(int orderingId) {
            await _mediator.Send(new RemoveOrderingCommand(orderingId));
            return Ok("Sipariş silindi.");
        }
    }
}