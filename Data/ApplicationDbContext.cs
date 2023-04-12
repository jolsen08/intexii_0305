using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using IntexII_0305.Data;
using Microsoft.AspNetCore.Identity;
using System.Configuration;
using IntexII_0305.Areas.Identity.Data;


namespace IntexII_0305.Data
{

    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID=postgres;Password=password;Server=localhost;Port=5432;Database=intex2;");
        }
    }
}