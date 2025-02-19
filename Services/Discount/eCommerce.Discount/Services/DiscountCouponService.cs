using Dapper;
using eCommerce.Discount.Context;
using eCommerce.Discount.Dtos;

namespace eCommerce.Discount.Services {
    public class DiscountCouponService : IDiscountCouponService {
        private readonly DapperContext _context;
        public DiscountCouponService(DapperContext context) {
            _context = context;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto) {
            string query = "INSERT INTO Coupons (CouponCode, Rate, IsActive, ValidDate) VALUES (@CouponCode, @Rate, @IsActive, @ValidDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponCode", createCouponDto.CouponCode);
            parameters.Add("@Rate", createCouponDto.Rate);
            parameters.Add("@IsActive", createCouponDto.IsActive);
            parameters.Add("@ValidDate", createCouponDto.ValidDate);

            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteDiscountCouponAsync(int couponId) {
            string query = "DELETE FROM Coupons WHERE CouponId = @CouponId";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponId", couponId);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync() {
            string query = "SELECT * FROM Coupons";
            using (var connection = _context.CreateConnection()) {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetDiscountCouponByIdDto> GetDiscountCouponByIdAsync(int couponId) {
            string query = "SELECT * FROM Coupons WHERE CouponId = @CouponId";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponId", couponId);
            using (var connection = _context.CreateConnection()) {
                return await connection.QueryFirstOrDefaultAsync<GetDiscountCouponByIdDto>(query, parameters);
            }
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto) {
            string query = "UPDATE Coupons SET CouponCode = @CouponCode, Rate = @Rate, IsActive = @IsActive, ValidDate = @ValidDate WHERE CouponId = @CouponId";
            var parameters = new DynamicParameters();
            parameters.Add("@CouponCode", updateCouponDto.CouponCode);
            parameters.Add("@Rate", updateCouponDto.Rate);
            parameters.Add("@IsActive", updateCouponDto.IsActive);
            parameters.Add("@ValidDate", updateCouponDto.ValidDate);
            parameters.Add("@CouponId", updateCouponDto.CouponId);

            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}