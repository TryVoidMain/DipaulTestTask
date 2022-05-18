using System;
using System.Diagnostics;
using System.Collections.Generic;

using DipaulTestTask.Interfaces;
using DipaulTestTask.Models;

namespace DipaulTestTask.Service
{
    public class DataStorageInMemory : ICompanyStorage
    {
        public ICollection<Company> Companies { get; set; } = new List<Company>();

        ICollection<Company> IStorage<Company>.Items => Companies;

        public void Load()
        {
            Debug.WriteLine("Загрузка данных");

            if (Companies is null || Companies.Count == 0)
                Companies = new List<Company>
                {
                    new Company
                    {
                        Id = 1,
                        Name = "Диполь",
                        Employees = new List<Employee>
                        {
                            new Employee
                            {
                                Id = 1,
                                Name = "Vasya",
                                Pos = Position.Developer
                            },
                            new Employee
                            {
                                Id = 2,
                                Name = "Petya",
                                Pos = Position.Manager
                            },
                            new Employee
                            {
                                Id = 3,
                                Name = "Vasilisa",
                                Pos = Position.CEO
                            }

                        }
                    },

                    new Company
                    {
                        Id = 1,
                        Name = "OneAss",
                        Employees = new List<Employee>
                        {
                            new Employee
                            {
                                Id = 1,
                                Name = "Petya",
                                Pos = Position.Developer
                            },
                            new Employee
                            {
                                Id = 2,
                                Name = "Vasya",
                                Pos = Position.CEO
                            },
                            new Employee
                            {
                                Id = 3,
                                Name = "Vasilisa",
                                Pos = Position.Manager
                            }

                        }
                    }
                };


        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
