using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace HealthCtalystHomeTestUnitTest
{
    [TestClass]
    public class HealthCatalystHomeTestUnitTest
    {
        /// <summary>
        /// Creates an HttpClient for communicating with the server.
        /// </summary>
        private static HttpClient CreateClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:54266/");
            return client;
        }

        /// <summary>
        /// Helper for serializaing JSON.
        /// </summary>
        private static StringContent Serialize(dynamic json)
        {
            return new StringContent(JsonConvert.SerializeObject(json), Encoding.UTF8, "application/json");
        }

        private async Task<dynamic> Search(string name, HttpStatusCode status=0)
        {
            using (HttpClient client = CreateClient())
            {
                HttpResponseMessage response = await client.PostAsync("search", Serialize(name));
                if (status != 0) Assert.AreEqual(status, response.StatusCode);
                if (response.IsSuccessStatusCode)
                {
                    String result = await response.Content.ReadAsStringAsync();
                    dynamic user = JsonConvert.DeserializeObject(result);
                    return user;
                }
                else
                {
                    return null;
                }
            }
                
        }

        private async Task GenerateClients(HttpStatusCode status = 0)
        {
            using (HttpClient client = CreateClient())
            {
                HttpResponseMessage response = await client.PostAsync("autogen", null);
                if (status != 0) Assert.AreEqual(status, response.StatusCode);
            }
        }

        private async Task Clear(HttpStatusCode status = 0)
        {
            using (HttpClient client = CreateClient())
            {
                HttpResponseMessage response = await client.PostAsync("clear", null);
                if (status != 0) Assert.AreEqual(status, response.StatusCode);
            }
        }                

        [TestMethod]
        public void SimpleTest1()
        {
            Clear(HttpStatusCode.OK).Wait();

            GenerateClients(HttpStatusCode.OK).Wait();
        }

        [TestMethod]
        public void SimpleTest2()
        {
            Clear(HttpStatusCode.OK).Wait();

            GenerateClients(HttpStatusCode.OK).Wait();


        }

        [TestMethod]
        public void SimpleTest3()
        {
            Clear(HttpStatusCode.OK).Wait();

            GenerateClients(HttpStatusCode.OK).Wait();
        }

        [TestMethod]
        public void SimpleTest4()
        {
            Clear(HttpStatusCode.OK).Wait();

            GenerateClients(HttpStatusCode.OK).Wait();
        }

        [TestMethod]
        public void SimpleTest5()
        {
            Clear(HttpStatusCode.OK).Wait();

            GenerateClients(HttpStatusCode.OK).Wait();
        }
    }
}
