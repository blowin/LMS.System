using FluentAssertions;
using FluentValidation;
using LMS.System.Domain.Services.CourseManagement.CourseServices;
using LMS.System.Domain.Services.CourseManagement.Page;
using LMS.System.Domain.Services.CourseManagement.Repository;
using LMS.System.Domain.Services.DBServices.DBContext;
using Microsoft.EntityFrameworkCore;

namespace LMS.System.Test.Units;

public class CourseServiceTest
{
    [Fact]
    public async Task AddCourseInDb_ExpectedResult_ListWithAddedCourse()
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
    public async Task ChangePublishField_ExpectedResult_FieldBecameTrue()
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
    public async Task ChangeArchiveField_ExpectedResult_FieldBecameTrue()
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
    public async Task RemoveCourse_ExpectedResult_CourseWillBeenRemove()
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
    public async Task CourseSearchById_ExpectedResult_FoundedCourse()
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

    [Fact]
    public async Task GetCoursePageAsync_ExpectedResult_FirstPage_WithCorrectPagination()
    {
        //Arrange
        using var DbContext = TestDbContextFactory.Create<ApplicationContext>();

        var service = new CourseService(DbContext);
        var user = TestData.TestData.GetValidUser();
        var category = TestData.TestData.GetValidCategory();
        var courseRequest = TestData.TestData.GetValidListCourseCreateRequest();

        DbContext.Categories.Add(category);
        DbContext.Users.Add(user);

        foreach (var request in courseRequest)
        {
            await service.CreateCourseAsync(request, default);
        }

        await DbContext.SaveChangesAsync();
        DbContext.ChangeTracker.Clear();

        var pageRequest = new CoursePageRequest
        {
            InstructorId = 1,
            Page = new PageRequest { PageNumber = 1, PageSize = 2 }
        };

        //Act
        var result = await service.GetCoursePageAsync(pageRequest, default);

        //Assert
        Assert.Equal(2, result.PageSize);
        Assert.Equal(1, result.PageNumber);
        Assert.Equal(6, result.TotalItemCount);
        Assert.Equal(3, result.PageCount);
        Assert.True(result.HasNextPage);
        Assert.False(result.HasPreviousPage);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetCoursePageAsyncWithSearchingById_ExpectedResult_ListWithOneCourse()
    {
        //Arrange
        using var DbContext = TestDbContextFactory.Create<ApplicationContext>();

        var service = new CourseService(DbContext);
        var user = TestData.TestData.GetValidUser();
        var category = TestData.TestData.GetValidCategory();
        var courseRequest = TestData.TestData.GetValidListCourseCreateRequest();

        DbContext.Categories.Add(category);
        DbContext.Users.Add(user);

        foreach (var request in courseRequest)
        {
            await service.CreateCourseAsync(request, default);
        }

        await DbContext.SaveChangesAsync();
        DbContext.ChangeTracker.Clear();

        var pageRequest = new CoursePageRequest
        {
            Id = 1,
            InstructorId = 1,
            Page = new PageRequest { PageNumber = 1, PageSize = 2 }
        };

        //Act
        var result = await service.GetCoursePageAsync(pageRequest, default);

        //Assert
        Assert.Equal(1, result.TotalItemCount);
    }

    [Fact]
    public async Task GetCoursePageAsyncWithSearchingBySearchTerm_ExpectedResult_ListWithTwoCourses()
    {
        //Arrange
        using var DbContext = TestDbContextFactory.Create<ApplicationContext>();

        var service = new CourseService(DbContext);
        var user = TestData.TestData.GetValidUser();
        var category = TestData.TestData.GetValidCategory();
        var courseRequest = TestData.TestData.GetValidListCourseCreateRequest();

        DbContext.Categories.Add(category);
        DbContext.Users.Add(user);

        foreach (var request in courseRequest)
        {
            await service.CreateCourseAsync(request, default);
        }

        await DbContext.SaveChangesAsync();
        DbContext.ChangeTracker.Clear();

        var pageRequest = new CoursePageRequest
        {
            SearchTerm = "C#",
            InstructorId = 1,
            Page = new PageRequest { PageNumber = 1, PageSize = 2 }
        };

        //Act
        var result = await service.GetCoursePageAsync(pageRequest, default);

        //Assert
        Assert.Equal(2, result.TotalItemCount);
    }

    [Fact]
    public async Task GetCoursePageAsyncWithSearchingByCategoryName_ExpectedResult_ListWithSixCourses()
    {
        //Arrange
        using var DbContext = TestDbContextFactory.Create<ApplicationContext>();

        var service = new CourseService(DbContext);
        var user = TestData.TestData.GetValidUser();
        var category = TestData.TestData.GetValidCategory();
        var courseRequest = TestData.TestData.GetValidListCourseCreateRequest();

        DbContext.Categories.Add(category);
        DbContext.Users.Add(user);

        foreach (var request in courseRequest)
        {
            await service.CreateCourseAsync(request, default);
        }

        await DbContext.SaveChangesAsync();
        DbContext.ChangeTracker.Clear();

        var pageRequest = new CoursePageRequest
        {
            CategoryName = "IT",
            InstructorId = 1,
            Page = new PageRequest { PageNumber = 1, PageSize = 2 }
        };

        //Act
        var result = await service.GetCoursePageAsync(pageRequest, default);

        //Assert
        Assert.Equal(6, result.TotalItemCount);
    }

    [Fact]
    public async Task GetCoursePageAsyncWithSortingByTitleAsc_ExpectedResult_FirstCourseWillBeAssembler()
    {
        //Arrange
        using var DbContext = TestDbContextFactory.Create<ApplicationContext>();

        var service = new CourseService(DbContext);
        var user = TestData.TestData.GetValidUser();
        var category = TestData.TestData.GetValidCategory();
        var courseRequest = TestData.TestData.GetValidListCourseCreateRequest();

        DbContext.Categories.Add(category);
        DbContext.Users.Add(user);

        foreach (var request in courseRequest)
        {
            await service.CreateCourseAsync(request, default);
        }

        await DbContext.SaveChangesAsync();
        DbContext.ChangeTracker.Clear();

        var pageRequest = new CoursePageRequest
        {
            SortField = Domain.Services.CourseManagement.Enums.EVCourseField.Title,
            SortType = Domain.Services.CourseManagement.Enums.EVSortType.Asc,
            InstructorId = 1,
            Page = new PageRequest { PageNumber = 1, PageSize = 2 }
        };

        //Act
        var result = await service.GetCoursePageAsync(pageRequest, default);

        //Assert
        Assert.Equal("Assembler basics", result[0].Title);
        Assert.Equal("C# Advanced level", result[1].Title);
    }

    [Fact]
    public async Task GetCoursePageAsyncWithSortingByTitleDesc_ExpectedResult_FirstCourseWillBePython()
    {
        //Arrange
        using var DbContext = TestDbContextFactory.Create<ApplicationContext>();

        var service = new CourseService(DbContext);
        var user = TestData.TestData.GetValidUser();
        var category = TestData.TestData.GetValidCategory();
        var courseRequest = TestData.TestData.GetValidListCourseCreateRequest();

        DbContext.Categories.Add(category);
        DbContext.Users.Add(user);

        foreach (var request in courseRequest)
        {
            await service.CreateCourseAsync(request, default);
        }

        await DbContext.SaveChangesAsync();
        DbContext.ChangeTracker.Clear();

        var pageRequest = new CoursePageRequest
        {
            SortField = Domain.Services.CourseManagement.Enums.EVCourseField.Title,
            SortType = Domain.Services.CourseManagement.Enums.EVSortType.Desc,
            InstructorId = 1,
            Page = new PageRequest { PageNumber = 1, PageSize = 2 }
        };

        //Act
        var result = await service.GetCoursePageAsync(pageRequest, default);

        //Assert
        Assert.Equal("Python basics", result[0].Title);
        Assert.Equal("Haskel basics", result[1].Title);
    }

    [Fact]
    public async Task GetCoursePageAsyncWithSortingByCategoryTitleSearchTermDesc_ExpectedResult_FirstCourseWillBeRussianorChilds()
    {
        //Arrange
        using var DbContext = TestDbContextFactory.Create<ApplicationContext>();

        var service = new CourseService(DbContext);
        var user = TestData.TestData.GetValidUser();
        var courseRequest = TestData.TestData.GetValidListCourseCreateRequestWithDifferentCategory();
        var categories = TestData.TestData.GetValidListCategory();

        foreach (var category in categories)
        {
            await DbContext.Categories.AddAsync(category);
        }

        DbContext.Users.Add(user);

        foreach (var request in courseRequest)
        {
            await service.CreateCourseAsync(request, default);
        }

        await DbContext.SaveChangesAsync();
        DbContext.ChangeTracker.Clear();

        var pageRequest = new CoursePageRequest
        {
            CategoryName = "Language",
            SearchTerm = "for",
            SortField = Domain.Services.CourseManagement.Enums.EVCourseField.Title,
            SortType = Domain.Services.CourseManagement.Enums.EVSortType.Desc,
            InstructorId = 1,
            Page = new PageRequest { PageNumber = 1, PageSize = 2 }
        };

        //Act
        var result = await service.GetCoursePageAsync(pageRequest, default);

        //Assert
        Assert.Equal("Languages", result[0].CategoryName);
        Assert.Equal("Russian for childs", result[0].Title);
        Assert.Equal(2, result.TotalItemCount);
    }
}
