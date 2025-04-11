using api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserTopic> UserTopics { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<FeedSource> FeedSource { get; set; }
        public DbSet<FeedSourceTable> FeedSourceTables { get; set; }
    }
}
