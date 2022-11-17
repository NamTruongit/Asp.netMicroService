using AutoMapper;
using Baskets.API.Entities;
using Baskets.API.GrpcSerives;
using Baskets.API.Repositories;
using EventBus.Message.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Baskets.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class BasketsController : ControllerBase
    {

        private readonly IBasketsRepository _repositories;
        private readonly DiscountGrpcServices _discountGrpc;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;
        public BasketsController(IBasketsRepository repositories,
            DiscountGrpcServices discountGrpc,IMapper mapper,
            IPublishEndpoint publishEndpoint)
        {
            _repositories = repositories ?? throw new ArgumentNullException(nameof(repositories));
            _discountGrpc = discountGrpc ?? throw new ArgumentNullException(nameof(discountGrpc));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
        }

        [HttpGet("{userName}", Name = "Basket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
        {
            var basket = await _repositories.GetBasket(userName);
            return Ok(basket ?? new ShoppingCart(userName));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart basket)
        {
            foreach (var item in basket.Items)
            {
                var coupon = await _discountGrpc.GetDiscount(item.ProductName);
                item.Price -= coupon.Amount;
            }
            return Ok(await _repositories.Updatebasket(basket));
        }

        [HttpDelete("{userName}", Name = "DeleteBasket")]
        [ProducesResponseType(typeof(ShoppingCart), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _repositories.DeleteBasket(userName);

            return Ok();
        }
        [Route("[action]")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
        {
            // get existing basket with total price 
            // Create basketCheckoutEvent -- Set TotalPrice on basketCheckout eventMessage
            // send checkout event to rabbitmq
            // remove the basket

            // get existing basket with total price
            var basket = await _repositories.GetBasket(basketCheckout.UserName);
            if (basket == null)
            {
                return BadRequest();
            }

            // send checkout event to rabbitmq
            var eventMessage = _mapper.Map<BasketCheckoutEvent>(basketCheckout);
            eventMessage.TotalPrice = basket.TotalPrice;
            await _publishEndpoint.Publish(eventMessage);

            // remove the basket
            await _repositories.DeleteBasket(basket.UserName);

            return Accepted();
        }
    }
}
