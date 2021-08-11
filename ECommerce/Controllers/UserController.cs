using System;
using System.Collections.Generic;
using System.Linq;
using ECommerce.Entities.Concrete;
using ECommmerce.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ECommerce
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<User> Index()
        {
            var users = _userService.GetByEmailAndPassword("admin@gmail.com", "admin");
            return users;
        }
    }
}
