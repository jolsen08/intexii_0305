using IntexII_0305.Models;
using IntexII0305.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexII0305.Models
{
    //This interface object creates the IQueryable type object "Books". This class will be referenced in the 
    //EFBookStoreRepository class
    public interface IIntexRepository
    {
        IQueryable<Burialmain> burialmain { get; }
        IQueryable<Analysis> analysis { get; }
        IQueryable<AnalysisTextile> analysistextile { get; }
        IQueryable<Artifactfagelgamousregister> artifactfagelgamousregister { get; }
        IQueryable<ArtifactfagelgamousregisterBurialmain> artifactfagelgamousregisterburialmain { get; }
        IQueryable<Artifactkomaushimregister> artifactkomaushimregister { get; }
        IQueryable<ArtifactkomaushimregisterBurialmain> artifactkomaushimregisterburialmain { get; }
        IQueryable<Biological> biological { get; }
        IQueryable<BiologicalC14> biologicalc14 { get; }
        IQueryable<Bodyanalysischart> bodyanalysischart { get; }
        IQueryable<Book> books { get; }
        IQueryable<BurialmainBiological> burialmainbiological { get; }
        IQueryable<BurialmainBodyanalysischart> burialmainbodyanalysischart { get; }
        IQueryable<BurialmainCranium> burialmaincranium { get; }
        IQueryable<BurialmainTextile> burialmaintextile { get; }
        IQueryable<C14> c14 { get; }
        IQueryable<Color> color { get; }
        IQueryable<ColorTextile> colortextile { get; }
        IQueryable<Cranium> cranium { get; }
        IQueryable<Decoration> decoration { get; }
        IQueryable<DecorationTextile> decorationtextile { get; }
        IQueryable<Dimension> dimension { get; }
        IQueryable<DimensionTextile> dimensiontextile { get; }
        IQueryable<Newsarticle> newsarticle { get; }
        IQueryable<Photodatum> photodata { get; }
        IQueryable<PhotodataTextile> photodatatextile { get; }
        IQueryable<Photoform> photoform { get; }
        IQueryable<Structure> structure { get; }
        IQueryable<StructureTextile> structuretextile { get; }
        IQueryable<Teammember> teammember { get; }
        IQueryable<Textile> textile { get; }
        IQueryable<Textilefunction> textilefunction { get; }
        IQueryable<TextilefunctionTextile> textilefunctiontextile { get; }
        IQueryable<Yarnmanipulation> yarnmanipulation { get; }
        IQueryable<YarnmanipulationTextile> yarnmanipulationtextile { get; }
    }
}
