using System.Collections.Generic;
using System.Linq;
using DataBaseApi;
using DataBaseApi.Controllers;
using DataBaseApi.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Test.Stubs;

namespace Tests
{
    public class ItemsControllerTest
    {
        private ItemsController _controller;
        private ApplicationContext _context;

        [SetUp]
        public void Setup()
        {
            _context = ApplicationContextStub.InitStub();
            _controller = new ItemsController(_context);
        }

        [Test]
        public void GetAll_NotNullReturn()
        {
            var okResult = _controller.Get().Result;

            Assert.NotNull(okResult);
        }

        [Test]
        public void GetAll_ReturnTrueCount()
        {
            var okResult = _controller.Get().Result;

            Assert.Equals(5, okResult.Value.Count());
        }
    }
}