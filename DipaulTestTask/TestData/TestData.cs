using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using DipaulTestTask.Models;


namespace DipaulTestTask.TestData
{
    public class TestData
    {

        /*        public IList<Company> Companies { get; set;  } = Enumerable.Range(1, 10)
                   .Select(i => new Company
                   {               
                       Id = i,
                       Name = $"CompanyName {i}",
                       Employees = Enumerable.Range(1, 5)
                           .Select(i => new Employee
                           {
                               Id = i,
                               Name = $"Employee {i}",
                               Pos = Position.Developer
                           })
                           .ToList()
                   })
                   .ToList();*/

        public IList<Company> Companies { get; set; } = new List<Company>()
        {

        };

/*        public static TestData LoadFromXML(string fileName)
        {
            var serializer = new XmlSerializer(typeof(TestData));
            using var file = File.OpenText(fileName);
            return (TestData)serializer.Deserialize(file);
        }

        public void SaveToXML(string fileName)
        {
            var serializer = new XmlSerializer(typeof(TestData));
            using var file = File.Create(fileName);
            serializer.Serialize(file, this);
        }*/
    }
}
