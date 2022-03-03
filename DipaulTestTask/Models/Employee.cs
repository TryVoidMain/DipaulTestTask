using System;

namespace DipaulTestTask.Models
{
    [Serializable]
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Position Pos { get; set; }

        public Employee() { }

        public Employee(string name, Position position) : this()
        {
            Name = name;
            Pos = position;
        }
    }


}
