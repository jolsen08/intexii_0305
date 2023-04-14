using IntexII_0305.Models;
using Microsoft.AspNetCore.Mvc;
namespace IntexII_0305.Controllers

{
    public class DataBaseController : Controller
    {
        private IntexContext repo;
        public DataBaseController(IntexContext temp)
        {
            repo = temp;
        }

        public IActionResult Tables(){
            return View();
        }

        [HttpGet]
        public IActionResult Analysis(){
            return View();
        }

        [HttpPost]
        public IActionResult Analysis(Analysis model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult AnalysisTextile(AnalysisTextile model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult Artifactfagelgamousregister(Artifactfagelgamousregister model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult ArtifactfagelgamousregisterBurialmain(ArtifactfagelgamousregisterBurialmain model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult Artifactkomaushimregister(Artifactkomaushimregister model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult ArtifactkomaushimregisterBurialmain(ArtifactkomaushimregisterBurialmain model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult Biological(Biological model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult BiologicalC14(BiologicalC14 model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult Bodyanalysischart(Bodyanalysischart model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult Book(Book model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult BurialmainBiological(BurialmainBiological model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult BurialmainBodyanalysischart(BurialmainBodyanalysischart model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult BurialmainCranium(BurialmainCranium model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult BurialmainTextile(BurialmainTextile model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult C14(C14 model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult Color(Color model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }
         
        [HttpPost]
        public IActionResult ColorTextile(ColorTextile model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }
         
        [HttpPost]
        public IActionResult Cranium(Cranium model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }
         
        [HttpPost]
        public IActionResult Decoration(Decoration model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }
         
        [HttpPost]
        public IActionResult DecorationTextile(DecorationTextile model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }
         
        [HttpPost]
        public IActionResult Dimension(Dimension model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }
         
        [HttpPost]
        public IActionResult DimensionTextile(DimensionTextile model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }
         
        [HttpPost]
        public IActionResult Newsarticle(Newsarticle model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }
         
        [HttpPost]
        public IActionResult PhotodataTextile(PhotodataTextile model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult Photodatum(Photodatum model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult Photoform(Photoform model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult Structure(Structure model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult StructureTextile(StructureTextile model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult Teammember(Teammember model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult Textile(Textile model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [HttpPost]
        public IActionResult Textilefunction(Textilefunction model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

         [HttpPost]
        public IActionResult TextilefunctionTextile(TextilefunctionTextile model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

         [HttpPost]
        public IActionResult Yarnmanipulation(Yarnmanipulation model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

          [HttpPost]
        public IActionResult YarnmanipulationTextile(YarnmanipulationTextile model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

    }
}
