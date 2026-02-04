using System;
using System.Collections.Generic;
using System.Text;
using ArtStore.Application.Features.Cart.Queries.GetCart;
using ArtStore.Domain.Entities;
using ArtStore.Domain.Interfaces;
using ArtStore.Shared.DTO;
using AutoMapper;
using FluentAssertions;
using NSubstitute;

namespace ArtStore.Application.UnitTests.Feature.Query
{
    public class GetCartQueryHandlerTests
    {
        private readonly ICartRepository _cartRepo;
        private readonly IMapper _mapper;
        private readonly GetCartQueryHandler _handler;

        public GetCartQueryHandlerTests()
        {
            _cartRepo = Substitute.For<ICartRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new GetCartQueryHandler(_cartRepo, _mapper);
		}

        [Fact]
        public async Task Handle_ShouldReturnEmptyDto_WhenCartDoesNotExist()
        {
            // Arrange
            var userId = "user-no-cart";

            _cartRepo.GetByUserIdAsync(userId).Returns((Cart?)null);
            var query = new GetCartQuery(userId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Items.Should().BeEmpty();
            result.TotalAmount.Should().Be(0);

			// Mapper should not be invoke in this path
			_mapper.DidNotReceiveWithAnyArgs().Map<CartDto>(Arg.Any<object>());
		}

		[Fact]
		public async Task Handle_ShouldReturnMappedDto_WhenCartExists()
		{
			// Arrange
			var userId = "user-with-cart";

			var existingCart = new Cart
			{
				UserId = userId,
				Items = new List<CartItem>
				{
					new CartItem { ProductId = Guid.NewGuid(), Quantity = 2 }
				}
			};

			var expectedDto = new CartDto
			{
				TotalAmount = 100,
				Items = new List<CartItemDto> { new CartItemDto { Quantity = 2 } }
			};

			// Mock
			_cartRepo.GetByUserIdAsync(userId).Returns(existingCart);
			_mapper.Map<CartDto>(existingCart).Returns(expectedDto);

			var query = new GetCartQuery(userId);

			// Act
			var result = await _handler.Handle(query, CancellationToken.None);

			// Assert
			result.Should().NotBeNull();
			result.Should().BeEquivalentTo(expectedDto);

			// Mapper need to be invoke once with cart object
			_mapper.Received(1).Map<CartDto>(existingCart);
		}
	}
}
