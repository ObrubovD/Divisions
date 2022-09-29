using Divisions.Dal;
using Divisions.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Divisions.Services
{
    public class StatusService : BackgroundService
    {
        
        readonly IServiceScopeFactory _scopeFactory;
        public StatusService(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }


        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DivisionDbContext>();
            await ChangeStatuses(dbContext);
        }
        private async Task ChangeStatuses(DivisionDbContext dbContext)
        {
            
            while (true)
            {
                var divisions = await dbContext.Divisions
                    .ToListAsync();

                foreach (var division in divisions)
                {
                    division.Status = !division.Status;
                }

                await dbContext.SaveChangesAsync();
                await Task.Delay(3000);
            }
        }

       

        public async Task<List<DivisionStatusDto>> GetDivisionStatuses()
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DivisionDbContext>();
            return await dbContext.Divisions
                .Select(a => DivisionStatusDto.Create(a))
                .ToListAsync();
        }

    }
}
