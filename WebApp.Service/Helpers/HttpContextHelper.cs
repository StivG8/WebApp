﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Service.Helpers
{
    public class HttpContextHelper
    {
        public static IHttpContextAccessor Accessor { get; set; }
        public static HttpContext HttpContext => Accessor?.HttpContext;
        public static IHeaderDictionary ResponseHeaders => HttpContext?.Response?.Headers;
        public static int? UserId => GetUserId();
        public static string IpAddress => Accessor?.HttpContext.Connection.RemoteIpAddress.ToString();
        public static string UserRole => HttpContext?.User.FindFirst("Role")?.Value;

        private static int? GetUserId()
        {
            string value = HttpContext?.User?.Claims.FirstOrDefault(p => p.Type == "Id")?.Value;

            bool canParse = int.TryParse(value, out int id);
            return canParse ? id : null;
        }
    }
}
