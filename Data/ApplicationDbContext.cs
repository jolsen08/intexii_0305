using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using IntexII_0305.Data;
using Microsoft.AspNetCore.Identity;
using System.Configuration;
using IntexII_0305.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Text;
using IntexII_0305.Models;

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
            optionsBuilder.UseNpgsql("Server=database-1.cwabqvknqua4.us-west-2.rds.amazonaws.com;Port=5432;Database=intex2;UserId=goshgang;Password=^4WQ2xpZh!#pCq2;");
        }

    }
}