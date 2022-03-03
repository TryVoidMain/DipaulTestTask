using System;
using System.Collections.Generic;

namespace DipaulTestTask.Models
{
    [Serializable]
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }

        public Company() { }
        public Company(string name) : this()
        {
            Name = name;
            Employees = new List<Employee>();
        }
    }
}
