using CloudBlog.Core.ResponsiveImages;
using KenticoCloud.Delivery;
using KenticoCloud.Delivery.ImageTransformation;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CloudBlog.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static string[] ResponsiveWidths { get; } = new string[] { "200", "400", "600", "800", "1000", "1200", "1400", "1600", "2000", "4000" };

        public static bool ResponsiveImagesEnabled { get; } = ResponsiveWidths.Any();

        /// <summary>
        /// Generates an IMG tag for an image file.
        /// </summary>
        /// <param name="htmlHelper">HTML helper.</param>
        /// <param name="asset">Asset</param>
        /// <param name="title">Title</param>
        /// <param name="cssClass">CSS class</param>
        /// <param name="width">Optional width size</param>
        /// <param name="height">Optional height size</param>
        /// <param name="sizes">Media conditions mapping screen width to image size</param>
        public static MvcHtmlString AssetImage(this HtmlHelper htmlHelper, Asset asset, string title = null, string cssClass = "", int? width = null, int? height = null, ResponsiveImageSizes sizes = null)
        {
            if (asset == null)
            {
                return MvcHtmlString.Empty;
            }

            var imageUrlBuilder = new ImageUrlBuilder(asset.Url);
            var image = new TagBuilder("img");

            if (width.HasValue)
            {
                image.MergeAttribute("width", width.ToString());
                imageUrlBuilder = imageUrlBuilder.WithWidth(Convert.ToDouble(width));
            }

            if (height.HasValue)
            {
                image.MergeAttribute("height", height.ToString());
                imageUrlBuilder = imageUrlBuilder.WithHeight(Convert.ToDouble(height));
            }

            if (ResponsiveImagesEnabled && !width.HasValue && !height.HasValue)
            {
                image.MergeAttribute("srcset", GenerateSrcsetValue(asset.Url));

                if (sizes != null)
                {
                    image.MergeAttribute("sizes", sizes.GenerateSizesValue());
                }
            }

            image.MergeAttribute("src", $"{imageUrlBuilder.Url}");
            image.AddCssClass(cssClass);
            string titleToUse = title ?? asset.Description ?? string.Empty;
            image.MergeAttribute("alt", titleToUse);
            image.MergeAttribute("title", titleToUse);

            return MvcHtmlString.Create(image.ToString(TagRenderMode.SelfClosing));
        }

        /// <summary>
        /// Generates an IMG tag for an inline image.
        /// </summary>
        /// <param name="htmlHelper">HTML helper.</param>
        /// <param name="image">Inline image.</param>
        /// <param name="sizes">Media conditions mapping screen width to image size</param>
        public static MvcHtmlString InlineImage(this HtmlHelper htmlHelper, IInlineImage image, ResponsiveImageSizes sizes = null)
        {
            if (image == null)
            {
                return MvcHtmlString.Empty;
            }

            var imageTag = new TagBuilder("img");

            if (ResponsiveImagesEnabled)
            {
                imageTag.MergeAttribute("srcset", GenerateSrcsetValue(image.Src));

                if (sizes != null)
                {
                    imageTag.MergeAttribute("sizes", sizes.GenerateSizesValue());
                }
            }

            imageTag.MergeAttribute("src", image.Src);
            imageTag.MergeAttribute("alt", image.AltText);

            return MvcHtmlString.Create(imageTag.ToString(TagRenderMode.SelfClosing));
        }

        private static string GenerateSrcsetValue(string imageUrl)
        {
            var imageUrlBuilder = new ImageUrlBuilder(imageUrl);

            return string.Join(",", ResponsiveWidths.Select(w
                =>$"{imageUrlBuilder.WithWidth(Convert.ToDouble(w)).Url} {w}w"));
        }
    }
}