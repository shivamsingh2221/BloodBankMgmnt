using NUnit.Framework;
using DonorAPI.Models;
using DonorAPI.Controllers;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Microsoft.EntityFrameworkCore;
using DonorAPI.Repository;

namespace DonorUnitTesting
{
    public class Tests
    {
        public List<Donor> obj1 = new List<Donor>();
        

        //Simulation_dbContext xx = new Simulation_dbContext();
        // obj2 = new DonoresController();

        IQueryable<Donor> cdata;
        Mock<DbSet<Donor>> mockSet;
        Mock<inventoryContext> Donorcontextmock;
        [SetUp]
        public void Setup()
        {

            obj1 = new List<Donor>()
            {
                new Donor{ Name="Shivam" , Address="LKO" , BloodGroup ="AB+", Id=1, PhoneNo=100}
            };
            cdata = obj1.AsQueryable();
            mockSet = new Mock<DbSet<Donor>>();
            mockSet.As<IQueryable<Donor>>().Setup(m => m.Provider).Returns(cdata.Provider);
            mockSet.As<IQueryable<Donor>>().Setup(m => m.Expression).Returns(cdata.Expression);
            mockSet.As<IQueryable<Donor>>().Setup(m => m.ElementType).Returns(cdata.ElementType);
            mockSet.As<IQueryable<Donor>>().Setup(m => m.GetEnumerator()).Returns(cdata.GetEnumerator());
            var p = new DbContextOptions<inventoryContext>();
            Donorcontextmock = new Mock<inventoryContext>(p);
            Donorcontextmock.Setup(x => x.Donor).Returns(mockSet.Object);

        }




        [Test]
        public void Test1()
        {
            var x = new DonorAPIRespository(Donorcontextmock.Object);
            var y = x.GetDonors(1);
            Assert.AreEqual(1, y.Count());
        }



        [Test]
        public void Test2()
        {
            var x = new DonorAPIRespository(Donorcontextmock.Object);
            var y = x.DeleteDonors(1);
            Assert.IsNotNull(y);
        }

    }
}