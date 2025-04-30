using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Final_API.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Final_API.DAL.Context
{
    public class ApplicationDbContext:IdentityDbContext<CustomUser>
    {
        public DbSet<Project> Projects {  get; set; }
        public DbSet<Bug> Bugs {  get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<UserBug> UserBugs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<CustomUser>(entity => entity.ToTable("Users"));
            builder.Entity<UserBug>()
               .HasKey(ub => new { ub.UserId, ub.BugId });

            builder.Entity<UserBug>()
                .HasOne(ub => ub.User)
                .WithMany(u => u.UserBugs)
                .HasForeignKey(ub => ub.UserId);

            builder.Entity<UserBug>()
                .HasOne(ub => ub.Bug)
                .WithMany(b => b.UserBugs)
                .HasForeignKey(ub => ub.BugId);
        }
    }
}
