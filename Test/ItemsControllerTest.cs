using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task TestGetItem()
        {
            var id = 1;

            var response = (await _controller.Get(id)).Result as ObjectResult;
            var value = response.Value as ItemModel;

            Assert.AreEqual(value.Id,1);
        }

        [Test]
        public void TestUpdateItem()
        {
            var item = new ItemModel()
            {
                Title = "New Item best!",
                Id = 1
            };

            var okResult = _controller.Put(item).Result;
            var contexResult = _context.Items.FirstOrDefault(x => x.Id.Equals(1));

            Assert.AreEqual(item.Title, contexResult.Title);
        }

        [Test]
        public void TestAddItem()
        {
            var item = new ItemModel()
            {
                Description = "New Item",
                Price = 100,
                Title = "New Item best!",
                Id = 10,
                InStock = 10000
            };

            var okResult = _controller.Post(item).Result;
            var contexResult = _context.Items.FirstOrDefault(x => x.Id.Equals(10));

            Assert.NotNull(contexResult);
        }

        [Test]
        public void TestGetAll_NotNullReturn()
        {
            var okResult = _controller.Get().Result;

            Assert.NotNull(okResult);
        }

        [Test]
        public async Task TestGetAll_ReturnTrueCount()
        {
            var okResult = (await _controller.Get()).Result as ObjectResult;
            
            Assert.AreEqual(5, (okResult.Value as IEnumerable<ItemModel>).Count());
        }

        [Test]
        public void TestDeleteItem()
        {
            var id = 2;
            var okResult = _controller.Delete(id).Result;
            var contexResult = _context.Items.FirstOrDefault(x => x.Id.Equals(2));

            Assert.NotNull(okResult);
            Assert.Null(contexResult);
        }
    }
}