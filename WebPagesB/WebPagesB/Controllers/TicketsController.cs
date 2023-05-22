using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ParcialJoseMiguelBuritica.DAL.Entities;
using System.Net.Http;

namespace WebPagesB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : Controller
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _configuration;

        public TicketsController(IHttpClientFactory httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;

        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {

                var url = _configuration["https://localhost:7005/api/Tickets/Get/"];
                var json = await _httpClient.CreateClient().GetStringAsync(url);
                List<Ticket> tickets = JsonConvert.DeserializeObject<List<Ticket>>(json);
                return View(tickets);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }


   //    [HttpGet]
   //    public async Task<IActionResult> Edit(Guid? id)
   //    {
   //        var url = String.Format("https://localhost:7005/api/Tickets/Get/{0}", id);
   //        var json = await _httpClient.CreateClient().GetStringAsync(url);
   //        Ticket ticket = JsonConvert.DeserializeObject<Ticket>(json);
   //        return View(ticket);
   //    }
   //
   //    [HttpPost]
   //    [ValidateAntiForgeryToken]
   //    public async Task<IActionResult> Edit(Guid? id, Ticket ticket)
   //    {
   //        try
   //        {
   //            var url = String.Format("https://localhost:7005/api/Tickets/Edit/{0}", id);
   //            await _httpClient.CreateClient().PutAsJsonAsync(url, ticket);
   //            return RedirectToAction("Index");
   //        }
   //        catch (Exception ex)
   //        {
   //            return View("Error", ex);
   //        }
   //
   //    }

    }
}
