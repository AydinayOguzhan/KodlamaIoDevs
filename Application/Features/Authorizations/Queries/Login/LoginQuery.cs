using Application.Features.Authorizations.Dtos;
using Application.Features.Authorizations.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authorizations.Queries.Login
{
    public class LoginQuery: IRequest<LoginDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }

        public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly IAuthSevrice _authService;
            private readonly AuthorizationBusinessRules _authBusinessRules;

            public LoginQueryHandler(IMapper mapper, IUserRepository userRepository, IAuthSevrice authService, AuthorizationBusinessRules authBusinessRules)
            {
                _mapper = mapper;
                _userRepository = userRepository;
                _authService = authService;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<LoginDto> Handle(LoginQuery request, CancellationToken cancellationToken)
            {
                User user = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);
                _authBusinessRules.CheckIfUserExists(user);
                _authBusinessRules.CheckIfPasswordTrue(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt);

                AccessToken accessToken = await _authService.CreateAccessToken(user);
                LoginDto loginDto = _mapper.Map<LoginDto>(user);
                loginDto.AccessToken = accessToken;
                return loginDto;
            }
        }
    }
}
