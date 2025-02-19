using eCommerce.Discount.Dtos;

namespace eCommerce.Discount.Services {
    public interface IDiscountCouponService {
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync();
        Task<GetDiscountCouponByIdDto> GetDiscountCouponByIdAsync(int couponId);
        Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto);
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto);
        Task DeleteDiscountCouponAsync(int couponId);
    }
}