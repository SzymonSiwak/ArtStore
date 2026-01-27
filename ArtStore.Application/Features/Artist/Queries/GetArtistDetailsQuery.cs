using ArtStore.Domain.Interfaces;
using ArtStore.Shared.DTOs;
using AutoMapper;
using MediatR;

namespace ArtStore.Application.Features.Artists.Queries.GetArtistDetails
{
	public record GetArtistDetailsQuery(Guid Id) : IRequest<ArtistDetailsDto>;

	public class GetArtistDetailsQueryHandler : IRequestHandler<GetArtistDetailsQuery, ArtistDetailsDto>
	{
		private readonly IArtistRepository _artistRepository;
		private readonly IMapper _mapper;

		public GetArtistDetailsQueryHandler(IArtistRepository artistRepository, IMapper mapper)
		{
			_artistRepository = artistRepository;
			_mapper = mapper;
		}

		public async Task<ArtistDetailsDto> Handle(GetArtistDetailsQuery request, CancellationToken cancellationToken)
		{
			var artist = await _artistRepository.GetByIdAsync(request.Id);

			if (artist == null)
			{
				throw new KeyNotFoundException($"Artist with ID {request.Id} not found.");
			}

			return _mapper.Map<ArtistDetailsDto>(artist);
		}
	}
}