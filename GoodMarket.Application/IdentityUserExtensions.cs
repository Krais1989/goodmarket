﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace GoodMarket.Application
{
    public static class IdentityUserExtensions
    {
        //public static string GetUserId(this ClaimsPrincipal principal)
        //{
        //    return principal.Claims.FirstOrDefault(e => e.Type == ClaimTypes.Id).Value;
        //}

        public static string GetEmail(this ClaimsPrincipal principal)
        {
            return principal.Claims.FirstOrDefault(e => e.Type == ClaimTypes.Email).Value;
        }

        public static string GetName(this ClaimsPrincipal principal)
        {
            return principal.Claims.FirstOrDefault(e => e.Type == ClaimTypes.Name).Value;
        }
    }
}