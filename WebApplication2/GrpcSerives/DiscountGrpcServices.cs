using Discount.GRPC.Protos;
using System;
using System.Threading.Tasks;

namespace WebApplication2.GrpcSerives
{
    public class DiscountGrpcServices
    {
        private readonly DiscountProtoSerivces.DiscountProtoSerivcesBase _protoSerivcesBase;
        public DiscountGrpcServices(DiscountProtoSerivces.DiscountProtoSerivcesBase protoSerivcesBase)
        {
            _protoSerivcesBase = protoSerivcesBase ?? throw new ArgumentNullException(nameof(protoSerivcesBase));
        }

        //public async Task<CouponModel> GetDiscount(string productName)
        //{
        //    var discountRequest = new GetDiscountRequest { ProductName = productName };
        //    return await _protoSerivcesBase.GetDiscount(discountRequest);
        //}

    }
}
