using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment1.Models
{
    public class EFBikes : IBikesMock
    {
        private Model1 db = new Model1();

        public IQueryable<Bike> Bikes
        {
            get
            {
                return db.Bikes;
            }
        }

        public IQueryable<Bike> Bikess
        {
            get { return db.Bikes; }
        }

        public void Delete(Bike bike)
        {
            db.Bikes.Remove(bike);
            db.SaveChanges();
        }

        public Bike Save(Bike bike)
        {
            if (bike.Bikes == 0)
            {
                // insert
                db.Bikes.Add(bike);
            }
            else
            {
                // update
                db.Entry(bike).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return bike;
        }
    }
}

        

        
       
    
