using GraphQLDemo.API.DataLoaders;
using GraphQLDemo.API.DTOs;
using GraphQLDemo.API.Models;
using GraphQLDemo.API.Services.Instructors;
using HotChocolate;
using HotChocolate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQLDemo.API.Schema.Queries
{
    public class CourseType
    {
        [GraphQLNonNullType]
        public string Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }

        [IsProjected(true)]
        public string InstructorId { get; set; }

        public async Task<InstructorType> Instructor([Service] InstructorDataLoader instructorDataLoader)
        {
            if(InstructorId == null) return null;
            
            InstructorDTO instructorDTO = await instructorDataLoader.LoadAsync(InstructorId, CancellationToken.None);
            
            if(instructorDTO == null) return null;
            
            return new InstructorType()
            {
                Id = instructorDTO.Id,
                FirstName = instructorDTO.FirstName,
                LastName = instructorDTO.LastName,
                Salary = instructorDTO.Salary,
            };
        }

        public IEnumerable<StudentType> Students { get; set; }
    }
}
