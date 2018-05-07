using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HealthCatalystHomeTest.Models;

namespace HealthCatalystHomeTest.Controllers
{
    public class SearchControllerTester : ApiController
    {
        private IHealthCatalystHomeTestContext db = new HealthCatalystHomeTestContext();

        public SearchControllerTester()
        { }

        public SearchControllerTester(IHealthCatalystHomeTestContext context)
        {
            db = context;
        }

        // search
        public IHttpActionResult Search(string name)
        {
            User user = db.Users.Find(name);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        public IHttpActionResult Add(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        public IHttpActionResult Clear()
        {
            var all = from c in db.Users select c;
            db.Users.RemoveRange(all);
            db.SaveChanges();

            if (db.Users.Count() != 0)
                return NotFound();

            return Ok();
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}