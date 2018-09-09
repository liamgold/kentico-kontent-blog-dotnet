using KenticoCloud.Delivery;
using System.Globalization;

namespace CloudBlog
{
    public class CustomContentLinkUrlResolver : IContentLinkUrlResolver
    {
        protected string CurrentCulture => CultureInfo.CurrentUICulture.Name;

        public string ResolveLinkUrl(ContentLink link)
        {
            switch (link.ContentTypeCodename)
            {
                case "article":
                    return $"/{CurrentCulture}/articles/{link.UrlSlug}";
                case "home":
                    return $"/{CurrentCulture}/";
                default:
                    return $"/not_found";
            }
        }

        public string ResolveBrokenLinkUrl()
        {
            return $"/broken_link";
        }
    }
}