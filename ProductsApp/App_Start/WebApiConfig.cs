﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using HistoryApp.Controllers;

namespace HistoryApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors(); // requires Install-Package Microsoft.AspNet.WebApi.Cors -pre -project WebService

            // Web API routes
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "APIEvents",
                routeTemplate: "api/{zoom}/{lat}/{lon}",
                defaults: new
                {
                    controller = "Events",
                    category = RouteParameter.Optional,
                    startdate = RouteParameter.Optional,
                    enddate = RouteParameter.Optional,
                    searchterm = RouteParameter.Optional
                }
            );
            config.Routes.MapHttpRoute(
                name: "AllEvents",
                routeTemplate: "api/{controller}"
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
