using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

using DipaulTestTask.Context;
using DipaulTestTask.Models;


namespace DipaulTestTask.Service
{
    class DataStorageInDB
    {
        const string sql_server_connect_string = @"(localdb)\MSSQLLocalDB;Initial Catalog=CompaniesDB.db";
                
        public void InitDB()
        {
            var connection_options = new DbContextOptionsBuilder<CompaniesDB>()
                .UseSqlServer(sql_server_connect_string)
                .Options;

            using (var db = new CompaniesDB(connection_options))
            {
                db.Database.EnsureCreated();

                if(!db.Companies.Any())
                {
                    var companies = new List<Company>
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

                    foreach(Company company in companies)
                        db.Companies.Add(company);

                    db.SaveChanges();
                }

                var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();
            }
        }        
    }
}
