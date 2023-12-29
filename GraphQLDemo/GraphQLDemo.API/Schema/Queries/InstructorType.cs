using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;

namespace GraphQLDemo.API.Schema.Queries
{
    public class InstructorType
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [GraphQLName("money")]
        public double Salary { get; set; }
    }
}
