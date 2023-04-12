using IntexII_0305.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntexII_0305.Models
{
    //This interface object creates the IQueryable type object "Books". This class will be referenced in the 
    //EFBookStoreRepository class
    public interface IIntexRepository
    {
        IQueryable<Burialmain> burialmain { get; }
    }
}
