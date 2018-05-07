using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;
using System.Net;
using HealthCatalystHomeTest.Controllers;
using HealthCatalystHomeTest.Models;
using System.Collections.Generic;


namespace HealthCatalystHomeTest.Tests
{
    [TestClass]
    public class ControllerTest
    {

        [TestMethod]
        public void ClearTest1()
        {
            var controller = new SearchControllerTester(new TestHealthCatalystHomeTestContext());

            var testUsers = GetTestClients();

            var result = controller.Add(testUsers[0]);

            Assert.IsNotNull(result);

            Assert.AreEqual(testUsers[0], controller.Search("First"));

        }

        private List<User> GetTestClients()
        {
            var testUsers = new List<User>();
            // example users
            testUsers.Add(new User { LastName = "First", FirstName = "User1", Age = 1, Interests = "first user test interest", Image = null});
            testUsers.Add(new User { LastName = "Second", FirstName = "User2", Age = 2, Interests = "Second user test interest", Image = null });            
            testUsers.Add(new User { LastName = "Third", FirstName = "User3", Age = 3, Interests = "Third user test interest", Image = null });
            testUsers.Add(new User { LastName = "Fourth", FirstName = "User4", Age = 4, Interests = "first user test interest", Image = null });

            return testUsers;
        }
    }
}
