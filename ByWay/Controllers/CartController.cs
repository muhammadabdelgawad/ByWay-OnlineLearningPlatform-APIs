using AutoMapper;
using ByWay.Application.Abstraction.DTOs.Cart;
using ByWay.Application.Abstraction.Repositories.Cart;
using ByWay.Application.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ByWay.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController(IMapper mapper, IUnitOfWork unitOfWork, ICartService cartService) : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            var cart = await cartService.GetCartAsync(User);
            return Ok(cart);
        }


        [Authorize]
        [HttpPost("addItem")]
        public async Task<IActionResult> AddCartItem([FromBody] CreateCartItemRequest model)
        {
            var cart = await cartService.AddCartItemAsync(User, model);
            return Ok(cart);
        }

        [HttpPut("updateItem/{itemId}")]
        public async Task<IActionResult> UpdateCartItem(int itemId, [FromBody] UpdateCartItemRequest model)
        {
            var cart = await cartService.UpdateCartItemAsync(User, itemId, model);
            return Ok(cart);
        }

        [Authorize]
        [HttpPost("applyDiscount")]
        public async Task<IActionResult> ApplyDiscount([FromQuery] decimal discount)
        {
            await cartService.ApplyDiscountAsync(User, discount);
            return Ok("Discount applied successfully.");
        }

        [Authorize]
        [HttpDelete("clear")]
        public async Task<IActionResult> ClearCart()
        {
            await cartService.ClearCartAsync(User);
            return Ok("Cart cleared successfully.");
        }
    }
}
