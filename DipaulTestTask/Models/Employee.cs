using System;

namespace DipaulTestTask.Models
{
    [Serializable]
    public class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public Employee() { }

        public Employee(string name, string position) : this()
        {
            Name = name;
            Position = position;
        }
    }
}
