using Divisions.Dal.Dbo;

namespace Divisions.Dal.Models
{
    public class DivisionDto
    {
        public string Name { get; set; }

        public bool Status { get; set; }

        public string ParentDivisionName { get; set; }

        public static DivisionDto Create(DivisionDbo dbo)
        {
            return new DivisionDto()
            {
                Name = dbo.Name,
                ParentDivisionName = dbo.ParentDivision.Name
            };
        }
    }
}
