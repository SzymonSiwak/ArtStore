using ArtStore.Domain.Interfaces;
using ArtStore.Shared.DTO;
using AutoMapper;
using MediatR;

namespace ArtStore.Application.Features.Artist.Queries
{
    public record GetArtistsQuery() : IRequest<IEnumerable<ArtistDto>>;
    public class GetArtistsQueryHandler : IRequestHandler<GetArtistsQuery, IEnumerable<ArtistDto>>
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IMapper _mapper;

        public GetArtistsQueryHandler(IArtistRepository artistRepository, IMapper mapper)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArtistDto>> Handle(GetArtistsQuery _, CancellationToken cancellationToken)
        {
            var artists = await _artistRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ArtistDto>>(artists);
		}
    }
}
