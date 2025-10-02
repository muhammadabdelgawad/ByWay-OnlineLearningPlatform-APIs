using AutoMapper;
using ByWay.Application.Abstraction.DTOs.Cart;
using ByWay.Application.Abstraction.Repositories.Cart;
using ByWay.Application.Contracts;
using ByWay.Domain.Entities.Cart;
using ByWay.Infrastructure.Data;
using System;
using System.Security.Claims;

namespace ByWay.Application.Services.Cart
{
    public class CartService : ICartService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _context;

        public CartService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            
        }
        public Task<CartResponse> GetCartAsync(ClaimsPrincipal claimsPrincipal)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateCartItemRequest> AddCartItemAsync(ClaimsPrincipal user,CreateCartItemRequest model)
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart= await 
            var cartItem = mapper.Map<CartItem>(model);
        }

        public Task<UpdateCartItemRequest> UpdateCartItemAsync(UpdateCartItemRequest model)
        {
            throw new NotImplementedException();
        }

        public Task ClearCartAsync(ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

       

        public Task ApplyDiscountAsync(ClaimsPrincipal user, decimal discount)
        {
            throw new NotImplementedException();
        }
    }
}
