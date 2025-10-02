using ByWay.Application.Abstraction.DTOs.Cart;
using System.Security.Claims;

namespace ByWay.Application.Abstraction.Repositories.Cart
{
    public interface ICartService
    {
        Task<CartResponse> GetCartAsync(ClaimsPrincipal claimsPrincipal);
        Task<CartResponse> AddCartItemAsync(ClaimsPrincipal user,CreateCartItemRequest model);
        Task<UpdateCartItemRequest> UpdateCartItemAsync(UpdateCartItemRequest model);
        Task ClearCartAsync(ClaimsPrincipal user);
        Task ApplyDiscountAsync(ClaimsPrincipal user, decimal discount);
    }
}
