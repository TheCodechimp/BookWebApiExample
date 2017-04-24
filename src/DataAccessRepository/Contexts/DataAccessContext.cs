using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccessRepository
{
    public interface IDbContext : IDisposable
    {
        DbSet<BookDataModel> Books { get; set; }

        Task<int> SaveChanges();
    }

    public class DataAccessContext : DbContext, IDbContext
    {
        public DataAccessContext()
        {            
        }
        public DataAccessContext(DbContextOptions<DataAccessContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TestDatabase;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDataModel>().ToTable("Book");
        }

        public async Task<int> SaveChanges()
        {
            return await SaveChangesAsync();
        }

        public DbSet<BookDataModel> Books { get; set; }
    }
}
