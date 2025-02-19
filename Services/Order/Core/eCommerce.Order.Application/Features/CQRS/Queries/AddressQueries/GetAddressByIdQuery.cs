namespace eCommerce.Order.Application.Features.CQRS.Queries.AddressQueries {
    public class GetAddressByIdQuery {
        public int AddressId { get; set; }

        public GetAddressByIdQuery(int addressId) {
            AddressId = addressId;
        }
    }
}