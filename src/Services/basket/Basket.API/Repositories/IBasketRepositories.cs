using Basket.API.Entities;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public interface IBasketRepositories
    {
        Task<ShoppingCart> GetBasket(string username);
        Task<ShoppingCart> Updatebasket(ShoppingCart cart);
        Task DeleteBasket(string username);
    }
}
