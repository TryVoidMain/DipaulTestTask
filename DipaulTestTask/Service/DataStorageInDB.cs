using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions;


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
            }
        }        
    }
}
