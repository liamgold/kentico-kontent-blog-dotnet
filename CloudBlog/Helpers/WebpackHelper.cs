using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Hosting;

namespace CloudBlog.Helpers
{
    public static class WebpackHelper
    {
        public static bool UseIntegrityHashes => false;

        public static string PublicPath => "~/sitefiles/dist/";

        public static string AssetJsonFilePath => "~/sitefiles/dist/assets.json";

        public static string ManifestJsonFilePath => "~/sitefiles/dist/manifest.json";

        public const string WebpackMacroRegex = @"\[\[(?'macroname'.+?)\|(?'bundlename'.+?)(?:\|(?'assetmode'.+?))*?\]\]";

        public static string GetAssetContent(string fileName)
        {
            var assetUrl = GetAssetUrl(fileName);

            if (string.IsNullOrWhiteSpace(assetUrl))
            {
                return string.Empty;
            }

            var assetUri = new Uri(assetUrl, UriKind.RelativeOrAbsolute);

            string assetFilePath;

            if (assetUri.IsAbsoluteUri)
            {
                assetFilePath = HostingEnvironment.MapPath($"~{assetUri.LocalPath}");
            }
            else
            {
                assetFilePath = HostingEnvironment.MapPath($"~{assetUri.OriginalString.TrimStart('~')}");
            }

            if (string.IsNullOrWhiteSpace(assetFilePath))
            {
                return string.Empty;
            }

            if (File.Exists(assetFilePath) == false)
            {
                return string.Empty;
            }

            return File.ReadAllText(assetFilePath);
        }

        public static string GetAssetUrl(string fileName)
        {
            var asset = GetAsset(fileName);

            if (asset == null)
            {
                return string.Empty;
            }

            // If it starts with "/" then assume it is already prefixed with public path.
            if (asset.Src.StartsWith("/"))
            {
                return asset.Src;
            }

            // Otherwise prefix manually.
            return $"{PublicPath.TrimEnd('/')}/{asset.Src}";
        }

        public static string GetAssetIntegrity(string fileName)
        {
            if (!UseIntegrityHashes)
            {
                return string.Empty;
            }

            var asset = GetAsset(fileName);

            if (asset == null)
            {
                return string.Empty;
            }

            return asset.Integrity;
        }

        public static WebpackAsset GetAsset(string fileName)
        {
            var assetsJsonPath = HostingEnvironment.MapPath(AssetJsonFilePath);

            if (string.IsNullOrWhiteSpace(assetsJsonPath))
            {
                return null;
            }

            if (File.Exists(assetsJsonPath) == false)
            {
                return null;
            }

            var assetsJson = File.ReadAllText(assetsJsonPath);
            var definition = JsonConvert.DeserializeObject<WebpackAssetsDefinition>(assetsJson);

            if (!definition.ContainsKey(fileName))
            {
                return null;
            }

            return definition[fileName];
        }
    }

    public class WebpackAssetsDefinition : Dictionary<string, WebpackAsset>
    {
    }

    public class WebpackAsset
    {
        public string Integrity { get; set; }
        public string Src { get; set; }
    }
}