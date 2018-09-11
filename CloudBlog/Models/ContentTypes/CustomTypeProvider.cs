using System;
using KenticoCloud.Delivery;

namespace CloudBlog.Models
{
    public class CustomTypeProvider : ICodeFirstTypeProvider
    {
        public Type GetType(string contentType)
        {
            switch (contentType)
            {
                case "article":
                    return typeof(Article);
                case "blog_post":
                    return typeof(BlogPost);
                case "home":
                    return typeof(Home);
                default:
                    return null;
            }
        }
    }
}