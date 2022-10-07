using ConsumirApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using TiendaApi.Modelo;

namespace ConsumirApi.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<ActionResult> Index()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://localhost:7093/api/productos");
            var productolista = JsonConvert.DeserializeObject<List<ModeloProductos>>(json);
            return View(productolista);
            //WebRequest oRequest = WebRequest.Create("https://localhost:7093/api/productos");
            // WebResponse oResponse = oRequest.GetResponse();
            // StreamReader sr = new StreamReader(oResponse.GetResponseStream());
            //return await sr.ReadToEndAsync();
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