﻿using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ProductManagement;
using ProductManagement.Helper;
using ProductManagementDBEntity.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TST_ProductManagement.Data;

namespace TST_ProductManagement.Controller
{
    class ProductControllerTests
    {
        private ProductController mockProductController;
        private Mock<IProductManagementHelper> mockProductManagementHelper;
        private ProductDatas mockProductData;
        [SetUp]
        public void Setup()
        {
            mockProductManagementHelper = new Mock<IProductManagementHelper>();
            mockProductData = new ProductDatas();
            mockProductController = new ProductController(mockProductManagementHelper.Object);
        }

        /// <summary>
        ///  To Get all Products
        /// </summary>
        /// <returns></returns>
        [Test]   
        public async Task GetAll_Valid_Returns()
        {
            mockProductManagementHelper.Setup(d => d.GetAllProducts()).ReturnsAsync(mockProductData.products);
            var result = await mockProductController.GetAllProducts();
            Assert.That(result, Is.Not.Null);
        }
        /// <summary>
        /// To test for exception while getting all products
        /// </summary>
        /// <returns></returns>
        [Test]
        [Ignore("")]
        public async Task GetAll_InValid_ReturnsNull()
        {
            mockProductManagementHelper.Setup(d => d.GetAllProducts()).ReturnsAsync((List<Products>)(null));
            var result = await mockProductController.GetAllProducts() as OkObjectResult;
            Assert.That(result, Is.Null);
        }
        /// <summary>
        /// To add new product
        /// </summary>

        /// <returns></returns>
        [Test]
        [Ignore("")]
        public async Task AddProduct_valid_Returns()
        {
            mockProductManagementHelper.Setup(d => d.AddProduct(It.IsAny<Products>())).ReturnsAsync(true);
            var result = await mockProductController.AddProduct(new Products()
            {
                ProductId = 3,
                ProductName = "Bangles",
                ProductDesc = "Good",
                ProductPrice = 1000,
                ProducedDate = DateTime.Now,
                ProductExpireDate = DateTime.Now,
                CreateDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UserId = 1
            }) as OkObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.ToString(), Is.EqualTo(true));
        }
        /// <summary>
        /// To update existing product
        /// </summary>

        /// <returns></returns>
        [Test]
        [Ignore("")]
        public async Task UpdateProduct_valid_Returns()
        {
            mockProductManagementHelper.Setup(d => d.UpdateProduct(It.IsAny<Products>())).ReturnsAsync(true);
            var result = await mockProductController.UpdateProduct(new Products()
            {
                ProductId = 3,
                ProductName = "Bangles",
                ProductDesc = "Good",
                ProductPrice = 1000,
                ProducedDate = DateTime.Now,
                ProductExpireDate = DateTime.Now,
                CreateDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                UserId = 1
            }) as OkObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(true));
        }
        [Test]
        [Ignore("")]
        public async Task DeleteProduct_Valid_Return()
        {
            mockProductManagementHelper.Setup(d => d.GetProducts(It.IsAny<int>()));
            var result = await mockProductController.DeleteProduct(1);
            Assert.That(result, Is.Null);

        }
    }
}
