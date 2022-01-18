using Basket.API.Entities;

namespace Basket.API.Repositories
{
    public interface IBasketReposiroty
    {
        Task<ShoppingCart> GetBasket(string userName);
        Task<ShoppingCart> UpdateBasket(ShoppingCart basket);
        Task DeleteBasket(string userName);
    }
}
