using ArtStore.Domain.Interfaces;
using ArtStore.Shared.DTO;
using AutoMapper;
using MediatR;

namespace ArtStore.Application.Features.User.Queries.GetUserProfile
{
    public record GetUserProfileQuery(string UserId) : IRequest<UserProfileDto>;

	public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, UserProfileDto>
	{
		private readonly IMapper _mapper;
		private readonly IUserRepository _userRepository;

		public GetUserProfileQueryHandler(IMapper mapper, IUserRepository userRepository)
		{
			_mapper = mapper;
			_userRepository = userRepository;
		}
		public async Task<UserProfileDto> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
		{
			var user = await _userRepository.GetByIdWithFavoritesAsync(request.UserId);
			return _mapper.Map<UserProfileDto>(user);
		}
	}
}
