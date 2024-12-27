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
        //Stokta en �ok bulunan �r�n� listeleme.
        //Sipari�lerin toplam tutar�n� hesaplama(Quantity* Price).
        //Verilen bir m��terinin yapt��� t�m sipari�lerin listesi.
        //Polimorfizm: ILogger ad�nda bir interface tan�mlanmal� ve bu interface iki farkl� s�n�f taraf�ndan implemente edilmelidir
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
            logger.Log("Uygulama �al��t�");
            ILoggerr loggerr = new FLogs();
            loggerr.Log("Uygulama �al��t�");

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
