using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parish.Infrastructure;
using System;
using System.Linq;
using System.Collections.Generic;
using Parish.Domain;
using System.ServiceModel;

namespace Parish.Tests
{
    /// <summary>
    /// Test class for ParishService
    /// </summary>
    [TestClass]
    public class ParishUnitTests
    {
        private ParishService _service;
        private ParishContext _context;
        private List<ParishModel> _testModels = new List<ParishModel>()

        {   new ParishModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Test Parish",
                    Street = "Test Street",
                    City = "Test City",
                },
            new ParishModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Test Parish 2",
                    Street = "Test Street 2",
                    City = "Test City 2",
                },
            new ParishModel()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Test Parish 3",
                    Street = "Test Street 3",
                    City = "Test City 3",
                }
        };

        /// <summary>
        /// Initialize test context
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _context = new ParishContext();
            _service = new ParishService();
        }

        [TestMethod]
        public void GetAllParishes_ShouldReturnAllParishes()
        {
            int parishesCount = _context.Parishes.ToList().Count;
            Assert.AreEqual(parishesCount, _service.GetParishes().Count);
        }

        [TestMethod]
        public void AddParish_ShouldAddNewParish()
        {
            var parish = _testModels.First();
            _service.AddParish(parish);

            var retrievedParish = _context.Parishes.FirstOrDefault(x => x.Id == parish.Id);
            Assert.IsNotNull(retrievedParish);
            Assert.AreEqual(parish.Name, retrievedParish.Name);
        }

        [TestMethod]
        public void GetParish_ShouldReturnCorrectParish()
        {
            var parish = _testModels[1];
            _context.Parishes.Add(parish);
            _context.SaveChanges();

            var retrievedParish = _service.GetParish(parish.Id.ToString());
            Assert.IsNotNull(retrievedParish);
            Assert.AreEqual(parish.Name, retrievedParish.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void AddParish_ShouldThrowException_WhenParishAlreadyExists()
        {
            var parish = _testModels.Last();
            _context.Parishes.Add(parish);
            _context.SaveChanges();

            _service.AddParish(parish);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void GetParish_ShouldThrowException_WhenParishNotFound()
        {
            _service.GetParish(Guid.NewGuid().ToString());
        }
    }
}
