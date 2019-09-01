using Cart.API.Controllers;
using Cart.Domain.Models;
using Cart.Infrastructure.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cart.UnitTests
{
    public class CartControllerTests
    {
        [Theory, AutoMoqData]
        public async void AddItemToCart_Empty_UserId_Should_Return_BadRequest(Mock<ICartRepository> cartRepositoryMock)
        {
            //Arrange
            var emptyUserCart = new UserCart(string.Empty);
            cartRepositoryMock.Setup(c => c.AddUpdateCartAsync(emptyUserCart)).Returns(Task.FromResult(emptyUserCart));
            var cartController = new CartController(cartRepositoryMock.Object);

            //Act
            var sut = await cartController.Post(emptyUserCart);

            //Assert
            var apiResult = sut.Result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Theory, AutoMoqData]
        public async void AddItemToCart_Empty_CartItemList_Should_Return_BadRequest(Mock<ICartRepository> cartRepositoryMock)
        {
            //Arrange
            var emptyUserCart = new UserCart("123");
            cartRepositoryMock.Setup(c => c.AddUpdateCartAsync(emptyUserCart)).Returns(Task.FromResult(emptyUserCart));
            var cartController = new CartController(cartRepositoryMock.Object);

            //Act
            var sut = await cartController.Post(emptyUserCart);

            //Assert
            var apiResult = sut.Result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Theory, AutoMoqData]
        public async void AddItemToCart_Post_Success(Mock<ICartRepository> cartRepositoryMock, UserCart userCardData)
        {
            //Arrange
            cartRepositoryMock.Setup(c => c.AddUpdateCartAsync(userCardData)).Returns(Task.FromResult(userCardData));
            var cartController = new CartController(cartRepositoryMock.Object);

            //Act
            var sut = await cartController.Post(userCardData);

            //Assert
            var apiResult = sut.Result.Should().BeOfType<OkObjectResult>().Subject;
            var actualValue = apiResult.Value as UserCart;
            actualValue.CartItems.Should().HaveCount(userCardData.CartItems.Count);
        }

        [Theory, AutoMoqData]
        public async void GetCart_Empty_UserId_Should_Return_BadRequest(Mock<ICartRepository> cartRepositoryMock)
        {
            //Arrange
            var userId = string.Empty;
            var emptyUserCart = new UserCart(string.Empty);
            cartRepositoryMock.Setup(c => c.GetCartAsync(userId)).Returns(Task.FromResult(emptyUserCart));
            var cartController = new CartController(cartRepositoryMock.Object);

            //Act
            var sut = await cartController.Get(userId);

            //Assert
            var apiResult = sut.Result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Theory, AutoMoqData]
        public async void GetCart_Empty_Success(Mock<ICartRepository> cartRepositoryMock,string userId, UserCart userCardData)
        {
            //Arrange
            cartRepositoryMock.Setup(c => c.GetCartAsync(userId)).Returns(Task.FromResult(userCardData));
            var cartController = new CartController(cartRepositoryMock.Object);

            //Act
            var sut = await cartController.Get(userId);

            //Assert
            var apiResult = sut.Result.Should().BeOfType<OkObjectResult>().Subject;
            var actualValue = apiResult.Value as UserCart;
            actualValue.CartItems.Should().HaveCount(userCardData.CartItems.Count);
        }
    }

}
