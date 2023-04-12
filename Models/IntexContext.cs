using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable


namespace IntexII_0305.Models
{
    //Our BookstoreContext method inherits from the DbContext and creates the Dbset type variable "Books"
    public class IntexContext : DbContext
    {
        public IntexContext()
        {
        }

        public IntexContext(DbContextOptions<IntexContext> options)
            : base(options)
        {
        }

        public DbSet<Burialmain> burialmain { get; set; }
    }
}
