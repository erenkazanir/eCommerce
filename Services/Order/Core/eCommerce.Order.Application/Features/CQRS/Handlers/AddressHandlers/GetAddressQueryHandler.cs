using eCommerce.Order.Application.Features.CQRS.Results.AddressResults;
using eCommerce.Order.Application.Interfaces;
using eCommerce.Order.Domain.Entities;

namespace eCommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers {
    public class GetAddressQueryHandler {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository) {
            _repository = repository;
        }

        public async Task<List<GetAddressQueryResult>> Handle() {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult {
                AddressId = x.AddressId,
                UserId = x.UserId,
                Disctrict = x.District,
                City = x.City,
                Detail = x.Detail
            }).ToList();
        }
    }
}