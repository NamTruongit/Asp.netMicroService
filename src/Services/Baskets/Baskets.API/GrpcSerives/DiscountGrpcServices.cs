
using Discount.GRPC.Protos;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Baskets.API.GrpcSerives
{
    public class DiscountGrpcServices 
    {
        private readonly DiscountProtoSerivces.DiscountProtoSerivcesClient _protoSerivcesBase;
        public DiscountGrpcServices(DiscountProtoSerivces.DiscountProtoSerivcesClient protoSerivcesBase)
        {
            _protoSerivcesBase = protoSerivcesBase ?? throw new ArgumentNullException(nameof(protoSerivcesBase));
        }

        public async Task<CouponModel> GetDiscount(string produtName)
        {
            var discountRequest = new GetDiscountRequest { ProductName = produtName };
            return await _protoSerivcesBase.GetDiscountAsync(discountRequest);
        }
    }
}
