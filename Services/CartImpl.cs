using FashionHexa.Entities;
using FashionHexa.Services;
using FashionHexa.DTO;
using System.Collections.Generic;
using System.Linq;
using FashionHexa.Database;

namespace FashionHexa.Services
{
    public class CartImpl:IRepo<CartDTO>
    {
        private readonly MyContext _context;
        public CartImpl(MyContext context)
        {
            _context = context;
        }

        public List<CartDTO> GetAll()
        {
            var result = _context.carts
                .Select(c=> new CartDTO()
                {
                    CartId = c.CartId,
                    UserId = c.UserId,
                    ProductId = c.ProductId,
                    Quantity = c.Quantity,
                    //image= c.image
                })
                .ToList();
            return result;
        }

        public bool Add(CartDTO item)
        {
            Cart cartNew = new Cart();
            cartNew.UserId = item.UserId;
            cartNew.ProductId = item.ProductId;
            cartNew.Quantity= item.Quantity;
            //cartNew.image = item.image;
            _context.carts.Add(cartNew);
            return true;
        }

        public bool Delete(int id)
        {
            var cartDelete = _context.carts.Find(id);
            if (cartDelete == null)
                return false;
            _context.carts.Remove(cartDelete);
            return true;
            
        }

        public bool Update(CartDTO item)
        {
            var cartUpdate = _context.carts.Find(item.CartId);
            if(cartUpdate == null)
                return false;
            cartUpdate.UserId = item.UserId;
            cartUpdate.ProductId = item.ProductId;
            cartUpdate.Quantity = item.Quantity;
            //cartUpdate.image = item.image;
            return true;
        }

        public CartDTO GetByCartId(int cartId)
        {
            var cart=_context.carts.FirstOrDefault(c=>c.CartId == cartId);

            if (cart == null)
                return null;

            var cartDTO = new CartDTO()
            {
                CartId = cart.CartId,
                UserId = cart.UserId,
                ProductId = cart.ProductId,
                Quantity = cart.Quantity,
                //image= cart.image
            };
            return cartDTO;
        }

        public List<ProductCartDTO> GetAllCartsByUser(int userId)
        {
            var result =
            (
                from p in _context.Products
                join 
                c in _context.carts
                on
                p.ProductId equals c.ProductId
                where c.UserId == userId
                select new ProductCartDTO()
                {
                    CartId = c.CartId,
                    ProductId=p.ProductId,
                    Name=p.Name,
                    Price=p.Price,
                    Quantity=c.Quantity,
                    image=p.image,
                }
            ).ToList();
            return result;
        }
    }
}
