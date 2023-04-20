using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoviesCatalogueChallenge.Controllers;
using MoviesCatalogueChallenge.DTOs;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MoviesCatalogueTests.User
{
    [TestClass]
    public class UserApplicationTest
    {
        private HttpClient httpclient;

        public UserApplicationTest()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            httpclient = webAppFactory.CreateClient();
        }

        [TestMethod]
        public async Task Post_ValidUser_ReturnsOk()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpclient = webAppFactory.CreateClient();
            // Arrange
            var user = new UserCreateDTO
            {
                Email = "test2@example.com",
                Password = "P@ssw0rd",
                RoleId = 2
            };
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            // Act
            var response = await httpclient.PostAsync("/api/Users", content);
            var stringResult = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.AreEqual("Successefully Created!", stringResult);
        }

        [TestMethod]
        public async Task Post_InvalidUser_ReturnsBadRequest()
        {
            // Arrange
            var user = new UserCreateDTO
            {
                Email = "test@example.com",
                Password = "1234",
                RoleId = 1
            };
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            // Act
            var response = await httpclient.PostAsync("/api/Users", content);

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task Post_DuplicateEmail_ReturnsBadRequest()
        {
            // Arrange
            var user = new UserCreateDTO
            {
                Email = "test@example.com",
                Password = "P@ssw0rd",
                RoleId = 1
            };
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            // Act
            var response = await httpclient.PostAsync("/api/Users", content);

            // Assert
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public async Task Post_ValidCredentials_ReturnsToken()
        {
            // Arrange
            HttpContent content = null!;

            // Act
            var response = await httpclient.PostAsync("/api/Users/authenticate?Email=admin@admin.com&Pass=admin", content);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            
        }

        [TestMethod]
        public async Task Post_InvalidCredentials_ReturnsUnauthorized()
        {
            // Arrange
            HttpContent content = null!;

            // Act
            var response = await httpclient.PostAsync("/api/Users/authenticate?Email=admin@example.com&Pass=wrong_password", content);

            // Assert
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
