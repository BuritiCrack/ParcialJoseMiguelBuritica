using ParcialJoseMiguelBuritica.DAL.Entities;

namespace ParcialJoseMiguelBuritica.DAL
{
    public class SeederDb
    {
        private readonly DataBaseContext _context;

        public SeederDb(DataBaseContext context) 
        {
            _context = context;
        }

        public async Task SeederAsync() 
        {
            await _context.Database.EnsureCreatedAsync();

            await PopulateTicketsAsync();

            await _context.SaveChangesAsync();
        }

        private async Task PopulateTicketsAsync() 
        {
            if (!_context.Tickets.Any())
            {
                for (int t = 0; t < 50000; t++)
                {
                    _context.Tickets.Add (new Ticket{ UseDate = null, IsUsed = false, EntranceGate = null});

                }

            }
        }
    }
}
