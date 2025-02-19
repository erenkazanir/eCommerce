using eCommerce.Order.Application.Features.CQRS.Queries.OrderDetailQueris;
using eCommerce.Order.Application.Features.CQRS.Results.OrderDetailResults;
using eCommerce.Order.Application.Interfaces;
using eCommerce.Order.Domain.Entities;

namespace eCommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers {
    public class GetOrderDetailByIdQueryHandler {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository) {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query) {
            var value = await _repository.GetByIdAsync(query.OrderDetailId);
            return new GetOrderDetailByIdQueryResult {
                OrderDetailId = value.OrderDetailId,
                ProductId = value.ProductId,
                ProductName = value.ProductName,
                ProductPrice = value.ProductPrice,
                ProductAmount = value.ProductAmount,
                ProductTotalPrice = value.ProductTotalPrice,
                OrderingId = value.OrderingId
            };
        }
    }
}
