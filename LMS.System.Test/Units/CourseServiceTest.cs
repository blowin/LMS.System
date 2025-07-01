using FluentAssertions;
using FluentValidation;
using LMS.System.Domain.Services.CourseManagement.Repository;
using LMS.System.Domain.Services.DBServices.DBContext;
using Microsoft.EntityFrameworkCore;

namespace LMS.System.Test.Units;

public class CourseServiceTest
{
    [Fact]
    public async Task AddCourseInDb_Throws_Complete()
    {
        //Arrange

        using var DbContext = TestDbContextFactory.Create<ApplicationContext>();
        var service = new CourseService(DbContext);

        var user = TestData.TestData.GetValidUser();

        var category = TestData.TestData.GetValidCategory();

        var course = TestData.TestData.GetValidCourseCreateRequest();

        DbContext.Categories.Add(category);
        DbContext.Users.Add(user);
        DbContext.SaveChanges();
        DbContext.ChangeTracker.Clear();

        //Act

        var courseId = await service.CreateCourseAsync(course, default);

        //Assert

        var AddedCourse = DbContext.Courses.FirstOrDefault(p => p.Id == courseId);
        Assert.NotNull(AddedCourse);
        Assert.Equal("Заголовок", AddedCourse.Title);
    }

    [Fact]
    public async Task ChangePublishField_Throws_FieldBecameTrue()
    {
        //Arrange

        using var DbContext = TestDbContextFactory.Create<ApplicationContext>();
        var service = new CourseService(DbContext);

        var user = TestData.TestData.GetValidUser();

        var category = TestData.TestData.GetValidCategory();

        var course = TestData.TestData.GetValidCourseCreateRequest();

        DbContext.Categories.Add(category);
        DbContext.Users.Add(user);
        var courseId = await service.CreateCourseAsync(course, default);
        DbContext.SaveChanges();
        DbContext.ChangeTracker.Clear();

        //Act

        await service.PublishCourseAsync(courseId, default);

        //Assert

        var addedCourse = DbContext.Courses.FirstOrDefault(c => c.Id == courseId);
        Assert.NotNull(addedCourse);
        Assert.Equal("Заголовок", addedCourse.Title);
        Assert.True(addedCourse.IsPublished);
    }

    [Fact]
    public async Task ChangeArchiveField_Throws_FieldBecameTrue()
    {
        //Arrange
        using var DbContext = TestDbContextFactory.Create<ApplicationContext>();
        var service = new CourseService(DbContext);

        var user = TestData.TestData.GetValidUser();
        var category = TestData.TestData.GetValidCategory();
        var course = TestData.TestData.GetValidCourseCreateRequest();

        DbContext.Categories.Add(category);
        DbContext.Users.Add(user);
        var courseId = await service.CreateCourseAsync(course, default);
        DbContext.SaveChanges();
        DbContext.ChangeTracker.Clear();

        //Act
        await service.ArchiveCourseAsync(courseId, default);

        //Assert

        var addedCourse = DbContext.Courses.FirstOrDefault(c => c.Id == courseId);
        Assert.NotNull(addedCourse);
        Assert.Equal("Заголовок", addedCourse.Title);
        Assert.True(addedCourse.IsArchive);
    }

    [Fact]
    public async Task RemoveCourse_Throws_CourseWillBeenRemove()
    {
        //Arrange
        using var DbContext = TestDbContextFactory.Create<ApplicationContext>();
        var service = new CourseService(DbContext);

        var user = TestData.TestData.GetValidUser();
        var category = TestData.TestData.GetValidCategory();
        var course = TestData.TestData.GetValidCourseCreateRequest();

        DbContext.Categories.Add(category);
        DbContext.Users.Add(user);
        var courseId = await service.CreateCourseAsync(course, default);
        DbContext.SaveChanges();
        DbContext.ChangeTracker.Clear();

        //Act
        await service.DeleteCourseAsync(courseId, default);

        //Assert
        var result = DbContext.Courses.Any();
        Assert.False(result);
    }

    [Fact]
    public async Task CourseSearchById_Throws_CourseWillBeFound()
    {
        //Arrange
        using var DbContext = TestDbContextFactory.Create<ApplicationContext>();
        var service = new CourseService(DbContext);

        var user = TestData.TestData.GetValidUser();
        var category = TestData.TestData.GetValidCategory();
        var course = TestData.TestData.GetValidCourseCreateRequest();

        DbContext.Categories.Add(category);
        DbContext.Users.Add(user);
        var courseId = await service.CreateCourseAsync(course, default);
        DbContext.SaveChanges();
        DbContext.ChangeTracker.Clear();

        //Act
        var result = await service.CourseByIdResponse(courseId, default);

        //Assert
        Assert.NotNull(result);
        Assert.True(result.Id == courseId);
    }

}
