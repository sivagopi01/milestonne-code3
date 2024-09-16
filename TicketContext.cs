using ASP.NET_core_web_api_Milestone_.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_core_web_api_Milestone_.Data
{
    public class TicketContext:DbContext
    {
            public TicketContext(DbContextOptions<TicketContext> options) : base(options)
            {
            }

            public DbSet<Ticket> Tickets { get; set; }
        
    }
}
