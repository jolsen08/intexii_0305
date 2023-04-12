using IntexII_0305.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexII_0305.Components
{
    public class TypesViewComponent : ViewComponent
    {
        //Loading up a dataset
        private IIntexRepository repo { get; set; }
        public TypesViewComponent (IIntexRepository temp)
        {
            repo = temp;
        }

        //Pulling the distinct category types and returning it to a view
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["burialArea"];

            var types = repo.burialmain
                .Select(x => x.Area)
                .Distinct()
                .OrderBy(x => x);
            return View(types);
        }
    }
}
