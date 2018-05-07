// Jiwon Nam
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http.Results;
using System.Net;
using HealthCatalystHomeTest.Controllers;
using HealthCatalystHomeTest.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace HealthCatalystHomeTest.Tests
{
    /// <summary>
    /// Test class for Search Controller and fake database set
    /// </summary>
    [TestClass]
    public class ControllerTest
    {
        // add test
        /// <summary>
        /// simple add test
        /// </summary>
        [TestMethod]
        public void SimpleAddTest1()
        {
            var controller = new SearchController(new TestHealthCatalystHomeTestContext());

            var testUsers = GetUserSample();

            var result = controller.Add(testUsers[0]) as OkNegotiatedContentResult<User>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.LastName, testUsers[0].LastName);
            Assert.AreEqual(result.Content.FirstName, testUsers[0].FirstName);
            Assert.AreEqual(result.Content.Age, testUsers[0].Age);
            Assert.AreEqual(result.Content.Interests, testUsers[0].Interests);
        }

        /// <summary>
        /// simple add test
        /// </summary>
        [TestMethod]
        public void SimpleAddTest2()
        {
            var controller = new SearchController(new TestHealthCatalystHomeTestContext());

            var testUsers = GetUserSample();

            var result = controller.Add(testUsers[1]) as OkNegotiatedContentResult<User>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.LastName, testUsers[1].LastName);
            Assert.AreEqual(result.Content.FirstName, testUsers[1].FirstName);
            Assert.AreEqual(result.Content.Age, testUsers[1].Age);
            Assert.AreEqual(result.Content.Interests, testUsers[1].Interests);
        }

        /// <summary>
        /// simple add test
        /// </summary>
        [TestMethod]
        public void SimpleAddTes3()
        {
            var controller = new SearchController(new TestHealthCatalystHomeTestContext());

            var testUsers = GetUserSample();

            var result = controller.Add(testUsers[2]) as OkNegotiatedContentResult<User>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.LastName, testUsers[2].LastName);
            Assert.AreEqual(result.Content.FirstName, testUsers[2].FirstName);
            Assert.AreEqual(result.Content.Age, testUsers[2].Age);
            Assert.AreEqual(result.Content.Interests, testUsers[2].Interests);
        }

        /// <summary>
        /// simple add test
        /// </summary>
        [TestMethod]
        public void SimpleAddTest4()
        {
            var controller = new SearchController(new TestHealthCatalystHomeTestContext());

            var testUsers = GetUserSample();

            var result = controller.Add(testUsers[3]) as OkNegotiatedContentResult<User>;

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Content.LastName, testUsers[3].LastName);
            Assert.AreEqual(result.Content.FirstName, testUsers[3].FirstName);
            Assert.AreEqual(result.Content.Age, testUsers[3].Age);
            Assert.AreEqual(result.Content.Interests, testUsers[3].Interests);
        }

        /// <summary>
        /// large number set add method test
        /// </summary>
        [TestMethod]
        public void Add1()
        {
            var controller = new SearchController(new TestHealthCatalystHomeTestContext());

            int setCount = 10000;
            var testUsers = LargeUserSet(setCount);

            for(int i = 0; i < setCount; i++)
            {
                var result = controller.Add(testUsers[i]) as OkNegotiatedContentResult<User>;
                Assert.IsNotNull(result);
                Assert.AreEqual("last name " + i, testUsers[i].LastName);
                Assert.AreEqual("first name " + i, testUsers[i].FirstName);
                Assert.AreEqual(i, testUsers[i].Age);
                Assert.AreEqual("" + i + "th test result", testUsers[i].Interests);
            }   
        }

        // search test
        /// <summary>
        /// simple search test
        /// </summary>
        [TestMethod]
        public void SimpleSearchTest1()
        {
            var context = new TestHealthCatalystHomeTestContext();
            var tempClients = GetUserSample();
            context.Users.Add(tempClients[0]);
            var controller = new SearchController(context);
            // checking first name search
            var result = controller.Search("User1") as OkNegotiatedContentResult<List<User>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.Count);
            Assert.AreEqual(tempClients[0].LastName, result.Content[0].LastName);
            Assert.AreEqual(tempClients[0].FirstName, result.Content[0].FirstName);
            Assert.AreEqual(tempClients[0].Age, result.Content[0].Age);
            Assert.AreEqual(tempClients[0].Interests, result.Content[0].Interests);
            // checking last name search
            var result2 = controller.Search("First") as OkNegotiatedContentResult<List<User>>;
            Assert.IsNotNull(result);
            Assert.AreEqual(tempClients[0].LastName, result2.Content[0].LastName);
            Assert.AreEqual(tempClients[0].FirstName, result2.Content[0].FirstName);
            Assert.AreEqual(tempClients[0].Age, result2.Content[0].Age);
            Assert.AreEqual(tempClients[0].Interests, result2.Content[0].Interests);
        }

        /// <summary>
        /// simple search test
        /// </summary>
        [TestMethod]
        public void SimpleSearchTest2()
        {
            var context = new TestHealthCatalystHomeTestContext();
            var tempClients = GetUserSample();
            context.Users.Add(tempClients[1]);
            var controller = new SearchController(context);
            // checking first name search
            var result = controller.Search("User2") as OkNegotiatedContentResult<List<User>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.Count);
            Assert.AreEqual(tempClients[1].LastName, result.Content[0].LastName);
            Assert.AreEqual(tempClients[1].FirstName, result.Content[0].FirstName);
            Assert.AreEqual(tempClients[1].Age, result.Content[0].Age);
            Assert.AreEqual(tempClients[1].Interests, result.Content[0].Interests);
            // checking last name search
            var result2 = controller.Search("Second") as OkNegotiatedContentResult<List<User>>;
            Assert.IsNotNull(result);
            Assert.AreEqual(tempClients[1].LastName, result2.Content[0].LastName);
            Assert.AreEqual(tempClients[1].FirstName, result2.Content[0].FirstName);
            Assert.AreEqual(tempClients[1].Age, result2.Content[0].Age);
            Assert.AreEqual(tempClients[1].Interests, result2.Content[0].Interests);
        }

        /// <summary>
        /// simple search test
        /// </summary>
        [TestMethod]
        public void SimpleSearchTest3()
        {
            var context = new TestHealthCatalystHomeTestContext();
            var tempClients = GetUserSample();
            context.Users.Add(tempClients[2]);
            var controller = new SearchController(context);
            // checking first name search
            var result = controller.Search("User3") as OkNegotiatedContentResult<List<User>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.Count);
            Assert.AreEqual(tempClients[2].LastName, result.Content[0].LastName);
            Assert.AreEqual(tempClients[2].FirstName, result.Content[0].FirstName);
            Assert.AreEqual(tempClients[2].Age, result.Content[0].Age);
            Assert.AreEqual(tempClients[2].Interests, result.Content[0].Interests);
            // checking last name search
            var result2 = controller.Search("Third") as OkNegotiatedContentResult<List<User>>;
            Assert.IsNotNull(result);
            Assert.AreEqual(tempClients[2].LastName, result2.Content[0].LastName);
            Assert.AreEqual(tempClients[2].FirstName, result2.Content[0].FirstName);
            Assert.AreEqual(tempClients[2].Age, result2.Content[0].Age);
            Assert.AreEqual(tempClients[2].Interests, result2.Content[0].Interests);
        }

        /// <summary>
        /// simple search test
        /// </summary>
        [TestMethod]
        public void SimpleSearchTest4()
        {
            var context = new TestHealthCatalystHomeTestContext();
            var tempClients = GetUserSample();
            context.Users.Add(tempClients[3]);
            var controller = new SearchController(context);
            // checking first name search
            var result = controller.Search("User4") as OkNegotiatedContentResult<List<User>>;

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content.Count);
            Assert.AreEqual(tempClients[3].LastName, result.Content[0].LastName);
            Assert.AreEqual(tempClients[3].FirstName, result.Content[0].FirstName);
            Assert.AreEqual(tempClients[3].Age, result.Content[0].Age);
            Assert.AreEqual(tempClients[3].Interests, result.Content[0].Interests);
            // checking last name search
            var result2 = controller.Search("Fourth") as OkNegotiatedContentResult<List<User>>;
            Assert.IsNotNull(result);
            Assert.AreEqual(tempClients[3].LastName, result2.Content[0].LastName);
            Assert.AreEqual(tempClients[3].FirstName, result2.Content[0].FirstName);
            Assert.AreEqual(tempClients[3].Age, result2.Content[0].Age);
            Assert.AreEqual(tempClients[3].Interests, result2.Content[0].Interests);
        }

        /// <summary>
        /// single data clear test
        /// </summary>
        [TestMethod]
        public void ClearTest1()
        {
            var context = new TestHealthCatalystHomeTestContext();
            var user = GetUserSample();

            context.Users.Add(user[0]);

            var controller = new SearchController(context);
            IHttpActionResult result = controller.Clear();

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        /// <summary>
        /// large set clear test
        /// </summary>
        [TestMethod]
        public void ClearTest2()
        {
            var context = new TestHealthCatalystHomeTestContext();
            var user = LargeUserSet(100000);

            for (int i = 0; i < GetUserSample().Count; i++)
                context.Users.Add(user[i]);

            var controller = new SearchController(context);
            IHttpActionResult result = controller.Clear();

            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        /// <summary>
        /// large set search test with last name
        /// </summary>
        [TestMethod]
        public void SearchTest1()
        {
            var context = new TestHealthCatalystHomeTestContext();
            var tempClients = GetUserSample();
            int setCount = 10000;
            var largeUserSet = LargeUserSet(setCount);

            for (int i = 0; i < setCount; i++)
                context.Users.Add(largeUserSet[i]);            

            var controller = new SearchController(context);

            for(int i = 0; i < setCount; i++)
            {
                var result = controller.Search("last name " + i) as OkNegotiatedContentResult<List<User>>;
                Assert.IsNotNull(result);
                Assert.AreEqual(1, result.Content.Count);
                Assert.AreEqual("last name " + i, result.Content[0].LastName);
                Assert.AreEqual("first name " + i, result.Content[0].FirstName);
                Assert.AreEqual(i, result.Content[0].Age);
                Assert.AreEqual("" + i + "th test result", result.Content[0].Interests);
            }                     
        }

        /// <summary>
        /// large set search test with first name
        /// </summary>
        [TestMethod]
        public void SearchTest2()
        {
            var context = new TestHealthCatalystHomeTestContext();
            var tempClients = GetUserSample();
            int setCount = 10000;
            var largeUserSet = LargeUserSet(setCount);

            for (int i = 0; i < setCount; i++)
                context.Users.Add(largeUserSet[i]);

            var controller = new SearchController(context);

            for (int i = 0; i < setCount; i++)
            {
                var result = controller.Search("first name " + i) as OkNegotiatedContentResult<List<User>>;
                Assert.IsNotNull(result);
                Assert.AreEqual(1, result.Content.Count);
                Assert.AreEqual("last name " + i, result.Content[0].LastName);
                Assert.AreEqual("first name " + i, result.Content[0].FirstName);
                Assert.AreEqual(i, result.Content[0].Age);
                Assert.AreEqual("" + i + "th test result", result.Content[0].Interests);
            }
        }

        /// <summary>
        /// test for search with duplicated last name
        /// </summary>
        [TestMethod]
        public void SearchTest3()
        {
            var context = new TestHealthCatalystHomeTestContext();
            var tempClients = GetUserSample();
            int setCount = 10000;
            var dupleSet = DuplicateNameSet(setCount);

            for (int i = 0; i < setCount; i++)
                context.Users.Add(dupleSet[i]);

            var controller = new SearchController(context);

            for (int i = 0; i < 4; i++)
            {
                var result = controller.Search("last name " + i) as OkNegotiatedContentResult<List<User>>;
                Assert.IsNotNull(result);
                Assert.AreEqual(setCount / 5, result.Content.Count);
            
                for(int j = 0; j < result.Content.Count; j++)
                {
                    Assert.AreEqual("first name " + (j * 5 + i), result.Content[j].FirstName);
                }
            }
        }

        /// <summary>
        /// helper method to generate duplicated last name set
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private List<User> DuplicateNameSet(int num)
        {
            var dupleSet = new List<User>();

            for(int i = 0; i< num; i++)
            {
                dupleSet.Add(new User
                {
                    LastName = "last name " + (i % 5),
                    FirstName = "first name " + i,
                    Age = i,
                    Interests = "" + (i % 5) + "same results"
                });
            }
            return dupleSet;
        }

        /// <summary>
        /// helper method to generate large number of user set
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private List<User> LargeUserSet(int num)
        {
            var largeSet = new List<User>();

            for(int i = 0; i < num; i++)
            {
                largeSet.Add(new User
                {
                    LastName = "last name " + i,
                    FirstName = "first name " + i,
                    Age = i,
                    Interests = "" + i + "th test result"
                });
            }

            return largeSet;
        }

        /// <summary>
        /// helper method to generate small number of users
        /// </summary>
        /// <returns></returns>
        private List<User> GetUserSample()
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
