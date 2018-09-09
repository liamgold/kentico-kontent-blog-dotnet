using System;
using System.Configuration;
using System.Web.Mvc;
using CloudBlog.Models;
using KenticoCloud.Delivery;

namespace CloudBlog.Controllers
{
    public class ControllerBase : AsyncController
    {
        protected static readonly DeliveryClient baseClient = CreateDeliveryClient();
        public readonly IDeliveryClient client;

        public ControllerBase()
        {
            client = baseClient;
        }
       
        public static DeliveryClient CreateDeliveryClient()
        {
            // Use the provider to get environment variables.
            var provider = new ConfigurationManagerProvider();

            // Build DeliveryOptions with default or explicit values.
            var options = provider.GetDeliveryOptions();
            Guid.TryParse(ConfigurationManager.AppSettings["ProjectId"], out Guid projectId);
            options.ProjectId = projectId.ToString();

            var clientInstance = new DeliveryClient(options);
            clientInstance.CodeFirstModelProvider.TypeProvider = new CustomTypeProvider();
            clientInstance.ContentLinkUrlResolver = new CustomContentLinkUrlResolver();
            return clientInstance;
        }
    }
}

