using Microsoft.AspNetCore.Mvc;
using Moq;
using SalesPortalAPI.Controllers;
using SalesPortalAPI.Core.Repository;
using SalesPortalAPI.Data;
using SalesPortalAPI.Models;
using System;
using Xunit;

namespace SalesPortalAPITest
{
    public class QuotationControllerTest
    {
        public Mock<QuotationDBContext> _dbContextMock = new Mock<QuotationDBContext>();
        public Mock<IDataGenerator<Quotation>> _dataGeneratorMock = new Mock<IDataGenerator<Quotation>>();
        public QuotationControllerTest() { }

        [Fact]
        /// <summary>
        /// Asserts the get method of API.
        /// </summary>
        public void Get_WhenCalled_ReturnsOkResult()
        {
            //TODO : Set up the mock interfaces correctly 
                //_dbContextMock.Setup(p => p).Returns(true);
                //_dataGeneratorMock.Setup(p => p).Returns(true);
            //Arrange
            QuotationController _controller = new QuotationController(_dbContextMock.Object, _dataGeneratorMock.Object);
            // Act
            var okResult = _controller.Get();
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}
