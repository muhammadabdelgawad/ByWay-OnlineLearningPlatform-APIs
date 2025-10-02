using ByWay.Domain.Entities.Cart;

namespace ByWay.Application.Services.Cart
{
    public class CartService : ICartService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CartService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<CartResponse> GetCartAsync(ClaimsPrincipal claimsPrincipal)
        {

            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                throw new Exception("User is not authenticated.");

            var carts = await _unitOfWork.Carts.GetAllAsync();
            var userCart = carts.FirstOrDefault(c => c.UserId == userId);

            if (userCart == null)
            {
                
                return new CartResponse
                {
                    UserId = userId,
                    CreatedAt = DateTime.UtcNow,
                    Items = new List<CartItemResponse>(),
                    SubTotal = 0,
                    Discount = 0,
                    Total = 0
                };
            }
            return _mapper.Map<CartResponse>(userCart);


        }

        public async Task<CartResponse> AddCartItemAsync(ClaimsPrincipal user, CreateCartItemRequest model)
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("User is not authenticated.");

            if (model == null)
                throw new ArgumentNullException(nameof(model));

            if (model.CourseId <= 0)
                throw new Exception("Valid Course ID is required.");

            var course = await _unitOfWork.Courses.GetByIdAsync(model.CourseId);
            if (course == null)
                throw new InvalidOperationException($"Course with ID {model.CourseId} not found.");

            var carts = await _unitOfWork.Carts.GetAllAsync();
            var cart = carts.FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Carts
                {
                    UserId = userId,
                    CreatedAt = DateTime.UtcNow,
                    Discount = 0,
                    Items = new List<CartItem>()
                };
                await _unitOfWork.Carts.AddAsync(cart);
                await _unitOfWork.CompleteAsync();
            }

           
            var cartItems = await _unitOfWork.CartItems.GetAllAsync();
            var existingItem = cartItems.FirstOrDefault(ci => ci.CourseId == model.CourseId);

            if (existingItem != null)
            {
                existingItem.Quantity += model.Quantity;
                _unitOfWork.CartItems.Update(existingItem);
            }
            else
            {
                var newCartItem = new CartItem
                {
                    CourseId = model.CourseId,  
                    CourseName = course.CourseName,
                    PictureUrl = course.PictureUrl,
                    Price = course.Price,
                    Quantity = model.Quantity
                };

                await _unitOfWork.CartItems.AddAsync(newCartItem);
            }

            await _unitOfWork.CompleteAsync();
            return await GetCartAsync(user);
        }
      
        public async Task<UpdateCartItemRequest> UpdateCartItemAsync(ClaimsPrincipal user,int ItemId,UpdateCartItemRequest model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var cartItems = await _unitOfWork.CartItems.GetAllAsync();
            var cartItem = cartItems.FirstOrDefault(ci => ci.Course?.Id == model.CourseId);

            if (cartItem == null)
                throw new InvalidOperationException("Cart item not found.");

            cartItem.Quantity = model.Quantity;
            _unitOfWork.CartItems.Update(cartItem);
            await _unitOfWork.CompleteAsync();

            return model;
        }

        public async Task ClearCartAsync(ClaimsPrincipal user)
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("User is not authenticated.");
             
            var carts = await _unitOfWork.Carts.GetAllAsync();
            var cart = carts.FirstOrDefault(c => c.UserId == userId);

            if (cart != null)
            {
                var cartItems = await _unitOfWork.CartItems.GetAllAsync();
                var userCartItems = cartItems.Where(ci => cart.Items.Contains(ci));

                foreach (var item in userCartItems)
                {
                    _unitOfWork.CartItems.Delete(item);
                }

                await _unitOfWork.CompleteAsync();
            }
        }

       

        public async Task ApplyDiscountAsync(ClaimsPrincipal user, decimal discount)
        {
            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("User is not authenticated.");

            var carts = await _unitOfWork.Carts.GetAllAsync();
            var cart = carts.FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
                throw new InvalidOperationException("Cart not found.");

            cart.Discount = discount;
            _unitOfWork.Carts.Update(cart);
            await _unitOfWork.CompleteAsync();
        }
    }
}
