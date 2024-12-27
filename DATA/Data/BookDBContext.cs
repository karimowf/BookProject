using BookService.TypeConfigure;
using DATA.Data.Entity;
using DATA.TypeConfigure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Data
{
    public class BookDbContext : IdentityDbContext<User, Role, string>
    {

        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookUser> BookUsers { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookEntityConfigure());
            modelBuilder.ApplyConfiguration(new ScoreEntityConfigure());

            base.OnModelCreating(modelBuilder);
        }
    }
}
