using System;

namespace MiniApp1.Core.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public Decimal Salary { get; set; }
        public string Position { get; set; }
        public string Adress { get; set; }
        public string UserId { get; set; }

    }
}
