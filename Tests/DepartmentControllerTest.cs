using API.Controllers;
using Application.Repos;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Tests
{
    public class DepartmentControllerTest
    {
        private readonly IDepartment _service;
        private readonly DepartmentController _controller;
        public DepartmentControllerTest()
        {
            _service = new DepartmentRepoFake();
            _controller = new DepartmentController(_service, null);

        }

        [Fact]
        public void GetDepartmentById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            var testId = 1;

            // Act
            var okResult = _controller.GetDepartment(testId).Result;

            // Assert
            Assert.IsType<Department>(okResult.Value);
        }

        [Fact]
        public void GetDepartmentByById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Arrange
            var testId = 343424;
            
            // Act
            var response = _controller.GetDepartment(testId).Result;

            // Assert
            Assert.IsNotType<Department>(response.Value);
        }

        [Fact]
        public void GetDepartmentByById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            var testId = 1;

            // Act
            var okResult = _controller.GetDepartment(testId).Result;

            // Assert
            Assert.IsType<Department>(okResult.Value);
            Assert.Equal(testId, (okResult.Value as Department).ID);

        }
    }
}