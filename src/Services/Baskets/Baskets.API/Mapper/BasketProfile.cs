using AutoMapper;
using Baskets.API.Entities;
using EventBus.Message.Events;

namespace Baskets.API.Mapper
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<BasketCheckout,BasketCheckoutEvent>().ReverseMap();
        }
    }
}
