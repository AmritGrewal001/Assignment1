using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Models
{
   public interface IBikesMock
    {
         
        IQueryable<Bike> Bikes { get; }
        
        Bike Save(Bike bike);
        void Delete(Bike bike);
    }
}

