using IntexII_0305.Models;
using IntexII_0305.Models.ViewModels;
using IntexII0305.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
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
        //private IntexContext repo { get; set; }
        public TypesViewComponent (IIntexRepository temp)
        {
            repo = temp;
        }

        //Pulling the distinct category types and returning it to a view
        public IViewComponentResult Invoke()
        {            
            var filtersViewModel = new FiltersViewModel
            {
                Sexes = repo.burialmain
                                .Select(x => x.Sex)
                                .Where(x => (x != null) && (x != ""))
                                .Distinct()
                                .OrderBy(x => x),
                AgesAtDeath = repo.burialmain
                                .Select(x => x.Ageatdeath)
                                .Where(x => x != null)
                                .Distinct()
                                .OrderBy(x => x),
                Depths = repo.burialmain
                                .Select(x => x.Depth)
                                .Where(x => x != null)
                                .Distinct()
                                .OrderBy(x => x),
                HeadDirections = repo.burialmain
                                .Select(x => x.Headdirection)
                                .Where(x => x != null)
                                .Distinct()
                                .OrderBy(x => x),
                Wrappings = repo.burialmain
                                .Select(x => x.Wrapping)
                                .Where(x => x != null)
                                .Distinct()
                                .OrderBy(x => x),
                HairColors = repo.burialmain
                                .Select(x => x.Haircolor)
                                .Where(x => x != null)
                                .Distinct()
                                .OrderBy(x => x),
            };
            return View("Default", filtersViewModel);
        }
    }
}
