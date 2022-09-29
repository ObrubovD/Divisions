using System.ComponentModel.DataAnnotations;

namespace Divisions.Dal.Dbo
{
    public class DivisionDbo : BaseDbo
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public bool Status { get; set; }

        public Guid? ParentDivisionId { get; set; } = Guid.Empty;


        
        public DivisionDbo ParentDivision { get; set; }
    }
}
