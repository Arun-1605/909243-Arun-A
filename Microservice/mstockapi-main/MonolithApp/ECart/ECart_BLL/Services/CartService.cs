using ECart_DAL;
using System.Collections.Generic;

namespace ECart_BLL
{
    public class CartService
    {
        private readonly CartRepository cartRepository;
        public CartService()
        {
            cartRepository = new CartRepository();
        }

        public bool Add(CartItemDto dto)
        {
            if (!cartRepository.Exists(dto.UserId, dto.ProductId))
            {
                var Cart = new Cart { UserId = dto.UserId, ProductId = dto.ProductId, Quantity = dto.Quantity, Price = dto.ProductPrice };
                return cartRepository.Add(Cart) == 1;
            }
            var Item = cartRepository.GetCartItem(dto.UserId, dto.ProductId);
            Item.Price = dto.ProductPrice;
            Item.Quantity += dto.Quantity;
            return cartRepository.Update(Item) == 1;
        }
        public bool ClearCart(int userId)
        {
            return cartRepository.ClearCart(userId) > 0;
        }
        public bool Remove(int cartItemId)
        {
            return cartRepository.Remove(cartItemId) == 1;
        }
        public IEnumerable<CartItemDto> GetCart(int userId)
        {
            var CartItems = cartRepository.GetCart(userId);
            var Dtos = new List<CartItemDto>();
            foreach (var item in CartItems)
                Dtos.Add(new CartItemDto
                {
                    ID = item.ID,
                    ProductId = item.ProductId,
                    UserId = item.UserId,
                    Quantity = item.Quantity,
                    ProductPrice = item.Price,
                    ProductName = item.Product.ProductName
                });
            return Dtos;
        }
    }
}
