﻿using GraphQLDemo.API.Models;
using GraphQLDemo.API.Schema.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.API.Schema.Mutations
{
    public class CourseResult
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public string InstructorId { get; set; }
    }
}
