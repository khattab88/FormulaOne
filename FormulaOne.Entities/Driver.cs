using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities
{
    public class Driver : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int DriverNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; }

        public Driver()
        {
            Achievements = new HashSet<Achievement>();
        }
    }
}
