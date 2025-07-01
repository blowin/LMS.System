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

        public static CourseCreateRequest GetBadValidCourseCreateRequest()
        {
            return new CourseCreateRequest
            {
                Title = null,
                Description = "Desc",
                CategoryId = 1,
                InstructorId = 1
            };
        }
    }
}
