using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DtoModels
{
    public class LotteryAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<RoundResults> RoundResults { get; set; }

        public LotteryAppContext(DbContextOptions<LotteryAppContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<User>()
            //    .HasMany<Ticket>()
            //    .WithOne(x => x.User)
            //    .HasForeignKey(x => x.UserId);

            builder.Entity<Ticket>()
                .HasOne(x=>x.User)
                .WithMany(x => x.Tickets)
                .HasForeignKey(x => x.UserId);
        }
    }
}
