using IntexII_0305.Models;
using IntexII0305.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexII0305.Models
{
    //The EFBookStoreRepository class inherits from IBookStoreRepository and adds the context variable as well as
    //the IQueryable type object from Book "Books"
    public class EFIntexRepository : IIntexRepository
    {

        private IntexContext context { get; set; }

        public EFIntexRepository (IntexContext temp)
        {
            context = temp;
        }
        public IQueryable<Burialmain> burialmain => context.burialmain;
        public IQueryable<Analysis> analysis => context.analysis;
        public IQueryable<AnalysisTextile> analysistextile => context.analysistextile;
        public IQueryable<Artifactfagelgamousregister> artifactfagelgamousregister => context.artifactfagelgamousregister;
        public IQueryable<ArtifactfagelgamousregisterBurialmain> artifactfagelgamousregisterburialmain => context.artifactfagelgamousregisterburialmain;
        public IQueryable<Artifactkomaushimregister> artifactkomaushimregister => context.artifactkomaushimregister;
        public IQueryable<ArtifactkomaushimregisterBurialmain> artifactkomaushimregisterburialmain => context.artifactkomaushimregisterburialmain;
        public IQueryable<Biological> biological => context.biological;
        public IQueryable<BiologicalC14> biologicalc14 => context.biologicalc14;
        public IQueryable<Bodyanalysischart> bodyanalysischart => context.bodyanalysischart;
        public IQueryable<Book> books => context.books;
        public IQueryable<BurialmainBiological> burialmainbiological => context.burialmainbiological;
        public IQueryable<BurialmainBodyanalysischart> burialmainbodyanalysischart => context.burialmainbodyanalysischart;
        public IQueryable<BurialmainCranium> burialmaincranium => context.burialmaincranium;
        public IQueryable<BurialmainTextile> burialmaintextile => context.burialmaintextile;
        public IQueryable<C14> c14 => context.c14;
        public IQueryable<Color> color => context.color;
        public IQueryable<ColorTextile> colortextile => context.colortextile;
        public IQueryable<Cranium> cranium => context.cranium;
        public IQueryable<Decoration> decoration => context.decoration;
        public IQueryable<DecorationTextile> decorationtextile => context.decorationtextile;
        public IQueryable<Dimension> dimension => context.dimension;
        public IQueryable<DimensionTextile> dimensiontextile => context.dimensiontextile;
        public IQueryable<Newsarticle> newsarticle => context.newsarticle;
        public IQueryable<Photodatum> photodata => context.photodata;
        public IQueryable<PhotodataTextile> photodatatextile => context.photodatatextile;
        public IQueryable<Photoform> photoform => context.photoform;
        public IQueryable<Structure> structure => context.structure;
        public IQueryable<StructureTextile> structuretextile => context.structuretextile;
        public IQueryable<Teammember> teammember => context.teammember;
        public IQueryable<Textile> textile => context.textile;
        public IQueryable<Textilefunction> textilefunction => context.textilefunction;
        public IQueryable<TextilefunctionTextile> textilefunctiontextile => context.textilefunctiontextile;
        public IQueryable<Yarnmanipulation> yarnmanipulation => context.yarnmanipulation;
        public IQueryable<YarnmanipulationTextile> yarnmanipulationtextile => context.yarnmanipulationtextile;
    }
}
