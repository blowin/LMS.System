using System.Threading.Tasks;
using LMS.System.Domain.Services.CourseManagement.Repository;
using LMS.System.Domain.Services.DBServices.DBContext;
using LMS.System.Domain.Services.DBServices.Models;
using LMS.System.Domain.Services.DBServices.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace LMS.System.Test;

public class CourseServiceTest
{
    //Тестирование удаления курса.
    [Fact]
    public async Task DeleteCourse_ShouldRemoveCourseFromDatabase()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase_AddUser")
            .Options;

        //инициализируем курс.
        var Title = "Курсы по JWT";
        var Description = "Этот курс создан для сбора денег";
        var CategoryId = 1;
        var InstructorId = 1;

        using (var context = new ApplicationContext(options))
        {
            var course = new Course
            {
                Title = Title,
                Description = Description,
                CategoryId = CategoryId,
                InstructorId = InstructorId
            };
            context.Add(course);
            context.SaveChanges();
        }

        // Act
        using (var context = new ApplicationContext(options))
        {
            var service = new CourseService(context);
            await service.DeleteCourseAsync(1, default);
        }
        // Assert
        using (var context = new ApplicationContext(options))
        {
            Assert.False(await context.Courses.AnyAsync(c => c.Id == 1));
        }
    }
    //Тестирование изменения поля IsPublish.
    [Fact]
    public async Task ChangeFieldIsPublishCourse_ShouldChangeIsPublishFromTrueToFalseCourse()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase_AddUser")
            .Options;

        //инициализируем курс.
        var Title = "Курсы по JWT";
        var Description = "Этот курс создан для сбора денег";
        var CategoryId = 1;
        var InstructorId = 1;

        using (var context = new ApplicationContext(options))
        {
            var course = new Course
            {
                Title = Title,
                Description = Description,
                CategoryId = CategoryId,
                InstructorId = InstructorId
            };
            context.Add(course);
            context.SaveChanges();
        }
        //Act
        using (var context = new ApplicationContext(options))
        {
            var service = new CourseService(context);
            await service.PublishCourseAsync(1, default);
        }
        //Assert
        using (var context = new ApplicationContext(options))
        {
            var course = await context.Courses.FindAsync(1);
            Assert.True(course.IsPublished);
        }
    }

    //Тестирование изменения поля IsPublish.
    [Fact]
    public async Task ChangeFieldIsArchiveCourse_ShouldChangeIsArchiveFromFalseToTrueCourse()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase_AddUser")
            .Options;

        //инициализируем курс.
        var Title = "Курсы по JWT";
        var Description = "Этот курс создан для сбора денег";
        var CategoryId = 1;
        var InstructorId = 1;

        using (var context = new ApplicationContext(options))
        {
            var course = new Course
            {
                Title = Title,
                Description = Description,
                CategoryId = CategoryId,
                InstructorId = InstructorId
            };
            context.Add(course);
            context.SaveChanges();
        }
        //Act
        using (var context = new ApplicationContext(options))
        {
            var service = new CourseService(context);
            await service.ArchiveCourseAsync(1, default);
        }
        //Assert
        using (var context = new ApplicationContext(options))
        {
            var course = await context.Courses.FindAsync(1);
            Assert.True(course.IsArchive);
        }
    }

    //Тестирование метода создания курса.
    [Fact]
    public async Task CreateCourse_ShouldAddingCourseInDatabase()
    {
        //Arrange
        var options = new DbContextOptionsBuilder<ApplicationContext>()
     .UseInMemoryDatabase(databaseName: "TestDatabase_AddUser")
     .Options;

        //инициализируем курс.
        var Title = "Курсы по JWT";
        var Description = "Этот курс создан для сбора денег";
        var CategoryId = 1;
        var InstructorId = 1;

        //Act
        using (var context = new ApplicationContext(options))
        {
            var course = new Course
            {
                Title = Title,
                Description = Description,
                CategoryId = CategoryId,
                InstructorId = InstructorId
            };
            context.Add(course);
            context.SaveChanges();
        }
        //Assert
        using (var context = new ApplicationContext(options))
        {
            //проверяем добавлены ли курсы.
            var exist = await context.Courses.AnyAsync();
            Assert.True(exist);

            //проверяем конкретный курс.
            var AddedCourse = await context.Courses.FirstOrDefaultAsync(c => c.Title == Title);
            Assert.NotNull(AddedCourse);

            Assert.Equal("Курсы по JWT", AddedCourse.Title);
            Assert.Equal("Этот курс создан для сбора денег", AddedCourse.Description);
            Assert.Equal(1, AddedCourse.CategoryId);
            Assert.Equal(1, AddedCourse.InstructorId);
        }
    }

    [Fact]
    public async Task FindCourseById_ShouldReturnCourseWichHaveSendedId()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<ApplicationContext>()
            .UseInMemoryDatabase(databaseName: "Test_FindCourseById")
            .Options;

        // Инициализация данных
        using (var arrangeContext = new ApplicationContext(options))
        {
            // Курс
            arrangeContext.Courses.Add(new Course
            {
                Title = "Курсы по JWT",
                Description = "Этот курс создан для сбора денег",
                CategoryId = 1,
                InstructorId = 1
            });

            await arrangeContext.SaveChangesAsync();
        }

        // Act
        using (var actContext = new ApplicationContext(options))
        {
            var service = new CourseService(actContext);
            var result = await service.CourseByIdResponse(1, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Курсы по JWT", result.Title);
        }
    }
}
