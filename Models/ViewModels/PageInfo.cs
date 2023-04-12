using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexII_0305.Models.ViewModels
{
    public class PageInfo
    {
        //Establishing these variables that will hold important information which will be used in the paginationTagHelper
        //page
        public int TotalNumBurials { get; set; }
        public int BurialsPerPage { get; set; }
        public int CurrentPage { get; set; }

        //Calculate total pages
        public int TotalPages => (int) Math.Ceiling((double) TotalNumBurials / BurialsPerPage);
    }
}
