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

      
        public IActionResult BurialSummary(string burialArea, int pageNum = 1)
        {
            int pageSize = 20;

            var x = new RecordsViewModel
            {
                burialmain = repo.burialmain
                .Where(c => c.Area == burialArea || burialArea == null)
                .OrderBy(t => t.Id)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBurials = (burialArea == null ?
                        repo.burialmain.Count()
                        : repo.burialmain.Where(x => x.Area == burialArea).Count()),
                    BurialsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View("AllBurialRecords", x);
        }

        public IActionResult RecordManager()
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

            var session = new InferenceSession("C:\\Users\\BYU Rental\\Documents\\IntexII\\IntexII_0305\\model.onnx");

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

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.burialArea = repo.burialmain.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Burialmain model)
        {
            if (ModelState.IsValid)
            {
                repo.Add(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Add");
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
           /* ViewBag.burialArea = repo.burialmain.ToList();
            var record = repo.burialmain.Single(x => x.Id == id);*/

            Burialmain burialmain = repo.burialmain.FirstOrDefault(x => x.Id == id);

            return View("Edit", burialmain);
        }

        [HttpPost]
        public IActionResult Edit(Burialmain model)
        {
            if (ModelState.IsValid)
            {
                repo.Update(model);
                repo.SaveChanges();
                return RedirectToAction("BurialSummary");
            } // if invalid input
            else return RedirectToAction("Edit", model.Id);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var record = repo.burialmain.Single(x => x.Id == id);
            return View("Delete", record);
        }
        
        [HttpPost]
        public IActionResult Delete(Burialmain model)
        {
            repo.burialmain.Remove(model);
            repo.SaveChanges();
            return RedirectToAction("BurialSummary");
        }
    }
}