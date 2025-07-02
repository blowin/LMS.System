using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.System.Domain.Services.CourseManagement.CourseRequest;
using LMS.System.Domain.Services.DBServices.Models;
using LMS.System.Domain.Services.DBServices.Models.Enums;
using LMS.System.Test.Units;

namespace LMS.System.Test.TestData
{
    public static class TestData
    {
        public static User GetValidUser()
        {
            return new User
            {
                Email = "nikolya224@mail.ru",
                PasswordHash = "mnjhbgvffvxcGIVDCIGVVkvkcVKEVKgvEKVF",
                Role = EVRole.Student,
                FirstName = "Test",
                LastName = "TestLast"
            };
        }

        public static Category GetValidCategory()
        {
            return new Category
            {
                Name = "IT"
            };
        }

        public static CourseCreateRequest GetValidCourseCreateRequest()
        {
            return new CourseCreateRequest
            {
                Title = "Заголовок",
                Description = "Desc",
                CategoryId = 1,
                InstructorId = 1
            };
        }

        public static List<CourseCreateRequest> GetValidListCourseCreateRequest()
        {
            return new List<CourseCreateRequest>
            {
                new (){ Title = "C# Basics", Description = "Learn C#" , CategoryId = 1 , InstructorId = 1 },
                new (){ Title = "C# Advanced level", Description = "Learn C#" , CategoryId = 1 , InstructorId = 1 },
                new (){ Title = "Python basics" , Description = "Learn python" , CategoryId = 1 , InstructorId = 1 },
                new (){ Title = "C++ basics" , Description = "Learn C++" , CategoryId = 1 , InstructorId = 1 },
                new (){ Title = "Haskel basics" , Description = "Learn Haskel" , CategoryId = 1 , InstructorId = 1 },
                new (){ Title = "Assembler basics" , Description = "Learn Assembler" , CategoryId = 1 , InstructorId = 1 }
            };
        }

        public static List<CourseCreateRequest> GetValidListCourseCreateRequestWithDifferentCategory()
        {
            return new List<CourseCreateRequest>
            {
                new (){ Title = "C# basics", Description = "Learn C#" , CategoryId = 1 , InstructorId = 1 },
                new (){ Title = "Russian for childs", Description = "Learn Russian language" , CategoryId = 3 , InstructorId = 1 },
                new (){ Title = "C# Advanced level", Description = "Learn C#" , CategoryId = 1 , InstructorId = 1 },
                new (){ Title = "Python basics" , Description = "Learn python" , CategoryId = 1 , InstructorId = 1 },
                new (){ Title = "English for teenagers", Description = "Learn English language" , CategoryId = 3 , InstructorId = 1 },
                new (){ Title = "C++ basics" , Description = "Learn C++" , CategoryId = 1 , InstructorId = 1 },
                new (){ Title = "Haskel basics" , Description = "Learn Haskel" , CategoryId = 1 , InstructorId = 1 },
                new (){ Title = "Assembler basics" , Description = "Learn Assembler" , CategoryId = 1 , InstructorId = 1 },
                new (){ Title = "Advanced math", Description = "Learn C#" , CategoryId = 2 , InstructorId = 1 },
            };
        }

        public static List<Category> GetValidListCategory()
        {
            return new List<Category>
            {
                new(){ Name = "IT" },
                new(){ Name = "Math" },
                new(){ Name = "Languages" },
            };
        }
    }
}
