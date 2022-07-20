using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class Context : IdentityDbContext<SystemUser, SystemRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-B64E139;database=CorePortfolioDB;integrated security=true");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<MainPage> MainPages { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
    }
}
