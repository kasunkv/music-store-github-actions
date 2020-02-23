using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicStore.Services;
using MusicStore.Web.Models;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MusicStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAlbumService _albumService;

        public HomeController(IAlbumService albumService, ILogger<HomeController> logger)
        {
            _albumService = albumService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var vm = new HomeViewModel();
            vm.Featured = _albumService.AllAlbums();

            vm.Suggestions = _albumService.UserPreferenceAlbums();

            return View(vm);
        }

        public IActionResult Albums()
        {
            var albums = _albumService.AllAlbums();
            return View(albums);
        }

        public async Task<IActionResult> Promotions()
        {
            var promoAlbums = await _albumService.PromotionalAlbumsAsync();
            return View(promoAlbums);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
