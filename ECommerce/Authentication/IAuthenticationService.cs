using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ECommerce.Api.Authentication
{
    public interface IAuthenticationService
    {
        string Authenticate(string username);
    }
}