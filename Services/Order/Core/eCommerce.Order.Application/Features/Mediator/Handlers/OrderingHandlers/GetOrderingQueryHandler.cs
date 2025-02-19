using eCommerce.Order.Application.Features.Mediator.Queries.OrderingQueries;
using eCommerce.Order.Application.Features.Mediator.Results.OrderingResults;
using eCommerce.Order.Application.Interfaces;
using eCommerce.Order.Domain.Entities;
using MediatR;

namespace eCommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers {
    public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>> {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingQueryHandler(IRepository<Ordering> repository) {
            _repository = repository;
        }

        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken) {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderingQueryResult {
                OrderingId = x.OrderingId,
                UserId = x.UserId,
                TotalPrice = x.TotalPrice,
                OrderDate = x.OrderDate
            }).ToList();
        }
    }
}