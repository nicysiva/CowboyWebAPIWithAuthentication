using CowboyWebAPI.Controllers;
using CowboyWebAPI.Services;
using CowboyWebAPITest.MockData;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CowboyWebAPITest.Systems.Controllers
{
    public class TestCowboyDetailsController
    {
        [Fact]
        public async Task GetCowboyDetails_ShouldReturn200Status()
        {
            //Arrange
            var cowboyservice = new Mock<ICowboyService>();
            cowboyservice.Setup(_ => _.GetCowboyDetails()).ReturnsAsync(CowboyMockData.GetCowboys());
            var systemundertest = new CowboyDetailsController(cowboyservice.Object);

            //Act
            var result = await systemundertest.GetCowboyDetails();

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));

            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetCowboyDetails_ShouldReturn204Status()
        {
            //Arrange
            var cowboyservice = new Mock<ICowboyService>();
            cowboyservice.Setup(_ => _.GetCowboyDetails()).ReturnsAsync(CowboyMockData.Emptydetails());
            var systemundertest = new CowboyDetailsController(cowboyservice.Object);

            //Act
            var result = await systemundertest.GetCowboyDetails();

            //Assert
            result.GetType().Should().Be(typeof(NotFoundResult));

            (result as NotFoundResult).StatusCode.Should().Be(404);
        }
    }
}
