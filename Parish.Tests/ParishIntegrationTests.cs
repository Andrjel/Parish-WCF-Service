using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Parish.Domain;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Parish.Tests
{
    /// <summary>
    /// Test class for ParishService
    /// </summary>
    [TestClass]
    public class ParishIntegrationTests
    {
        private HttpClient _client;

        [TestInitialize]
        public void Initialize()
        {
            _client = new HttpClient { BaseAddress = new Uri("http://localhost:8080/ParishService.svc/v1/") };
        }

        [TestMethod]
        public async Task GetParishes_ShouldReturnAllParishes()
        {
            var response = await _client.GetAsync("parishes");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var parishes = JsonConvert.DeserializeObject<List<ParishModel>>(content);

            Assert.IsNotNull(parishes);
            Assert.IsTrue(parishes.Count > 0);
        }

        [TestMethod]
        public async Task GetParish_ShouldReturnCorrectParish()
        {
            var id = "ae460af8-2ce6-4d14-b286-79509643eef0"; 

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
            var parish = new ParishModel { Id = Guid.NewGuid().ToString(), Name = "New Parish" };
            var json = JsonConvert.SerializeObject(parish);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("parishes", content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var createdParish = JsonConvert.DeserializeObject<ParishModel>(responseString);

            Assert.IsNotNull(createdParish);
            Assert.AreEqual(parish.Name, createdParish.Name);
        }
    }
}
