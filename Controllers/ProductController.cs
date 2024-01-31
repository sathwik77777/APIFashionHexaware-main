using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FashionHexa.Entities;
using FashionHexa.Services;
using FashionHexa.Models;
using FashionHexa.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using log4net;
using Microsoft.Extensions.Logging;
using System.Runtime.ConstrainedExecution;
using Microsoft.Data.SqlClient;

namespace FashionHexa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper _mapper;
        private readonly IConfiguration configuration;
        private ILogger<ProductController> logger;
        public ProductController(IProductService productService, IMapper mapper, IConfiguration configuration, ILogger<ProductController> logger)
        {
            this.productService = productService;
            _mapper = mapper;
            this.configuration = configuration;
            this.logger = logger;
        }

        [HttpGet, Route("GetAllProducts")]
        [Authorize]
        public IActionResult GetAllProducts()
        {
            try
            {
                List<Product> products = productService.GetProducts();
                List<ProductDTO> productsDTO = _mapper.Map<List<ProductDTO>>(products); 
                return StatusCode(200, productsDTO); 
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet, Route("GetProductById/{productId}")]
        [Authorize] //all authenticated users can access this
        public IActionResult GetProductById(int productId)
        {
            try
            {
                Product product = productService.GetProductById(productId);
                ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
                if (product != null)
                    return StatusCode(200, product);
                else
                    return StatusCode(404, new JsonResult("Invalid Id")); 
                
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        
        [HttpPost, Route("AddProduct")]
        [Authorize]
        public IActionResult Add(ProductDTO productDTO)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDTO); 
                productService.AddProduct(product);
                return StatusCode(200, product); 
                
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut, Route("EditProduct")]
        [Authorize(Roles = "Seller")]
        public IActionResult Edit(ProductDTO productDTO)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDTO); 
                productService.UpdateProduct(product);
                return StatusCode(200, product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete, Route("DeleteProduct/{productId}")]
         [Authorize(Roles = "Seller")]
        public IActionResult Delete(int productId)
        {
            try
            {
                productService.DeleteProduct(productId);
                return StatusCode(200, new JsonResult($"Product with Id {productId} is Deleted"));
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500,ex.Message);
            }
        }

       /* [HttpGet, Route("GetProductByPrice/{Price}")]
        [Authorize]
        public IActionResult GetProductByPrice(double price) 
        {
            try
            {
                List<Product> product = productService.GetProductsByPrice(price);
                if (product != null)
                    return StatusCode(200, product);
                else
                    return StatusCode(404, new JsonResult("Invalid Price Range"));
            }
            catch(Exception ex)
            {

                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
            
        }*/

        [HttpGet, Route("SortingProducts")]
        [Authorize]
        public IActionResult GetProductbySort(string SortOrder="asc")
        {
            try
            {
                List<Product> products = productService.GetProducts();
                List<ProductDTO> productsDTO = _mapper.Map<List<ProductDTO>>(products);
                if (SortOrder.ToLower() == "asc")
                {
                    productsDTO = productsDTO.OrderBy(p => p.Price).ToList();
                }
                else if (SortOrder.ToLower() == "desc")
                {
                    productsDTO = productsDTO.OrderByDescending(p => p.Price).ToList();
                }
                else
                {
                    return BadRequest("Invalid sortOrder parameter. Use 'asc' or 'desc'.");
                }
                return Ok(productsDTO);

            }
            catch(Exception ex) 
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            
            }
            

            

        }
        [HttpGet,Route("Searchbyname")]
        [Authorize]
        public IActionResult SearchProduct(string productName)
        {
            try
            {
               List <Product> product = productService.GetProductByName(productName);
               List<ProductDTO> productDTO = _mapper.Map<List<ProductDTO>>(product);
                if (product != null)
                    return StatusCode(200, product);
                else
                    return StatusCode(404, new JsonResult("Invalid Id"));

            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /*[HttpGet,Route("productBySeller")]
        //[Authorize]
        public IActionResult ProductBySeller(int userId)
        {
            try
            {
                List<Product> product = productService.GetproductBySeller(userId);
                List<ProductDTO> productDTO = _mapper.Map<List<ProductDTO>>(product);
                if (product != null)
                    return StatusCode(200, product);
                else
                    return StatusCode(404, new JsonResult("Invalid Id"));

            }

            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }*/



    

    }
}
