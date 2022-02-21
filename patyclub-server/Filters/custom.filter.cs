using System;  
using System.Collections.Generic;
using System.Security.Claims;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CustomFilter  
{  
    public class AuthData {
        public string[] authList { get; set; }
        public AuthData(string[] claimValue) {
            authList = claimValue;
        }
    }
    public class JwtAuthAttribute : TypeFilterAttribute
    {
        public JwtAuthAttribute(string[] claimValue) : base(typeof(JwtAuthFilter))
        {
            Arguments = new object[] {new AuthData(claimValue) };
        }
    }

    public class JwtAuthFilter : IAuthorizationFilter
    {
        readonly AuthData _claim;

        public JwtAuthFilter(AuthData claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            // var hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == _claim.Type && c.Value == _claim.Value);
            // if (!hasClaim)
            // {
            //     context.Result = new ForbidResult();
            // }
            if (_claim.authList[0] == "HomeLogin") {
                context.Result = new JsonResult(new
                {
                    Message = "Token Validation Has Failed. Request Access Denied"
                })
                {
                    StatusCode = 401
                };
            }
        }
    }
}  