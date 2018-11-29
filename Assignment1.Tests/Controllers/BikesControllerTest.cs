using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment1.Controllers;
using Moq;
using Assignment1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Assignment1.Tests.Controllers
{
    [TestClass]
    public class BikesControllerTest
    {
        BikesController controller;
        Mock<IBikesMock> mock;
        List<Bike> bikes;
        Bike bike;
        [TestInitialize]
        public void TestInitalize()
        {

            mock = new Mock<IBikesMock>();

            bikes = new List<Bike>
            {
                new Bike { Bikes = 100, Bike1 = "BMW", Bike2 = "Yamaha",
                    }
            };
            mock.Setup(m => m.Bikes).Returns(bikes.AsQueryable());
            controller = new BikesController(mock.Object);

        }
        [TestMethod]
        public void IndexLoadsView()
        {
            //  BikesController controller = new BikesController();

            // act
            ViewResult result = controller.Index() as ViewResult;

            // assert
            Assert.IsNotNull(result.ViewName);
        }

        [TestMethod]
        public void IndexReturnsBikes()
        {
            // act
            var result = (List<Bike>)((ViewResult)controller.Index()).Model;

            // assert
            CollectionAssert.AreEqual(bikes, result);
        }


        [TestMethod]
        public void DetailsNoIdLoadsError()
        {
            // act
            ViewResult result = (ViewResult)controller.Details(null);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DetailsInvalidIdLoadsError()
        {
            // act
            ViewResult result = (ViewResult)controller.Details(734);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DetailsValidIdLoadsBike()
        {
            // act
            Bike result = (Bike)((ViewResult)controller.Details(100)).Model;

            // assert
            Assert.AreEqual(bikes[0], result);
        }



        [TestMethod]
        public void EditNoIdLoadsError()
        {
            // arrange
            int? id = null;

            // act 
            ViewResult result = (ViewResult)controller.Edit(id);

            // assert 
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void EditIdIsValidLoadsBike()
        {
            // act
            Bike result = (Bike)((ViewResult)controller.Edit(100)).Model;

            // assert 
            Assert.AreEqual(bikes[0], result);
        }

        [TestMethod]
        public void EditInvalidIdLoadsError()
        {
            // act 
            ViewResult result = (ViewResult)controller.Edit(799);

            // assert 
            Assert.AreEqual("Error", result.ViewName);
        }




        [TestMethod]
        public void EditValidIdLoadsView()
        {
            // act 
            ViewResult result = (ViewResult)controller.Edit(100);

            // assert
            Assert.AreEqual("Edit", result.ViewName);
        }






        [TestMethod]
        public void EditModelIsValidReturnView()
        {
            //act
            RedirectToRouteResult result = (RedirectToRouteResult)controller.Edit(bikes[0]);

            //Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [TestMethod]
        public void EditCheckViewBagValuesBike()
        {
            //act arrange 
            controller.ModelState.AddModelError("Error", "Error thing");
            Bike testBike = new Bike { Bikes = 1 };
            ViewResult result = (ViewResult)controller.Edit(testBike);

            //assert
            Assert.IsNotNull(result.ViewBag.Bikes);
        }
        [TestMethod]
        public void EditModelInvalidReturnView()
        {
            controller.ModelState.AddModelError("Error", "Error thing");
            Bike testBike = new Bike { Bikes = 1 };

            // act
            ViewResult result = (ViewResult)controller.Edit(testBike);

            // assert
            Assert.AreEqual("Edit", result.ViewName);
        }



       

        [TestMethod]
        public void CreateLoadsView()
        {
            //act
            var actual = controller.Create();

            //assert
            Assert.IsNotNull( actual);
        }

        [TestMethod]
        public void CreateBikesViewBagNotNull()
        {
            //act
            var result = ((ViewResult)controller.Create());

            //assert
            Assert.IsNotNull(result.ViewBag.Bikes);
        }



       

        [TestMethod]
        public void DeleteNoIdLoadsError()
        {
            // act
            ViewResult result = (ViewResult)controller.Delete(null);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteInvalidIdLoadsError()
        {
            // act
            ViewResult result = (ViewResult)controller.Delete(543);

            // assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteValidIdLoadsView()
        {
            // act
            ViewResult result = (ViewResult)controller.Delete(100);

            // assert
            Assert.AreEqual("Delete", result.ViewName);
        }

        [TestMethod]
        public void DeleteValidIdLoadsBike()
        {
            Bike result = (Bike)((ViewResult)controller.Delete(100)).Model;

            // assert
            Assert.AreEqual(bikes[0], result);
        }



        [TestMethod]
        public void DeleteConfirmedIdLoadsError()
        {
            //Act
            ViewResult result = (ViewResult)controller.DeleteConfirmed(-3);

            //Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteConfirmedNoIdLoadsError()
        {
            //Act
            ViewResult result = (ViewResult)controller.DeleteConfirmed(0);

            //Assert
            Assert.AreEqual("Error", result.ViewName);
        }

        [TestMethod]
        public void DeleteConfirmedDataSuccessful()
        {
            //Act
            RedirectToRouteResult result = (RedirectToRouteResult)controller.DeleteConfirmed(100);

            //Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
    }
}