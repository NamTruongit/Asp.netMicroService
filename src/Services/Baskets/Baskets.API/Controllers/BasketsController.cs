using Baskets.API.Entities;
using Baskets.API.GrpcSerives;
using Baskets.API.Repositories;
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
        public BasketsController(IBasketsRepository repositories,DiscountGrpcServices discountGrpc)
        {
            _repositories = repositories ?? throw new ArgumentNullException(nameof(repositories));
            _discountGrpc = discountGrpc ?? throw new ArgumentNullException(nameof(discountGrpc));
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
    }
}
