using Dapper;
using Discount.API.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Threading.Tasks;

namespace Discount.API.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;
        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<Coupon> GetDiscount(string productName)
        {
            using var connection = new NpgsqlConnection
                (
                    _configuration.GetValue<string>("DatabaseSettings:ConnectionString")
                );

            var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
                ("Select * from Coupon where ProductName =@ProductName", new { ProductName = productName });

            if (coupon == null)
                return new Coupon
                { ProductName = "No Discount", Amount = 0, Decription = "No Discount DESC" };
            return coupon;
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected =
                await connection.ExecuteAsync
                ("insert into coupon(ProductName,decription,amount) values(@ProductName,@Decription,@Amount)",
                new { ProductName = coupon.ProductName, Decription = coupon.Decription, Amount = coupon.Amount });
            if (affected == 0)
                return false;

            return true;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var affected = await connection.ExecuteAsync
                ("Delete FROM Coupon WHERE ProductName = @ProductName", new { Productname = productName });
            if (affected == 0)
                return false;
            return true;
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            using var connection = new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

            var affected = await connection.ExecuteAsync
                ("Update Coupon SET ProductName = @ProductName ,Decription = @Decription,Amount = @Amount WHERE id = @Id",
                new { ProducName = coupon.ProductName, Decription = coupon.Decription, Amount = coupon.Amount });

            if (affected == 0)
                return false;
            return true;
        }
    }
}
