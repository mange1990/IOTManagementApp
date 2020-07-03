using IOTManagementApp.Controllers;
using Microsoft.Extensions.Logging;
using System;
using Xunit;



namespace IOTManagementAppTests
{
    public class OverviewControllerShould
    {
        private readonly ILogger<OverviewController> _logger;
        private readonly OverviewController _controller;

        public OverviewControllerShould()
        {
            _controller = new OverviewController(_logger);
        }

        [Fact]
        public void ReturnStringFromIndex()
        {
            var returnString = _controller.index();
            Assert.IsType<string>(returnString);
        }

        [Fact]
        public void ReturnHejFromIndex()
        {
            var returnString = _controller.index();
            Assert.Equal("Hej",returnString);
        }


    }
}
