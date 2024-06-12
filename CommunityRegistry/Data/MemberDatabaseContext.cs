using Microsoft.EntityFrameworkCore;
using CommunityRegistry.Models;

namespace CommunityRegistry.Data
{
    internal class MemberDatabaseContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            // Define path for the database to be built  
            builder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}MemberDatabase.db");
            base.OnConfiguring(builder);
        }
        public DbSet<Member>? Members { get; set; }
    }
}
