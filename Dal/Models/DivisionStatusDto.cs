using Divisions.Dal.Dbo;

namespace Divisions.Dal.Models
{
    public class DivisionStatusDto
    {
        public string Name { get; set; }

        public bool Status { get; set; }

        public static DivisionStatusDto Create(DivisionDbo dbo)
        {
            return new DivisionStatusDto()
            {
                Name = dbo.Name,
                Status = dbo.Status
            };
        }
    }
}
