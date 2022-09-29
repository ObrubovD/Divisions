using Divisions.Dal;
using Divisions.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Divisions.Services
{
    public class DivisionsService
    {
        readonly DivisionDbContext _dbContext;

        readonly IServiceScopeFactory _scopeFactory;

        public DivisionsService(DivisionDbContext dbContext, IServiceScopeFactory scopeFactory)
        {
            _dbContext = dbContext;
            _scopeFactory = scopeFactory;
        }

        public async Task<List<DivisionDto>> GetDivisions()
        {
            var divisions = await _dbContext.Divisions
                .Select(a => DivisionDto.Create(a))
                .ToListAsync();

            using var scope = _scopeFactory.CreateScope();
            var statusService = scope.ServiceProvider.GetRequiredService<StatusService>();
            var statuses = await statusService.GetDivisionStatuses();

            foreach (var division in divisions)
            {
                division.Status = statuses.First(a => a.Name == division.Name).Status;
            }

            return divisions;
        }
    }
}
