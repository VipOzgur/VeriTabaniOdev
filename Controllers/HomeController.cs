using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VtOdev.Models;

namespace VtOdev.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Tablolar eklendi
        //Miras eklendi (soyut)
        //Stokta en çok bulunan ürünü listeleme.
        //Sipariþlerin toplam tutarýný hesaplama(Quantity* Price).
        //Verilen bir müþterinin yaptýðý tüm sipariþlerin listesi.
        //Polimorfizm: ILogger adýnda bir interface tanýmlanmalý ve bu interface iki farklý sýnýf tarafýndan implemente edilmelidir
        //

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
            ILoggerr logger = new DbLogger();
            logger.Log("Uygulama çalýþtý");
            ILoggerr loggerr = new FLogs();
            loggerr.Log("Uygulama çalýþtý");

            }
            catch (Exception)
            {

                throw;
            }
            return View();
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
