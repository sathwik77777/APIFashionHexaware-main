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

namespace FashionHexa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRatingsController : ControllerBase
    {
        private readonly IUserRatingsService userRatingsService;
        private readonly IMapper _mapper;
        private readonly IConfiguration configuration;
        private ILogger<UserRatingsController> logger;

        public UserRatingsController(IUserRatingsService userRatingsService, IMapper mapper, IConfiguration configuration, ILogger<UserRatingsController> logger)
        {
            this.userRatingsService = userRatingsService;
            _mapper = mapper;
            this.configuration = configuration;
            this.logger = logger;
        }
        [HttpPost, Route("SubmitRating")]
        [Authorize(Roles = "Customer")]
        public IActionResult SubmitRating(UserRatingsDTO userRatingsDTO)
        {
            try
            {
                UserRatings userRatings = _mapper.Map<UserRatings>(userRatingsDTO);
                userRatingsService.AddRating(userRatings);
                return StatusCode(200, userRatings);


            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);

            }
        }

        [HttpPut, Route("Update Rating")]
        [Authorize(Roles = "Customer")]
        public IActionResult UpdateUserRating(UserRatingsDTO userRatingsDTO)
        {
            try
            {
                UserRatings userRatings = _mapper.Map<UserRatings>(userRatingsDTO);
                userRatingsService.UpdateRating(userRatings);
                return StatusCode(200, userRatings);


            }

            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }



        }

        [HttpDelete, Route("Delete Ratings")]
        [Authorize(Roles ="Customer")]
        public IActionResult DeleteUserRating(int userRatingsId)
        {
            try
            {
                userRatingsService.DeleteRating(userRatingsId);
                return StatusCode(200, new JsonResult($"Rating with Id {userRatingsId} is Deleted"));

            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet,Route("GetByUser")]
        [Authorize(Roles ="Customer")]
        public IActionResult GetUserRatings(int userId) 
        {
            try
            {
                List<UserRatings> userRatings = userRatingsService.GetUserRatings(userId);

               
                return StatusCode(200,userRatings);
                

            }

            catch(Exception ex) 
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);

            }
        }
    }
}









