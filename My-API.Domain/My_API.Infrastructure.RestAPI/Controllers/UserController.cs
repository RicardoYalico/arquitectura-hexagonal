using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_API.Application.Interfaces.Services;
using My_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_API.Infrastructure.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService<User, int> userService;

        public UserController(IUserService<User, int> _userService)
        {
            userService = _userService;
        }

        // GET: UserController
        [HttpGet]
        public ActionResult<User> Get([FromQuery] int? userType)
        {

            var user = userService.Obtener((int)userType);
            //var resources = _mapper.Map<IEnumerable<Publication>, IEnumerable<PublicationResource>>(publications);
            return user;
        }

    }
}
