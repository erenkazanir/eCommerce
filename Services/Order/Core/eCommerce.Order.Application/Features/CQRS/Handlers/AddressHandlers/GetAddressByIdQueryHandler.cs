using eCommerce.Order.Application.Features.CQRS.Queries.AddressQueries;
using eCommerce.Order.Application.Features.CQRS.Results.AddressResults;
using eCommerce.Order.Application.Interfaces;
using eCommerce.Order.Domain.Entities;

namespace eCommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers {
    public class GetAddressByIdQueryHandler {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository) {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query) {
            var address = await _repository.GetByIdAsync(query.AddressId);
            return new GetAddressByIdQueryResult {
                AddressId = address.AddressId,
                UserId = address.UserId,
                Disctrict = address.District,
                City = address.City,
                Detail = address.Detail
            };
        }
    }
}