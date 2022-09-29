using Divisions.Dal.Dbo;
using Divisions.Dal.Models;

namespace Divisions.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<DivisionDbo> dbos { get; set; }
    }
}
