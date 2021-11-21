using System;
using System.Collections.Generic;

namespace MiniApp1.Core.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }

        public string RelatedConsumerName { get; set; }

        public ICollection<Employee> Employees { get; set; }

    }
}
