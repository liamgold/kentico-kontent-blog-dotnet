// This code was generated by a cloud-generators-net tool 
// (see https://github.com/Kentico/cloud-generators-net).
// 
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated. 
// For further modifications of the class, create a separate file with the partial class.

using System;
using System.Collections.Generic;
using Kentico.Kontent.Delivery;

namespace CloudBlog.Models
{
    public partial class BlogPost
    {
        public const string Codename = "blog_post";
        public const string UrlPatternCodename = "url_pattern";
        public const string MetadataOgDescriptionCodename = "metadata__og_description";
        public const string MetadataMetaTitleCodename = "metadata__meta_title";
        public const string SummaryCodename = "summary";
        public const string MetadataOgTitleCodename = "metadata__og_title";
        public const string MetadataMetaDescriptionCodename = "metadata__meta_description";
        public const string TeaserImageCodename = "teaser_image";
        public const string MetadataTwitterSiteCodename = "metadata__twitter_site";
        public const string PostDateCodename = "post_date";
        public const string MetadataTwitterImageCodename = "metadata__twitter_image";
        public const string MetadataTwitterCreatorCodename = "metadata__twitter_creator";
        public const string BlogTagCodename = "blog_tag";
        public const string TitleCodename = "title";
        public const string MetadataTwitterTitleCodename = "metadata__twitter_title";
        public const string MetadataTwitterDescriptionCodename = "metadata__twitter_description";
        public const string BodyCopyCodename = "body_copy";
        public const string MetadataOgImageCodename = "metadata__og_image";

        public string UrlPattern { get; set; }
        public string MetadataOgDescription { get; set; }
        public string MetadataMetaTitle { get; set; }
        public string Summary { get; set; }
        public string MetadataOgTitle { get; set; }
        public string MetadataMetaDescription { get; set; }
        public IEnumerable<Asset> TeaserImage { get; set; }
        public string MetadataTwitterSite { get; set; }
        public DateTime? PostDate { get; set; }
        public IEnumerable<Asset> MetadataTwitterImage { get; set; }
        public string MetadataTwitterCreator { get; set; }
        public IEnumerable<TaxonomyTerm> BlogTag { get; set; }
        public string Title { get; set; }
        public string MetadataTwitterTitle { get; set; }
        public string MetadataTwitterDescription { get; set; }
        public string BodyCopy { get; set; }
        public IEnumerable<Asset> MetadataOgImage { get; set; }
        public ContentItemSystemAttributes System { get; set; }
    }
}