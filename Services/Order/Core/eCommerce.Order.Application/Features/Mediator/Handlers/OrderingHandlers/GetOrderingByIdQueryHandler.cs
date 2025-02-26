﻿using eCommerce.Order.Application.Features.Mediator.Queries.OrderingQueries;
using eCommerce.Order.Application.Features.Mediator.Results.OrderingResults;
using eCommerce.Order.Application.Interfaces;
using eCommerce.Order.Domain.Entities;
using MediatR;

namespace eCommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers {
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult> {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingByIdQueryHandler(IRepository<Ordering> repository) {
            _repository = repository;
        }

        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken) {
            var value = await _repository.GetByIdAsync(request.OrderingId);
            return new GetOrderingByIdQueryResult {
                OrderingId = value.OrderingId,
                UserId = value.UserId,
                TotalPrice = value.TotalPrice,
                OrderDate = value.OrderDate
            };
        }
    }
}