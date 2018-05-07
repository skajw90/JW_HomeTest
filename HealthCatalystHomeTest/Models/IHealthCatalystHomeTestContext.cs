using System;
using System.Data.Entity;

namespace HealthCatalystHomeTest.Models
{
    /// <summary>
    /// Interface for DB context to switch Fake and real DB
    /// </summary>
    public interface IHealthCatalystHomeTestContext : IDisposable
    {
        DbSet<User> Users { get; }
        int SaveChanges();
    }
}
