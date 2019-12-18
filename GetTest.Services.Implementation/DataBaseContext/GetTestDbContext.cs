using GetTest.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetTest.Services.Implementation.DataBaseContext
{
    public class GetTestDbContext :  DbContext
    {
        public GetTestDbContext(DbContextOptions<GetTestDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Test> Tests { get; set; }
    }
}
