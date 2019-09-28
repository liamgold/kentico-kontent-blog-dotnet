namespace KontentBlog.Models
{
    public partial class BlogPost : IMetadata, IDetailItem
    {
        public string Type => System.Type;
        public string Id => System.Id;
    }
}