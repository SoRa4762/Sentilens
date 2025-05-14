using api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //public override DbSet<User> Users { get; set; }
        public DbSet<UserTopic> UserTopics { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<FeedSource> FeedSource { get; set; }
        public DbSet<FeedSourceTopic> FeedSourceTopics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // FeedSource -> Article (one to many)
            modelBuilder.Entity<Article>()
                .HasOne(a => a.FeedSource)
                .WithMany(fs => fs.Articles)
                .HasForeignKey(a => a.FeedSourceId)
                .OnDelete(DeleteBehavior.Cascade); // if FeedSource is deleted, delete all related Articles

            // FeedSource <-> Topic (many to many via FeedSourceTopic(bridge entity))
            modelBuilder.Entity<FeedSourceTopic>()
                .HasKey(fst => new { fst.FeedSourceId, fst.TopicId }); // Composite Primary Key

            modelBuilder.Entity<FeedSourceTopic>()
                .HasOne(fst => fst.FeedSource)
                .WithMany(fs => fs.FeedSourceTopics)
                .HasForeignKey(fst => fst.FeedSourceId);

            modelBuilder.Entity<FeedSourceTopic>()
                .HasOne(fst => fst.Topic)
                .WithMany(t => t.FeedSourceTopics)
                .HasForeignKey(fst => fst.TopicId);

            // User <-> Topic (many to many via UserTopic(bridge entity))
            modelBuilder.Entity<UserTopic>()
                .HasKey(ut => new {ut.UserId, ut.TopicId });
            
            modelBuilder.Entity<UserTopic>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.UserTopics)
                .HasForeignKey(ut => ut.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserTopic>()
                .HasOne(ut => ut.Topic)
                .WithMany(t => t.UserTopics)
                .HasForeignKey(ut => ut.TopicId)
                .OnDelete(DeleteBehavior.Cascade);

            List<IdentityRole> identityRoles = new List<IdentityRole>
            {
                new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole() { Name = "User", NormalizedName = "USER" },
            };
            modelBuilder.Entity<IdentityRole>().HasData(identityRoles);
        }
    }
}
