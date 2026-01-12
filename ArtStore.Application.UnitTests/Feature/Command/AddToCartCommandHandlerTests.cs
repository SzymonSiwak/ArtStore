using ArtStore.Application.Features.Cart.Commands;
using ArtStore.Domain.Entities;
using ArtStore.Domain.Interfaces;
using ArtStore.Shared.DTOs;
using AutoMapper;
using FluentAssertions;
using NSubstitute;

namespace ArtStore.Application.UnitTests.Feature.Command
{
    public class AddToCartCommandHandlerTests
    {
        private readonly ICartRepository _cartRepo;
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;
        private readonly AddToCartCommandHandler _handler;

        public AddToCartCommandHandlerTests()
        {
            _cartRepo = Substitute.For<ICartRepository>();
            _productRepo = Substitute.For<IProductRepository>();
            _mapper = Substitute.For<IMapper>();
             
            // Mapper config for handler testing
            _mapper.Map<CartDto>(Arg.Any<Cart>()).Returns(new CartDto());
            _handler = new AddToCartCommandHandler(_cartRepo, _productRepo, _mapper);
		}

        [Fact]
        public async Task Handle_ShouldCreateNewCart_WhenCartDoesNotExist()
        {
            // Arrange
            var command = new AddToCartCommand("user1", Guid.NewGuid(), 1);

            // Mock: Product exist
            _productRepo.GetByIdAsync(command.ProductId)
                        .Returns(new Product { Id = command.ProductId, Price = new(100, "USD") });

            // Mock: Cart doesn't exist
            _cartRepo.GetByUserIdAsync(command.UserId).Returns((Cart?)null);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            //Assert
            await _cartRepo.Received(1).AddAsync(Arg.Is<Cart>(c => c.UserId == command.UserId));
            await _cartRepo.Received(1).SaveChangesAsync();
        }

        [Fact]
        public async Task Handle_ShouldThrowException_WhenProductNotFound()
        {
            // Arrange
            var command = new AddToCartCommand("user1", Guid.NewGuid(), 1);

            // Mock: Product does not exist
            _productRepo.GetByIdAsync(command.ProductId).Returns((Product?)null);

			// Act
			Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

			// Assert
			await act.Should().ThrowAsync<Exception>().WithMessage("Product not found");
			await _cartRepo.DidNotReceive().SaveChangesAsync();
		}

		[Fact]
		public async Task Handle_ShouldAddProductToExistingCart_WhenCartExists()
		{
			// Arrange
			var userId = "user-existing";
			var productId = Guid.NewGuid();
			var command = new AddToCartCommand(userId, productId, 1);

			// Mock: Product exists
			_productRepo.GetByIdAsync(productId).Returns(new Product { Id = productId, Price = new(50, "USD") });

			// Mock: Existing cart
			var existingCart = new Cart
			{
				UserId = userId,
				Items = new List<CartItem>() // List initialization to prevent from NullRef Exception
			};
			_cartRepo.GetByUserIdAsync(userId).Returns(existingCart);

			// Act
			await _handler.Handle(command, CancellationToken.None);

			// Assert
			// New cart shouldn't be created
			await _cartRepo.DidNotReceive().AddAsync(Arg.Any<Cart>());

			// Should save changes to existing cart
			await _cartRepo.Received(1).SaveChangesAsync();

			// Verify the product was added to the existing cart
			existingCart.Items.Should().ContainSingle(i => i.ProductId == productId && i.Quantity == 1);
		}

	}
}
