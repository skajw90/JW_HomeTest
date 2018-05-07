using System;
using System.Data.Entity;

namespace HealthCatalystHomeTest.Models
{
    public interface IHealthCatalystHomeTestContext : IDisposable
    {
        DbSet<User> Users { get; }
        int SaveChanges();
        void MarkAsModified(User user);
    }
}
