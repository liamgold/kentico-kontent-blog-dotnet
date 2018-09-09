// This code was generated by a cloud-generators-net tool 
// (see https://github.com/Kentico/cloud-generators-net).
// 
// Changes to this file may cause incorrect behavior and will be lost if the code is regenerated. 
// For further modifications of the class, create a separate file with the partial class.

using System;
using System.Collections.Generic;
using KenticoCloud.Delivery;

namespace CloudBlog.Models
{
    public partial class Article
    {
        public const string Codename = "article";
        public const string MetadataOgDescriptionCodename = "metadata__og_description";
        public const string MetadataMetaTitleCodename = "metadata__meta_title";
        public const string PersonasCodename = "personas";
        public const string BodyCopyCodename = "body_copy";
        public const string MetadataOgTitleCodename = "metadata__og_title";
        public const string MetadataMetaDescriptionCodename = "metadata__meta_description";
        public const string MetadataTwitterSiteCodename = "metadata__twitter_site";
        public const string PostDateCodename = "post_date";
        public const string MetaKeywordsCodename = "meta_keywords";
        public const string TeaserImageCodename = "teaser_image";
        public const string MetadataTwitterImageCodename = "metadata__twitter_image";
        public const string MetadataTwitterCreatorCodename = "metadata__twitter_creator";
        public const string TitleCodename = "title";
        public const string SummaryCodename = "summary";
        public const string MetadataTwitterTitleCodename = "metadata__twitter_title";
        public const string MetadataTwitterDescriptionCodename = "metadata__twitter_description";
        public const string MetaDescriptionCodename = "meta_description";
        public const string MetadataOgImageCodename = "metadata__og_image";
        public const string RelatedArticlesCodename = "related_articles";
        public const string UrlPatternCodename = "url_pattern";

        public string MetadataOgDescription { get; set; }
        public string MetadataMetaTitle { get; set; }
        public IEnumerable<TaxonomyTerm> Personas { get; set; }
        public string BodyCopy { get; set; }
        public string MetadataOgTitle { get; set; }
        public string MetadataMetaDescription { get; set; }
        public string MetadataTwitterSite { get; set; }
        public DateTime? PostDate { get; set; }
        public string MetaKeywords { get; set; }
        public IEnumerable<Asset> TeaserImage { get; set; }
        public IEnumerable<Asset> MetadataTwitterImage { get; set; }
        public string MetadataTwitterCreator { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string MetadataTwitterTitle { get; set; }
        public string MetadataTwitterDescription { get; set; }
        public string MetaDescription { get; set; }
        public IEnumerable<Asset> MetadataOgImage { get; set; }
        public IEnumerable<object> RelatedArticles { get; set; }
        public string UrlPattern { get; set; }
        public ContentItemSystemAttributes System { get; set; }
    }
}