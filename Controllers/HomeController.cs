// using IntexII_0305.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.ML.OnnxRuntime.Tensors;
using Microsoft.ML.OnnxRuntime;


namespace IntexII_0305.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

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

        public IActionResult BurialSummary()
        {
            return View();
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
        public IActionResult HeadDirectionPred(float square_north_south, float body_depth, float south_to_head, float square_east_west, float west_to_head, float west_to_feet, float south_to_feet, string north_south, string east_west, string adult_subadult, string wrapping, string area)
        {
            float north_south_N = 0;
            float east_west_E = 0;
            float east_west_W = 0;
            float adult_subadult_A = 0;
            float adult_subadult_C = 0;
            float wrapping_B = 0;
            float wrapping_H = 0;
            float wrapping_W = 0;
            float area_NE = 0;
            float area_NNW = 0;
            float area_NW = 0;
            float area_SE = 0;
            float area_SW = 0;



            if (north_south == "N")
            {
                north_south_N = 1;
            }
            else
            {
                north_south_N = 0;
            }

            if (east_west == "E")
            {
                east_west_E = 1;
                east_west_W = 0;
            }
            else
            {
                east_west_E = 1;
                east_west_W = 0;
            }

            if (adult_subadult == "A")
            {
                adult_subadult_A = 1;
                adult_subadult_C = 0;
            }
            else
            {
                adult_subadult_A = 1;
                adult_subadult_C = 0;
            }

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



            float[] inputData = { square_north_south, body_depth, south_to_head, square_east_west, west_to_head, west_to_feet, south_to_feet, north_south_N, east_west_E, east_west_W, adult_subadult_A, adult_subadult_C, wrapping_B, wrapping_H, wrapping_W, area_NE, area_NNW, area_NW, area_SE, area_SW };

            var session = new InferenceSession("/model.onnx");
            var tensor = new DenseTensor<float>(inputData, new int[] { 1, inputData.Length });

            //var inputs = new List<headpredictor>
            //{
            //    headpredictor.CreateFromTensor("float_input", tensor)
            //};
            //var results = session.Run(inputs);

            //var output = results.First().AsTensor<string>().ToArray();

            //return View(output);
            return View();

        }

        public IActionResult UnsupervisedFindings()
        {
            return View();
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }

    }
}