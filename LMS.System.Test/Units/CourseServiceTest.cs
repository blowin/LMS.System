using FluentAssertions;
using FluentValidation;
using LMS.System.Domain.Services.CourseManagement.Repository;
using LMS.System.Domain.Services.DBServices.DBContext;

namespace LMS.System.Test.Units;

public class CourseServiceTest
{
    [Fact]
    public async Task AddCourseInDb_Throws_Complete()
    {
        //Arrange

        using var mockDbContext = TestDbContextFactory.Create<ApplicationContext>();
        var service = new CourseService(mockDbContext);

        var user = TestData.TestData.GetValidUser();

        var category = TestData.TestData.GetValidCategory();

        var course = TestData.TestData.GetValidCourseCreateRequest();

        mockDbContext.Categories.Add(category);
        mockDbContext.Users.Add(user);
        mockDbContext.SaveChanges();
        mockDbContext.ChangeTracker.Clear();

        //Act

        var courseId = await service.CreateCourseAsync(course, default);

        //Assert

        var AddedCourse = mockDbContext.Courses.FirstOrDefault(p => p.Id == courseId);
        Assert.NotNull(AddedCourse);
        Assert.Equal("Заголовок", AddedCourse.Title);
    }

    [Fact]
    public async Task ChangePublishField_Throws_FieldBecameTrue()
    {
        //Arrange

        using var mockDbContext = TestDbContextFactory.Create<ApplicationContext>();
        var service = new CourseService(mockDbContext);

        var user = TestData.TestData.GetValidUser();

        var category = TestData.TestData.GetValidCategory();

        var course = TestData.TestData.GetValidCourseCreateRequest();

        mockDbContext.Categories.Add(category);
        mockDbContext.Users.Add(user);
        var courseId = await service.CreateCourseAsync(course, default);
        mockDbContext.SaveChanges();
        mockDbContext.ChangeTracker.Clear();

        //Act

        await service.PublishCourseAsync(courseId, default);

        //Assert

        var addedCourse = mockDbContext.Courses.FirstOrDefault(c => c.Id == courseId);
        Assert.NotNull(addedCourse);
        Assert.Equal("Заголовок", addedCourse.Title);
        Assert.True(addedCourse.IsPublished);
    }
}
