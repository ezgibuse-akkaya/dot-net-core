using System.Collections.Generic;

namespace MiniApp1.Core.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
