using System;
using System.Collections.Generic;
using System.Text;
using ArtStore.Domain.Interfaces;
using MediatR;

namespace ArtStore.Application.Features.User.Commands.ToogleFavorite
{
	public record ToggleFavoriteCommand(string UserId, Guid ProductId) : IRequest<bool>; // bool: true=added, false=removed

	public class ToggleFavoriteCommandHandler : IRequestHandler<ToggleFavoriteCommand, bool>
	{
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public ToggleFavoriteCommandHandler(IUserRepository userRepository, IProductRepository productRepository)
		{
			_userRepository = userRepository;
			_productRepository = productRepository;
		}

		public async Task<bool> Handle(ToggleFavoriteCommand request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetByIdWithFavoritesAsync(request.UserId);
			if (user == null) throw new Exception("User not found");

			var product = await _productRepository.GetByIdAsync(request.ProductId);
			if (product == null) throw new Exception("Product not found");

			bool isAdded;

			// Check if the product is already in favorites
			var existingFavorite = user.Favorites.FirstOrDefault(p => p.Id == request.ProductId);


			if (existingFavorite != null)
			{
				user.Favorites.Remove(existingFavorite);
				isAdded = false;
			}
			else
			{
				user.Favorites.Add(product);
				isAdded = true;
			}

			await _userRepository.UpdateAsync(user);

			// true = added, false = removed
			return isAdded;
		}
	}
}
