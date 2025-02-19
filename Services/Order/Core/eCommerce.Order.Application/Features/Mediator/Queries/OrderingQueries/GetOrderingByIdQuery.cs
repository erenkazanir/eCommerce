using eCommerce.Order.Application.Features.Mediator.Results.OrderingResults;
using MediatR;

namespace eCommerce.Order.Application.Features.Mediator.Queries.OrderingQueries {
    public class GetOrderingByIdQuery : IRequest<GetOrderingByIdQueryResult> {
        public int OrderingId { get; set; }

        public GetOrderingByIdQuery(int orderingId) {
            OrderingId = orderingId;
        }
    }
}