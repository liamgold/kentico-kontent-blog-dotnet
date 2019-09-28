using CloudBlog.Models;
using Kentico.Kontent.Delivery;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CloudBlog.Controllers
{
    public class BlogController : ControllerBase
    {
        public async Task<ActionResult> Index()        
        {
            var response = await client.GetItemsAsync<BlogPost>();

            return View(response.Items);
        }

        public async Task<ActionResult> Post(string urlSlug)
        {
            var response = await client.GetItemsAsync<BlogPost>(
                new EqualsFilter($"elements.{BlogPost.UrlPatternCodename}", urlSlug),
                new EqualsFilter("system.type", BlogPost.Codename),
                new DepthParameter(1)
            );

            if (response.Items.Count == 0)
            {
                throw new HttpException(404, "Not found");
            }
            else
            {
                return View(response.Items[0]);
            }
        }

        public async Task<ActionResult> Tag(string tagCode)
        {
            var response = await client.GetItemsAsync<BlogPost>(
                new ContainsFilter($"elements.{BlogPost.BlogTagCodename}", tagCode),
                new EqualsFilter("system.type", BlogPost.Codename)
            );

            return View(response.Items);
        }
    }
}