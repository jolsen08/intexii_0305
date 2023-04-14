using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using IntexII_0305.Models.ViewModels;
using IntexII_0305.Models;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Drawing.Printing;
using static System.Reflection.Metadata.BlobBuilder;


namespace IntexII_0305.Controllers
{
    public class HomeController : Controller
    {
        /*
                private IIntexRepository repo;*/
        private IntexContext repo;
        public HomeController(IntexContext temp)
        {
            repo = temp;
        }
        
        // public HomeController(IIntexRepository temp)
        // {
        //     repo = temp;
        // }
       

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AccountManager()
        {
            return View();
        }

        // public IActionResult AllBurialRecords(RecordsViewModel x) 
        // {
        //     ViewBag.Filters = x.Filters;
        //     return View();
        // }

        public IActionResult BurialSummary(
            //string burialArea,
            long? BurialRecordId,
            string? Sexes,
            string? AgesAtDeath,
            string? Depths,
            string? HeadDirections,
            string? Wrappings,
            string? HairColors,
            //string Areas,
            int pageNum = 1)
        {
            int pageSize = 20;

            if (BurialRecordId == 0) BurialRecordId = null;

            var x = new RecordsViewModel
            {
                burialmain = repo.burialmain
                //.Where(c => c.Area == burialArea || burialArea == null)
                .Where(c =>
                    (c.Sex == Sexes || Sexes == null)
                     && (c.Id == BurialRecordId || BurialRecordId == null)
                    && (c.Ageatdeath == AgesAtDeath || AgesAtDeath == null)
                    && (c.Depth == Depths || Depths == null)
                    && (c.Headdirection == HeadDirections || HeadDirections == null)
                    && (c.Wrapping == Wrappings || Wrappings == null)
                    && (c.Haircolor == HairColors || HairColors == null)
                    //&& (c.Area == Areas || Areas == null)
                )
                .OrderBy(t => t.Id)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalNumBurials =
                    //(burialArea == null
                    
                    ((Sexes == null)
                     && (BurialRecordId == null)
                    && (AgesAtDeath == null)
                    && (Depths == null)
                    && (HeadDirections == null)
                    && (Wrappings == null)
                    && (HairColors == null)
                    //&& (Areas == null)
                        ?
                        repo.burialmain.Count()
                        : repo.burialmain.Where(c =>
                            //c.Area == burialArea
                            (c.Sex == Sexes || Sexes == null)
                     && (c.Id == BurialRecordId || BurialRecordId == null)
                    && (c.Ageatdeath == AgesAtDeath || AgesAtDeath == null)
                    && (c.Depth == Depths || Depths == null)
                    && (c.Headdirection == HeadDirections || HeadDirections == null)
                    && (c.Wrapping == Wrappings || Wrappings == null)
                    && (c.Haircolor == HairColors || HairColors == null)
                    //&& (c.Area == Areas || Areas == null)
                            ).Count()),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                },

                Filters = new FilterTypes
                {
                    BurialRecordId = BurialRecordId,
                    Sexes = Sexes,
                    AgesAtDeath = AgesAtDeath,
                    Depths = Depths,
                    HeadDirections = HeadDirections,
                    Wrappings = Wrappings,
                    HairColors = HairColors
                    //Areas = Areas
                }
            };

            if (BurialRecordId != null) HttpContext.Session.SetString("BurialRecordId", BurialRecordId.ToString());
            else HttpContext.Session.Remove("BurialRecordId");
            if (Sexes != null) HttpContext.Session.SetString("Sexes", Sexes);
            else HttpContext.Session.Remove("Sexes");
            if (AgesAtDeath != null) HttpContext.Session.SetString("AgesAtDeath", AgesAtDeath);
            else HttpContext.Session.Remove("AgesAtDeath");
            if (Depths != null) HttpContext.Session.SetString("Depths", Depths);
            else HttpContext.Session.Remove("Depths");
            if (HeadDirections != null) HttpContext.Session.SetString("HeadDirections", HeadDirections);
            else HttpContext.Session.Remove("HeadDirections");
            if (Wrappings != null) HttpContext.Session.SetString("Wrappings", Wrappings);
            else HttpContext.Session.Remove("Wrappings");
            if (HairColors != null) HttpContext.Session.SetString("HairColors", HairColors);
            else HttpContext.Session.Remove("HairColors");
            HttpContext.Session.SetString("PageNum", pageNum.ToString());

            return View("AllBurialRecords", x);
        }

        public IActionResult ExitSummary()
        {
            string? Bri= HttpContext.Session.GetString("BurialRecordId");
            long? BurialRecordId;
            if (Bri == null) BurialRecordId = null;
            else BurialRecordId = long.Parse(Bri);
            string? Sexes = HttpContext.Session.GetString("Sexes");
            string? AgesAtDeath = HttpContext.Session.GetString("AgesAtDeath");
            string? Depths = HttpContext.Session.GetString("Depths");
            string? HeadDirections = HttpContext.Session.GetString("HeadDirections");
            string? Wrappings = HttpContext.Session.GetString("Wrappings");
            string? HairColors = HttpContext.Session.GetString("HairColors");
            string? Pn = HttpContext.Session.GetString("PageNum");
            int pageNum = int.Parse(Pn);

            int pageSize = 20;

            var x = new RecordsViewModel
            {
                burialmain = repo.burialmain
                //.Where(c => c.Area == burialArea || burialArea == null)
                .Where(c =>
                    (c.Sex == Sexes || Sexes == null)
                     && (c.Id == BurialRecordId || BurialRecordId == null)
                    && (c.Ageatdeath == AgesAtDeath || AgesAtDeath == null)
                    && (c.Depth == Depths || Depths == null)
                    && (c.Headdirection == HeadDirections || HeadDirections == null)
                    && (c.Wrapping == Wrappings || Wrappings == null)
                    && (c.Haircolor == HairColors || HairColors == null)
                //&& (c.Area == Areas || Areas == null)
                )
                .OrderBy(t => t.Id)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                PageInfo = new PageInfo
                {
                    TotalNumBurials =
                    //(burialArea == null

                    ((Sexes == null)
                     && (BurialRecordId == null)
                    && (AgesAtDeath == null)
                    && (Depths == null)
                    && (HeadDirections == null)
                    && (Wrappings == null)
                    && (HairColors == null)
                    //&& (Areas == null)
                        ?
                        repo.burialmain.Count()
                        : repo.burialmain.Where(c =>
                            //c.Area == burialArea
                            (c.Sex == Sexes || Sexes == null)
                     && (c.Id == BurialRecordId || BurialRecordId == null)
                    && (c.Ageatdeath == AgesAtDeath || AgesAtDeath == null)
                    && (c.Depth == Depths || Depths == null)
                    && (c.Headdirection == HeadDirections || HeadDirections == null)
                    && (c.Wrapping == Wrappings || Wrappings == null)
                    && (c.Haircolor == HairColors || HairColors == null)
                            //&& (c.Area == Areas || Areas == null)
                            ).Count()),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                },

                Filters = new FilterTypes
                {
                    BurialRecordId = BurialRecordId,
                    Sexes = Sexes,
                    AgesAtDeath = AgesAtDeath,
                    Depths = Depths,
                    HeadDirections = HeadDirections,
                    Wrappings = Wrappings,
                    HairColors = HairColors
                    //Areas = Areas
                }
            };
            return View("AllBurialRecords", x);
        }

            public IActionResult RecordManager()
        {
            return View();
        }

        public IActionResult Tables()
        {
            return View();
        }

        [HttpGet]
        public IActionResult HeadDirectionPred()
        {
            return View();
        }



        [HttpPost]
        public IActionResult HeadDirectionPred(float square_north_south, float body_depth, float south_to_head, float square_east_west, float west_to_head, float west_to_feet, float south_to_feet, string wrapping, string area)
        {
            float wrapping_B;
            float wrapping_H;
            float wrapping_W;
            float area_NE;
            float area_NNW;
            float area_NW;
            float area_SE;
            float area_SW;


            if (wrapping == "B")
            {
                wrapping_B = 1;
                wrapping_H = 0;
                wrapping_W = 0;
            }
            else if (wrapping == "H")
            {
                wrapping_B = 0;
                wrapping_H = 1;
                wrapping_W = 0;
            }
            else
            {
                wrapping_B = 0;
                wrapping_H = 0;
                wrapping_W = 1;
            }

            if (area == "NE")
            {
                area_NE = 1;
                area_NNW = 0;
                area_NW = 0;
                area_SE = 0;
                area_SW = 0;
            }
            else if (area == "NNW")
            {
                area_NE = 0;
                area_NNW = 1;
                area_NW = 0;
                area_SE = 0;
                area_SW = 0;
            }
            else if (area == "NW")
            {
                area_NE = 0;
                area_NNW = 0;
                area_NW = 1;
                area_SE = 0;
                area_SW = 0;
            }
            else if (area == "SE")
            {
                area_NE = 0;
                area_NNW = 0;
                area_NW = 0;
                area_SE = 1;
                area_SW = 0;
            }
            else
            {
                area_NE = 0;
                area_NNW = 0;
                area_NW = 0;
                area_SE = 0;
                area_SW = 1;
            }



            float[] inputData = { square_north_south, body_depth, south_to_head, square_east_west, west_to_head, west_to_feet, south_to_feet, wrapping_B, wrapping_H, wrapping_W, area_NE, area_NNW, area_NW, area_SE, area_SW };

            var session = new InferenceSession("./model.onnx");

            var tensor = new DenseTensor<float>(inputData, new int[] { 1, inputData.Length });

            var inputs = new List<NamedOnnxValue>
            {
                NamedOnnxValue.CreateFromTensor("float_input", tensor)
            };
            var results = session.Run(inputs);
            var output = new string[0];
            output = results.First().AsTensor<string>().ToArray();

            return View("HeadDirectionPred", output[0]);


        }

        public IActionResult UnsupervisedFindings()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RecordDetails()
        {
            // param: FilterTypes filters
            // ViewBag.Filters = filters;
            return View();
        }

        [HttpPost]
        public IActionResult RecordDetails(long id)
        {
            Burialmain burialmain = repo.burialmain.FirstOrDefault(x => x.Id == id);

            return View("RecordDetails", burialmain);
        }

        // [ResponseCache(Duration = n0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }

        [HttpGet]
        public IActionResult Notes()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Notes(long id)
        {
            Burialmain burialmain = repo.burialmain.FirstOrDefault(x => x.Id == id);

            return View("Notes", burialmain);
        }



        //CRUD Functionality

        [Authorize(Roles="SuperAdmin, TA")]
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.burialmain = repo.burialmain.ToList();
            return View();
        }

        [Authorize(Roles="SuperAdmin, TA")]
        [HttpPost]
        public IActionResult Add(Burialmain model)
        {
            if (ModelState.IsValid)
            {
                //change datetime to UTC
                if (model.Dateofexcavation != null)
                {
                    model.Dateofexcavation = model.Dateofexcavation.Value.ToUniversalTime();
                }

                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Add");
        }

        [Authorize(Roles="SuperAdmin, TA")]
        [HttpGet]
        public IActionResult Edit(long id)
        {
            ViewBag.burialmain = repo.burialmain.ToList();
            var record = repo.burialmain.Single(x => x.Id == id);

            //Burialmain burialmain = repo.burialmain.FirstOrDefault(x => x.Id == id);

            return View("Add", record);
        }

        [Authorize(Roles="SuperAdmin, TA")]
        [HttpPost]
        public IActionResult Edit(Burialmain model)
        {
            if (ModelState.IsValid)
            {
                repo.Update(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else { return RedirectToAction("Edit", model.Id); }
        }

        [Authorize(Roles="SuperAdmin, TA")]
        [HttpGet]
        public IActionResult Delete(long id)
        {
            var record = repo.burialmain.Single(x => x.Id == id);

            return View("Delete", record);
        }
        
        [Authorize(Roles="SuperAdmin, TA")]
        [HttpPost]
        public IActionResult Delete(Burialmain model )
        {

            repo.Remove(model);
            repo.SaveChanges();
            return RedirectToAction("BurialSummary");
        }


        //Database Add Functionality

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpGet]
        public IActionResult Analysis()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpPost]
        public IActionResult Analysis(Analysis model)
        {
            if (ModelState.IsValid)
            {
                //change datetime to UTC
                if (model.Date != null)
                {
                    model.Date = model.Date.Value.ToUniversalTime();
                }

                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpGet]
        public IActionResult Artifactfagelgamousregister()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, TA")]
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

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpGet]
        public IActionResult Artifactkomaushimregister()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpPost]
        public IActionResult Artifactkomaushimregister(Artifactkomaushimregister model)
        {
            if (ModelState.IsValid)
            {
                //change datetime to UTC
                if (model.Entrydate != null)
                {
                    model.Entrydate = model.Entrydate.Value.ToUniversalTime();
                }

                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpGet]
        public IActionResult Biological()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpPost]
        public IActionResult Biological(Biological model)
        {
            if (ModelState.IsValid)
            {
                //change datetime to UTC
                if (model.Date != null)
                {
                    model.Date = model.Date.Value.ToUniversalTime();
                }

                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpGet]
        public IActionResult Bodyanalysischart()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, TA")]
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

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpGet]
        public IActionResult Book()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, TA")]
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

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpGet]
        public IActionResult C14()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, TA")]
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

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpGet]
        public IActionResult Color()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, TA")]
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

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpGet]
        public IActionResult Cranium()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, TA")]
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

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpGet]
        public IActionResult Decoration()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, TA")]
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

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpGet]
        public IActionResult Dimension()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, TA")]
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

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpGet]
        public IActionResult Newsarticle()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, TA")]
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

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpGet]
        public IActionResult Photodatum()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, TA")]
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

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpGet]
        public IActionResult Photoform()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpPost]
        public IActionResult Photoform(Photoform model)
        {
            if (ModelState.IsValid)
            {
                //change datetime to UTC
                if (model.Photodate != null)
                {
                    model.Photodate = model.Photodate.Value.ToUniversalTime();
                }

                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpGet]
        public IActionResult Structure()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, TA")]
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

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpGet]
        public IActionResult Teammember()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, TA")]
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

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpGet]
        public IActionResult Textile()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpPost]
        public IActionResult Textile(Textile model)
        {
            if (ModelState.IsValid)
            {
                //change datetime to UTC
                if (model.Sampledate != null)
                {
                    model.Sampledate = model.Sampledate.Value.ToUniversalTime();
                }

                //change datetime to UTC
                if (model.Photographeddate != null)
                {
                    model.Photographeddate = model.Photographeddate.Value.ToUniversalTime();
                }

                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Tables");
        }

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpGet]
        public IActionResult Textilefunction()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, TA")]
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

        [Authorize(Roles = "SuperAdmin, TA")]
        [HttpGet]
        public IActionResult Yarnmanipulation()
        {
            return View();
        }

        [Authorize(Roles = "SuperAdmin, TA")]
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
    }
}