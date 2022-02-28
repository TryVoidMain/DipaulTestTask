using System;

namespace DipaulTestTask.Models
{
    [Serializable]
    public class Employee
    {
        public string Name { get; set; }

        public Employee() { }

        public Employee(string name)
        {
            Name = name;
        }
    }
}
