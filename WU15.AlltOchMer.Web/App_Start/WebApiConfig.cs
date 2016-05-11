using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;

namespace WU15.AlltOchMer.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var jasonFormater = config.Formatters.OfType<JsonMediaTypeFormatter>().First();

            jasonFormater.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/AllProducts/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApiDetailsS",
                routeTemplate: "api/{controller}/ProductDetails/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
        }
    }
}
