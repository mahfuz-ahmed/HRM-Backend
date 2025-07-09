using HRM.Applicatin.Service;
using HRM.Domain;
using HRM.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;

namespace HRM.Test
{
    public class EmployeeRepositoryTests
    {
        private readonly Mock<IRedisCacheService> _mockCacheService;
        private readonly AppDbContext _dbContext;
        private readonly EmployeeRepository _repository;

        public EmployeeRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "HRM_TestDB")
                .Options;

            _dbContext = new AppDbContext(options);
            _mockCacheService = new Mock<IRedisCacheService>();
            _repository = new EmployeeRepository(_dbContext, _mockCacheService.Object);
        }

        [Fact]
        public async Task AddEmployeeAsync_Should_Add_To_Db_And_Set_Cache()
        {
            // Arrange
            var employee = new Employee
            {
                Id = 1,
                UserID = 1,
                FullName = "Test User",
                Email = "test@example.com",
                Password ="Mahfzu123@",
                IsActive = true,
                IsAdmin = false,
                JoinDate = DateTime.Now,
                EntryUserID = 1,
                EntryDate = DateTime.Now,
                UpdateUserID = 1,
                UpdateDate = DateTime.Now
            };

            // Act
            var result = await _repository.AddEmployeeAsync(employee);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test User", result.FullName);
            Assert.Single(_dbContext.Employees); // Make sure it's saved in DB
            _mockCacheService.Verify(c => c.SetAsync(It.IsAny<string>(), It.IsAny<Employee>(), It.IsAny<TimeSpan>()), Times.Once);
            _mockCacheService.Verify(c => c.RemoveAsync(It.IsAny<string>()), Times.Once);
        }
    }
}
