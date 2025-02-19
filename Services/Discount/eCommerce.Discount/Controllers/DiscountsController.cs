using eCommerce.Discount.Dtos;
using eCommerce.Discount.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountCouponService _discountService;

        public DiscountsController(IDiscountCouponService discountService) {
            _discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDiscountCouponAsync() {
            var coupons = await _discountService.GetAllDiscountCouponAsync();
            return Ok(coupons);
        }

        [HttpGet("{couponId}")]
        public async Task<IActionResult> GetDiscountCouponByIdAsync(int couponId) {
            var coupon = await _discountService.GetDiscountCouponByIdAsync(couponId);
            return Ok(coupon);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto) {
            await _discountService.CreateDiscountCouponAsync(createCouponDto);
            return Ok("İndirim kuponu başarıyla oluşturuldu!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto) {
            await _discountService.UpdateDiscountCouponAsync(updateCouponDto);
            return Ok("İndirim kuponu başarıyla güncellendi!");
        }

        [HttpDelete("{couponId}")]
        public async Task<IActionResult> DeleteDiscountCouponAsync(int couponId) {
            await _discountService.DeleteDiscountCouponAsync(couponId);
            return Ok("İndirim kuponu başarıyla silindi!");
        }

    }
}
