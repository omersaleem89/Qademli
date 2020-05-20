
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using System;
using System.Security.Claims;

namespace Qademli.Utility
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private string[] allowedroles { get; set; }
        private readonly IConfiguration _config;
        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.allowedroles = roles;
            _config = Startup.Config;
        }

        

        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            bool isValid = false;
            var token = filterContext.HttpContext.Session.GetString("token");
            if (!string.IsNullOrEmpty(token))
            {
                string role = new JWTHandler(_config).ValidateToken(token).FindFirstValue(ClaimTypes.Role);
                foreach (var r in allowedroles)
                {
                    if (r == role)
                        isValid = true;
                }
            }
            if (!isValid)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { area="Account", controller = "Login", action = "Unauthorize" }));
            }
        }
    }
}
