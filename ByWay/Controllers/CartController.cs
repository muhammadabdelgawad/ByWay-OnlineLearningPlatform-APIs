using AutoMapper;
using ByWay.Application.Abstraction.Repositories.Cart;
using ByWay.Application.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ByWay.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController(IMapper mapper, IUnitOfWork unitOfWork, ICartService cartService) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            var cart = await cartService.GetCartAsync(User);
            return Ok(cart);
        }

        [HttpPost("addItem")]
        public async Task<IActionResult> AddCartItem([FromBody] ByWay.Application.Abstraction.DTOs.Cart.CreateCartItemRequest model)
        {
            var cart = await cartService.AddCartItemAsync(User, model);
            return Ok(cart);
        }

        

        [HttpPost("applyDiscount")]
        public async Task<IActionResult> ApplyDiscount([FromQuery] decimal discount)
        {
            await cartService.ApplyDiscountAsync(User, discount);
            return Ok("Discount applied successfully.");
        }

        [HttpDelete("clear")]
        public async Task<IActionResult> ClearCart()
        {
            await cartService.ClearCartAsync(User);
            return Ok("Cart cleared successfully.");
        }
    }
}
