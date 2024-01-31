using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FashionHexa.DTO;
using FashionHexa.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using log4net;

namespace FashionHexa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private UnitOfWork unitOfWork;
        private ILog _logger;

        public CartController(UnitOfWork uw, ILog logger)
        {
            unitOfWork = uw;
            _logger = logger;
        }

        [HttpGet,Route("GetAllItemsInCart")]
        [Authorize(Roles ="Customer")]
        public IActionResult GetAllItemsInCart()
        {
            var cartItems = unitOfWork.CartImplObject.GetAll();
            return Ok(cartItems);
        }

        [HttpPost, Route("AddToCart")]
        [Authorize]
        public IActionResult AddToCart(CartDTO cartItem)
        {
            try
            {
                bool status = unitOfWork.CartImplObject.Add(cartItem);

                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok(cartItem);
                }
                else
                {
                    return BadRequest("Error in adding item to cart");

                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut, Route("UpdateCartItem/{id}")]
        [Authorize(Roles="Customer")]
        public IActionResult UpdateCartItem(int id, CartDTO updatedCartItem)
        {
            updatedCartItem.CartId = id;

            try
            {
                bool status = unitOfWork.CartImplObject.Update(updatedCartItem);

                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok(updatedCartItem);
                }
                else
                {
                    return BadRequest($"Item with ID {id} not found or update failed");
                }
            }
            catch (Exception ex)
            {

                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);

                //throw;
            }
        }

        [HttpDelete, Route("RemoveFromCart/{id}")]
        [Authorize(Roles ="Customer")]
        public IActionResult RemoveFromCart(int id)
        {
            try
            {
                bool status = unitOfWork.CartImplObject.Delete(id);

                if (status)
                {
                    unitOfWork.SaveAll();
                    return Ok($"Item with ID {id} removed from cart");
                }
                else
                {
                    return BadRequest($"Item with ID {id} not found or removal failed");
                }
            }
            catch (Exception ex)
            {

                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
                //throw;
            }
        }

        [HttpGet,Route("GetByCartId/{id}")]
        [Authorize(Roles = "Seller")]
        public IActionResult GetByCartId(int id)
        {
            try
            {
                var cartItem = unitOfWork.CartImplObject.GetByCartId(id);
                if (cartItem == null)
                    return NotFound($"Item with ID {id} not found");
                return Ok(cartItem);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet,Route("GetAllCartsByUser/{userId}")]
        [Authorize(Roles = "Customer")]
        public IActionResult GetAllCartsByUser(int userId) 
        {
            try
            {
                var cartItems = unitOfWork.CartImplObject.GetAllCartsByUser(userId);

                if (cartItems == null || cartItems.Count == 0)
                    return NotFound($"No items found for user with ID {userId}");
                return Ok(cartItems);
            }
            catch (Exception ex)
            {
                    _logger.Error(ex.Message);
                    return StatusCode(500, ex.Message);
            }
        }




    }


}


    

