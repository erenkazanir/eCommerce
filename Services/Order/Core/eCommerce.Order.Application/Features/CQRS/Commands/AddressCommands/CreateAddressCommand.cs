namespace eCommerce.Order.Application.Features.CQRS.Commands.AddressCommands {
    public class CreateAddressCommand {
        public string UserId { get; set; }
        public string Disctrict { get; set; }
        public string City { get; set; }
        public string Detail { get; set; }
    }
}