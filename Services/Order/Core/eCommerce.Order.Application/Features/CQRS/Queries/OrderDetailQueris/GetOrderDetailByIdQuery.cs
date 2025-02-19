namespace eCommerce.Order.Application.Features.CQRS.Queries.OrderDetailQueris {
    public class GetOrderDetailByIdQuery {
        public int OrderDetailId { get; set; }

        public GetOrderDetailByIdQuery(int orderDetailId) {
            OrderDetailId = orderDetailId;
        }
    }
}