using eCommerce.Order.Application.Features.CQRS.Results.OrderDetailResults;
using eCommerce.Order.Application.Interfaces;
using eCommerce.Order.Domain.Entities;

namespace eCommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers {
    public class GetOrderDetailQueryHandler {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository) {
            _repository = repository;
        }

        public async Task<List<GetOrderDetailQueryResult>> Handle() {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderDetailQueryResult {
                OrderDetailId = x.OrderDetailId,
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice,
                ProductAmount = x.ProductAmount,
                ProductTotalPrice = x.ProductTotalPrice,
                OrderingId = x.OrderingId
            }).ToList();
        }
    }
}