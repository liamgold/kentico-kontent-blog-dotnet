using CloudBlog.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CloudBlog.Controllers
{
    public class HomeController : ControllerBase
    {
        public async Task<ActionResult> Index()
        {
            var response = await client.GetItemAsync<Home>(Home.Codename);

            var viewModel = new HomeViewModel
            {
                ContentItem = response.Item,
            };

            return View(viewModel);
        }
    }
}