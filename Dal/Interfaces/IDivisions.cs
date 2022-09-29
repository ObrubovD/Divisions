using Divisions.Dal.Dbo;
using Divisions.Dal.Models;

namespace Divisions.Dal.Interfaces
{
    public interface IDivisions
    {
        IEnumerable<DivisionDbo> AllDivisions { get;  }
     
    }
}
