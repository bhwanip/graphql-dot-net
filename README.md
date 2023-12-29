# GraphQL Demo (.NET)

# Commands

```
dotnet build
dotnet run --launch-profile GraphQLDemo.API
```

# Data Setup

```
INSERT INTO Instructors (Id, FirstName, LastName, Salary) VALUES ('2b712728-1821-4111-8d1d-f68d7f362119', 'John', 'Doe', 60000), ('0114719d-62e4-4e14-81c2-effb4326ec99', 'Jane', 'Smith', 55000), ('63a8dacf-d7cb-4b89-9bd3-9b4aa7659af0', 'Michael', 'Johnson', 70000), ('b827ce7a-7541-4fa6-9599-b74b58e958ed', 'Emily', 'Williams', 60000), ('0d2a5864-807e-43c2-b2d3-a83c4519029f', 'David', 'Brown', 65000), ('21a99a2b-3f5c-4085-8aec-e566e2892763', 'Emma', 'Jones', 60000), ('f9b926d0-d35d-42f9-a021-08f9251b9fb8', 'Daniel', 'Miller', 75000), ('719c5f81-063b-44ae-bb50-77015dc6f926', 'Olivia', 'Davis', 70000), ('bb1f6b44-0a17-42ad-a1ba-8d943f18e6ca', 'Andrew', 'Wilson', 65000), ('2cbedf07-3f6d-4f88-afe9-1fd40653a011', 'Sophia', 'Taylor', 70000);

INSERT INTO Courses (Id, Name, Subject, InstructorId) VALUES ('1ff1b49b-604c-40bc-8969-6477f2bbccbc', 'History', '1', '2b712728-1821-4111-8d1d-f68d7f362119'), ('5039c744-48eb-4b90-9985-ba7783114a04', 'Computers', '1', '2b712728-1821-4111-8d1d-f68d7f362119'), ('b6717c8b-56ae-4a26-ad5c-a6b2c447ccc7', 'Database', '2', '63a8dacf-d7cb-4b89-9bd3-9b4aa7659af0'), ('2710e03f-5c71-472d-800b-f2cbd9e6a974', 'Physics', '1', '63a8dacf-d7cb-4b89-9bd3-9b4aa7659af0'), ('998cce7c-0c3a-41c5-8356-3ded9401d448', 'Chemistry', '2', '0114719d-62e4-4e14-81c2-effb4326ec99'), ('28954971-67a8-4bee-8e84-510946c8d203', 'Biology', '1', '0d2a5864-807e-43c2-b2d3-a83c4519029f'), ('5a4164ac-81eb-42cc-b07d-2d162e0eee64', 'English', '1', 'b827ce7a-7541-4fa6-9599-b74b58e958ed'), ('a449661f-792d-4e25-bebd-b4b7753cf2d5', 'Economics', '2', 'bb1f6b44-0a17-42ad-a1ba-8d943f18e6ca'), ('8d04b2ee-8676-4b4b-b263-8073bd91abb5', 'Java', '2', '719c5f81-063b-44ae-bb50-77015dc6f926'), ('8ae7585c-3fb6-42e9-a428-a9aeee452454', 'NodeJS', '2', '2cbedf07-3f6d-4f88-afe9-1fd40653a011');

INSERT INTO Students (Id, FirstName, LastName, GPA) VALUES ('6d20f105-adfd-4754-b1c4-d8757e517493', 'The', 'Thor', '8.8'), ('b91750fd-3ff1-41af-a9a5-83ad912b3321', 'The', 'Hulk', '7.0'), ('e9786b38-bf7b-4de8-947c-84675ed7cad3', 'The', 'Maverick', '8.0'), ('0dd7c083-0e0d-4e0d-8d94-ef5de52894b9', 'The', 'Lanyster', '9.0'), ('fcb6f6ed-6405-40fe-8cef-99dfb51bdea3', 'Fantastic', 'Four', '6.9');

 INSERT INTO CourseDTOStudentDTO (CoursesId, StudentsId) VALUES ('1ff1b49b-604c-40bc-8969-6477f2bbccbc', '6d20f105-adfd-4754-b1c4-d8757e517493'), ('1ff1b49b-604c-40bc-8969-6477f2bbccbc', 'b91750fd-3ff1-41af-a9a5-83ad912b3321'), ('2710e03f-5c71-472d-800b-f2cbd9e6a974', 'e9786b38-bf7b-4de8-947c-84675ed7cad3'), ('28954971-67a8-4bee-8e84-510946c8d203', '0dd7c083-0e0d-4e0d-8d94-ef5de52894b9'), ('28954971-67a8-4bee-8e84-510946c8d203', 'fcb6f6ed-6405-40fe-8cef-99dfb51bdea3'), ('8ae7585c-3fb6-42e9-a428-a9aeee452454', '6d20f105-adfd-4754-b1c4-d8757e517493'), ('8d04b2ee-8676-4b4b-b263-8073bd91abb5', 'b91750fd-3ff1-41af-a9a5-83ad912b3321'), ('8ae7585c-3fb6-42e9-a428-a9aeee452454', 'e9786b38-bf7b-4de8-947c-84675ed7cad3'), ('5a4164ac-81eb-42cc-b07d-2d162e0eee64', '0dd7c083-0e0d-4e0d-8d94-ef5de52894b9'), ('a449661f-792d-4e25-bebd-b4b7753cf2d5', 'fcb6f6ed-6405-40fe-8cef-99dfb51bdea3'), ('a449661f-792d-4e25-bebd-b4b7753cf2d5', '6d20f105-adfd-4754-b1c4-d8757e517493');
```

# Sample Query/Mutation

```
query {
  courses {
    id
    name
    students {
      id
      firstName
      lastName
      gpa
    }
    instructor {
      id
      firstName
    }
  }
}
```
```
query {
  paginatedCourses(first: 10, order: {
    name: ASC
  }, where: {
    subject: {
      eq: SCIENCE
    }
  }){
    edges {
      node {
        id
        name
        subject
        instructor {
          id
          firstName
          lastName
          money
        }
      }
    }
  }
}
```

```
mutation {
  createCourse(courseInput: {
    instructorId: "21a99a2b-3f5c-4085-8aec-e566e2892763",
    name: "AGRICULTURE",
    subject: SCIENCE,
  }) {
    id
    name
    subject
  }
}
```