using Divisions.Dal.Dbo;
using Divisions.Dal.Interfaces;
using Divisions.Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Divisions.Dal.Repository
{
    public class DivisionsRepository:IDivisions
    {
        private readonly DivisionDbContext dbContext;
        public DivisionsRepository(DivisionDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IEnumerable<DivisionDbo> AllDivisions => dbContext.Divisions;
    }
}
