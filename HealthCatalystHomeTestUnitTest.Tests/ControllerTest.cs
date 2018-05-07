﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            var testUsers = GetTestClients();
            var controller = new SearchController();

            controller.Clear();

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