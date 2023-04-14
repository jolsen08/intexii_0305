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
        public DbSet<Analysis> analysis { get; set; }
        public DbSet<AnalysisTextile> analysistextile { get; set; }
        public DbSet<Artifactfagelgamousregister> artifactfagelgamousregister { get; set; }
        public DbSet<ArtifactfagelgamousregisterBurialmain> artifactfagelgamousregisterburialmain { get; set; }
        public DbSet<Artifactkomaushimregister> artifactkomaushimregister { get; set; }
        public DbSet<ArtifactkomaushimregisterBurialmain> artifactkomaushimregisterburialmain { get; set; }
        public DbSet<Biological> biological { get; set; }
        public DbSet<BiologicalC14> biologicalc14 { get; set; }
        public DbSet<Bodyanalysischart> bodyanalysischart { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<BurialmainBodyanalysischart> burialmainbodyanalysischart { get; set; }
        public DbSet<BurialmainBiological> burialmainbiological { get; set; }
        public DbSet<BurialmainCranium> burialmaincranium { get; set; }
        public DbSet<BurialmainTextile> burialmaintextile { get; set; }
        public DbSet<C14> c14 { get; set; }
        public DbSet<Color> color { get; set; }
        public DbSet<ColorTextile> colortextile { get; set; }
        public DbSet<Cranium> cranium { get; set; }
        public DbSet<Decoration> decoration { get; set; }
        public DbSet<DecorationTextile> decorationtextile { get; set; }
        public DbSet<Dimension> dimension { get; set; }
        public DbSet<DimensionTextile> dimensiontextile { get; set; }
        public DbSet<Newsarticle> newsarticle { get; set; }
        public DbSet<Photodatum> photodata { get; set; }
        public DbSet<PhotodataTextile> photodatatextile { get; set; }
        public DbSet<Photoform> photoform { get; set; }
        public DbSet<Structure> structure { get; set; }
        public DbSet<StructureTextile> structuretextile { get; set; }
        public DbSet<Teammember> teammember { get; set; }
        public DbSet<Textile> textile { get; set; }
        public DbSet<Textilefunction> textilefunction { get; set; }
        public DbSet<TextilefunctionTextile> textilefunctiontextile { get; set; }
        public DbSet<Yarnmanipulation> yarnmanipulation { get; set; }
        public DbSet<YarnmanipulationTextile> yarnmanipulationtextile { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnalysisTextile>()
                .HasKey(a => new { a.MainAnalysisid, a.MainTextileid });

            modelBuilder.Entity<ArtifactfagelgamousregisterBurialmain>()
                .HasKey(a => new { a.MainArtifactfagelgamousregisterid, a.MainBurialmainid });

            modelBuilder.Entity<ArtifactkomaushimregisterBurialmain>()
                .HasKey(a => new { a.MainArtifactkomaushimregisterid, a.MainBurialmainid });

            modelBuilder.Entity<BiologicalC14>()
                .HasKey(a => new { a.MainBiologicalid, a.MainC14id });

            modelBuilder.Entity<BurialmainBiological>()
                .HasKey(a => new { a.MainBurialmainid, a.MainBiologicalid });

            modelBuilder.Entity<BurialmainBodyanalysischart>()
                .HasKey(a => new { a.MainBurialmainid, a.MainBodyanalysischartid });

            modelBuilder.Entity<BurialmainCranium>()
                .HasKey(a => new { a.MainBurialmainid, a.MainCraniumid });

            modelBuilder.Entity<BurialmainTextile>()
                .HasKey(a => new { a.MainBurialmainid, a.MainTextileid });

            modelBuilder.Entity<ColorTextile>()
                .HasKey(a => new { a.MainColorid, a.MainTextileid });

            modelBuilder.Entity<DecorationTextile>()
                .HasKey(a => new { a.MainDecorationid, a.MainTextileid });

            modelBuilder.Entity<DimensionTextile>()
                .HasKey(a => new { a.MainDimensionid, a.MainTextileid });

            modelBuilder.Entity<PhotodataTextile>()
                .HasKey(a => new { a.MainPhotodataid, a.MainTextileid });

            modelBuilder.Entity<StructureTextile>()
                .HasKey(a => new { a.MainStructureid, a.MainTextileid });

            modelBuilder.Entity<TextilefunctionTextile>()
                .HasKey(a => new { a.MainTextilefunctionid, a.MainTextileid });

            modelBuilder.Entity<YarnmanipulationTextile>()
                .HasKey(a => new { a.MainYarnmanipulationid, a.MainTextileid });
        }
    }
}
