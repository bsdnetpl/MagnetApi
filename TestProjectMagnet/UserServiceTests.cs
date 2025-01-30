using MagnetApi.DB;
using MagnetApi.DTO;
using MagnetApi.Models;
using MagnetApi.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

public class UserServiceTests
    {
    private readonly Mock<DbSet<User>> _userDbSetMock;
    private readonly Mock<IConfiguration> _configurationMock;
    private readonly UserService _userService;
    private readonly Mock<DBConnection> _dbContextMock;

    public UserServiceTests()
        {
        var options = new DbContextOptionsBuilder<DBConnection>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _dbContextMock = new Mock<DBConnection>(options);
        _userDbSetMock = new Mock<DbSet<User>>();
        _configurationMock = new Mock<IConfiguration>();

        _dbContextMock.Setup(db => db.Set<User>()).Returns(_userDbSetMock.Object);

        _userService = new UserService(_dbContextMock.Object, _configurationMock.Object);
        }

    [Fact]
    public async Task AuthenticateAsync_ShouldReturnNull_WhenUserNotFound()
        {
        // Arrange
        var userDto = new UserDto { Email = "test@example.com", Password = "password" };
        var users = new List<User>().AsQueryable();
        _dbContextMock.Setup(db => db.Set<User>()).ReturnsDbSet(users);

        // Act
        var result = await _userService.AuthenticateAsync(userDto);

        // Assert
        Assert.Null(result);
        }

    

    [Fact]
    public async Task UpdatePasswordAsync_ShouldThrowException_WhenUserNotFound()
        {
        // Arrange
        var users = new List<User>().AsQueryable();
        _dbContextMock.Setup(db => db.Set<User>()).ReturnsDbSet(users);

        // Act & Assert
        await Assert.ThrowsAsync<KeyNotFoundException>(() => _userService.UpdatePasswordAsync(1, "oldPassword", "newPassword"));
        }
    }


