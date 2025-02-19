using eCommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using eCommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using eCommerce.Order.Application.Features.CQRS.Queries.OrderDetailQueris;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Order.WebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase {
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;

        public OrderDetailsController(GetOrderDetailQueryHandler getOrderDetailQueryHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler) {
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetailList() {
            var result = await _getOrderDetailQueryHandler.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int orderDetailId) {
            var result = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(orderDetailId));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command) {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok("Sipariş detayı eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command) {
            await _updateOrderDetailCommandHandler.Handle(command);
            return Ok("Sipariş detayı güncellendi.");
        }

        [HttpDelete("{orderDetailId}")]
        public async Task<IActionResult> RemoveOrderDetail(int orderDetailId) {
            await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(orderDetailId));
            return Ok("Sipariş detayı silindi.");
        }
    }
}
