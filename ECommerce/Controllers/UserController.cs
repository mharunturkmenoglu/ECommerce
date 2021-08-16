using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ECommerce.Api.Controllers;
using ECommerce.Entities.Concrete;
using ECommmerce.Entities.Dtos;
using ECommmerce.Service.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// TODO: Add Authentication and Authorization
// TODO: Use AutoMapper to map UserDtos to user (make it Service Layer)
// TODO: Change paramaters and returning values on methods in Service Layer.

namespace ECommerce
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly ECommerce.Shared.Authentication.IAuthenticationService _authenticationService;

        public UserController(IUserService userService, ECommerce.Shared.Authentication.IAuthenticationService authenticationService)
        {
            _userService = userService;
            _authenticationService = authenticationService;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.GetByEmailAndPassword(userLoginDto.Email, userLoginDto.Password);
                if (user.UserName != null && user.Password != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim("UserName", user.UserName),
                        new Claim(ClaimTypes.Role, "User"),
                    };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddDays(2),
                        IsPersistent = true,
                        //IssuedUtc = <DateTimeOffset>,
                        // The time at which the authentication ticket was issued.

                        //RedirectUri = <string>
                        // The full path or absolute URI to be used as an http 
                        // redirect response value.
                    };
                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                    _authenticationService.Authenticate(user);
                    return Ok(user);
                }
                else
                {
                    return BadRequest("Wrong Email or Password");
                }
            }
            else
            {
                return BadRequest("Wrong Email or Password");
            }
        }
        [Authorize]
        [HttpPost("adduser")]
        public ActionResult Add(UserAddDto userAddDto)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (ModelState.IsValid)
            {
                _userService.Add(new User
                {
                    Email = userAddDto.Email,
                    Password = userAddDto.Password,
                    UserName = userAddDto.UserName,
                    CreatedByName = "",
                    ModifiedByName = "",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    Description = "",
                    Note = "",
                }, "");
                return Ok("Success.");
            }
            else
            {
                return BadRequest("Wrong Email or Password");
            }
        }
        [Authorize]
        [HttpPost("changeLanguage")]
        public ActionResult SetLanguage(int id)
        {
            _authenticationService.SetLanguage(id);
            return Ok("success");
        }
        [Authorize]
        [HttpGet("logout")]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok("succesfully logged out");
        }
    }
}
