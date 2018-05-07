using HealthCatalystHomeTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCatalystHomeTest.Tests
{
    class TestUserDbSet : TestDbSet<User>
    {
        public override User Find(params object[] keyValues)
        {
            return this.SingleOrDefault
                (user => (user.FirstName == (string)keyValues.Single() || user.LastName == (string)keyValues.Single()));
        }
    }
}
