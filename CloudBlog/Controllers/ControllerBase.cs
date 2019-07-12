using System;
using System.Configuration;
using System.Web.Mvc;
using CloudBlog.Infrastructure;
using CloudBlog.Models;
using KenticoCloud.Delivery;

namespace CloudBlog.Controllers
{
    public class ControllerBase : AsyncController
    {
        protected static readonly IDeliveryClient baseClient = CreateDeliveryClient();
        public readonly IDeliveryClient client;

        public ControllerBase()
        {
            client = baseClient;
        }
       
        public static IDeliveryClient CreateDeliveryClient()
        {
            // Use the provider to get environment variables.
            var provider = new ConfigurationManagerProvider();

            // Build DeliveryOptions with default or explicit values.
            var options = provider.GetDeliveryOptions();
            Guid.TryParse(ConfigurationManager.AppSettings["ProjectId"], out Guid projectId);
            options.ProjectId = projectId.ToString();

            var clientInstance = DeliveryClientBuilder.WithOptions(o => options)
                .WithTypeProvider(new CustomTypeProvider())
                .WithContentLinkUrlResolver(new CustomContentLinkUrlResolver()).Build();

            return clientInstance;
        }
    }
}

