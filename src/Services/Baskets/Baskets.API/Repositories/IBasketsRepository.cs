using Baskets.API.Entities;
using System.Threading.Tasks;

namespace Baskets.API.Repositories
{
    public interface IBasketsRepository
    {
        Task<ShoppingCart> GetBasket(string username);
        Task<ShoppingCart> Updatebasket(ShoppingCart cart);
        Task DeleteBasket(string username);
    }
}
