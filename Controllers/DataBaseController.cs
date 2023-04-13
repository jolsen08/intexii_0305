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
    }
}
