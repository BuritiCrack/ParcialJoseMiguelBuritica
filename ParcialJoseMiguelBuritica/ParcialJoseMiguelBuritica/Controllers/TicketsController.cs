using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParcialJoseMiguelBuritica.DAL;
using ParcialJoseMiguelBuritica.DAL.Entities;
using System.Diagnostics.Metrics;

namespace ParcialJoseMiguelBuritica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : Controller
    {
        private readonly DataBaseContext _context;

        public TicketsController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicket()
        {
            var tickets = await _context.Tickets.ToListAsync();

            if (tickets == null) return NotFound();

            return tickets;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Ticket>> GetTicketById(Guid? id)
        {
            var country = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == id);

            if (country == null) return NotFound();

            return Ok(country);
        }


        //Editar
        [HttpPut, ActionName("Put")]
        [Route("Put/{Id}")]
        public async Task<ActionResult<Ticket>> Verificar(Guid? Id, String entranceGate)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == Id);

            if (ticket != null)
            {
                if (ticket.IsUsed == false)
                {
                    try
                    {
                        ticket.UseDate = DateTime.Now;
                        ticket.IsUsed = true;
                        ticket.EntranceGate = entranceGate;

                        _context.Tickets.Update(ticket);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateException dbUpdateException)
                    {
                        if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                           return Conflict("ya existe");
                    }
                    catch (Exception ex)
                    {
                        return Conflict(ex.Message);
                    }

                    return Ok(ticket);

                }
                return Conflict("Boleta ya usada");

            }

            return NotFound();

        }
    }
}
