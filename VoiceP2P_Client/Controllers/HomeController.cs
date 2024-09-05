using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VoiceP2P_Client.Models;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Windows;

namespace VoiceP2P_Client.Controllers
{
    public class HomeController : Controller
    {
        public HubConnection connection;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var clientUrl = GetClientUrl(HttpContext);
            Console.WriteLine(clientUrl);
            
            // создаем подключение к хабу
            //connection = new HubConnectionBuilder()
            //    .WithUrl("https://localhost:7282/chat")
            //    .Build();
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

        private string GetClientUrl(HttpContext context)
        {
            var request = context.Request;
            var clientUrl = $"{request.Scheme}://{request.Host}{request.PathBase}";
            return clientUrl;
        }
    }
}
