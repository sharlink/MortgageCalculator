using Afi.Dp.Retail.Logility.Api;
using MortgageCalculator.Api.Filters;
using MortgageCalculator.Api.Helper;
using MortgageCalculator.Api.Repos;
using MortgageCalculator.Api.Services;
using MortgageCalculator.Dto;
using Newtonsoft.Json.Serialization;
using System;
using System.Configuration;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;
using Unity.Lifetime;

namespace MortgageCalculator.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType<IMortgageService, MortgageRepo>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);


            //CORS Enable           

            var cors = new EnableCorsAttribute(ConfigurationManager.AppSettings["MortgageCalculator.Web"].ToString(), "*", "GET, POST, PUT, DELETE, OPTIONS");
            config.EnableCors(cors);

            //Custom Error

            config.Filters.Add(new CustomExceptionFilter());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Auto Mapper

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<MortgageData.Mortgage, Dto.Mortgage>()
                    .ForMember(dest => dest.TermsInMonths, opt => opt.MapFrom(src =>
                     src.EffectiveStartDate.GetTotalMonthsFrom(src.EffectiveEndDate)))
                     .ForMember(dest => dest.MortgageType, opt => opt.MapFrom(src =>
                      (MortgageType)Enum.Parse(typeof(MortgageType), src.MortgageType.ToString())));
            });

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            config.Formatters.XmlFormatter.MediaTypeMappings.Add(new QueryStringMapping("acceptFormat", "xml", new MediaTypeHeaderValue("application/xml")));
            config.Formatters.JsonFormatter.MediaTypeMappings.Add(new QueryStringMapping("acceptFormat", "json", new MediaTypeHeaderValue("application/json")));
        }
    }
}
