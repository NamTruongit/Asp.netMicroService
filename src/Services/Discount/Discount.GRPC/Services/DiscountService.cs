using AutoMapper;
using Discount.GRPC.Entities;
using Discount.GRPC.Protos;
using Discount.GRPC.Repositories;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Discount.GRPC.Services
{
    public class DiscountService : DiscountProtoSerivces.DiscountProtoSerivcesBase
    { 
        private readonly IDiscountRepository _repositorys;
        private readonly ILogger<DiscountService> _logger;
        private readonly IMapper _mapper;

        public DiscountService(IDiscountRepository repositorys, ILogger<DiscountService> logger, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repositorys = repositorys ?? throw new ArgumentNullException(nameof(repositorys));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await _repositorys.GetDiscount(request.ProductName);
            if (coupon == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount with product name {request.ProductName} is not found "));
            }
            _logger.LogInformation("Discount is retrived for prductnName:{productName}, Amount;{amount}", coupon.ProductName, coupon.Amount);
            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }


        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = _mapper.Map<Coupon>(request.Coupon);
            await _repositorys.CreateDiscount(coupon);
            _logger.LogInformation("Discount is successfully created. Product Name:{productName}", coupon.ProductName);

            var couponModel = _mapper.Map<CouponModel>(coupon);
            return couponModel;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var deleted = await _repositorys.DeleteDiscount(request.ProductName);
            var reponse = new DeleteDiscountResponse
            {
                Success = deleted
            };
            return reponse;

        }
    }
}
