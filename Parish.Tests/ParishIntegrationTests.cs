using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Parish.Domain;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Parish.Infrastructure;
using System.Linq;

namespace Parish.Tests
{
    /// <summary>
    /// Test class for ParishService
    /// </summary>
    [TestClass]
    public class ParishIntegrationTests
    {
        private HttpClient _client;
        private ParishContext _context;

        [TestInitialize]
        public void Initialize()
        {
            _client = new HttpClient { BaseAddress = new Uri("http://localhost/ParishService/ParishService.svc/v1/") };
            _context = new ParishContext();
        }

        [TestMethod]
        public async Task GetParishes_ShouldReturnAllParishes()
        {
            var response = await _client.GetAsync("parishes");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var parishes = JsonConvert.DeserializeObject<List<ParishModel>>(content);

            var parishCount = _context.Parishes.ToList().Count;

            Assert.IsNotNull(parishes);
            Assert.AreEqual(parishCount, parishes.Count);
        }

        [TestMethod]
        public async Task GetParish_ShouldReturnCorrectParish()
        {
            var id = "ae460af8-2ce6-4d14-b286-79509643eef0".ToUpper(); 

            var response = await _client.GetAsync($"parishes/{id}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var parish = JsonConvert.DeserializeObject<ParishModel>(content);

            Assert.IsNotNull(parish);
            Assert.AreEqual(id, parish.Id.ToString());
        }

        [TestMethod]
        public async Task AddParish_ShouldAddNewParish()
        {
            var parish = new ParishModel { Id = Guid.NewGuid().ToString(), Name = "Test" , City = "Test", Street = "Test"};
            var json = JsonConvert.SerializeObject(parish);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("parishes", content);
            response.EnsureSuccessStatusCode();

            var addedParish = _context.Parishes.FirstOrDefault(x => x.Id == parish.Id);
            Assert.AreEqual(parish.Id, addedParish.Id);
        }
    }
}
