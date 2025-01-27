﻿using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace al.Auth
{
    public class RoleRestaurant : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var token = actionContext.Request.Headers.Authorization;
            var isUser = LogService.checkUser(token.ToString(), "Restaurant");
            if (!isUser)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, new { Msg = "You Are not a Restaurant" });
            }
            base.OnAuthorization(actionContext);
        }

    }
}