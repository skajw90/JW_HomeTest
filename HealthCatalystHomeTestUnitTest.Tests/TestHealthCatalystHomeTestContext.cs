using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthCatalystHomeTest.Models;

namespace HealthCatalystHomeTest.Tests
{
    class TestHealthCatalystHomeTestContext : IHealthCatalystHomeTestContext
    {
        public TestHealthCatalystHomeTestContext()
        {
            this.Users = new TestUserDbSet();
        }

        public DbSet<User> Users { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(User user) { }

        public void Dispose() { }
    }
}
