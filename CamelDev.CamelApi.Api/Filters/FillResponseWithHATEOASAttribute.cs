﻿using CamelDev.CamelApi.Api.HATEOAS;
using CamelDev.CamelApi.Api.HATEOAS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace CamelDev.CamelApi.Api.Filters
{
    public class FillResponseWithHATEOASAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {

            // application/hal+json
            if (actionExecutedContext.Response.IsSuccessStatusCode &&
                actionExecutedContext.Request.Headers.SelectMany(s => s.Value).Any(a => a.Contains("hal")))
            {
                ObjectContent responseContent = actionExecutedContext.Response.Content as ObjectContent;
                object responseValue = responseContent.Value;

                RestResourceBuilder.BuildResource(responseValue,actionExecutedContext.Request);
            }
        }
    }
}