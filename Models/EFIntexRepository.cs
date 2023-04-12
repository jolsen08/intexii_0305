using IntexII_0305.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexII_0305.Models
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
    }
}
