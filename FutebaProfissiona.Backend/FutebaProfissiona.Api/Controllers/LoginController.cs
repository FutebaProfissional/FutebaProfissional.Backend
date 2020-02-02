using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FutebaProfissional.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FutebaProfissional.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public object Post(
            [FromBody]User usuario,
            [FromServices]AccessManager accessManager)
        {
            if (accessManager.ValidateCredentials(usuario))
            {
                return accessManager.GenerateToken(usuario);
            }
            else
            {
                return new
                {
                    Authenticated = false,
                    Message = "Authentication Failed."
                };
            }
        }
    }
}