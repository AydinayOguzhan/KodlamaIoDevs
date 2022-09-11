using Application.Features.Authorizations.Dtos;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Authorizations.Commands.Register
{
    public class RegisterCommand: IRequest<RegisteredDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public AuthenticatorType AuthenticatorType { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IAuthSevrice _authService;

            public RegisterCommandHandler(IMapper mapper, IUserRepository userRepository, IUserOperationClaimRepository userOperationClaimRepository, IAuthSevrice authService)
            {
                _mapper = mapper;
                _userRepository = userRepository;
                _userOperationClaimRepository = userOperationClaimRepository;
                _authService = authService;
            }

            public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                //Kullanıcının girdiği şifreyi hashle
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);

                //User objesini oluştur
                User user = new User
                {
                    FirstName = request.UserForRegisterDto.FirstName,
                    LastName = request.UserForRegisterDto.LastName,
                    Email = request.UserForRegisterDto.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true,
                    AuthenticatorType = request.AuthenticatorType
                };
                //User'ı veritabanına ekle
                User addedUser = await _userRepository.AddAsync(user);

                //User'a default 2(user) operationClaim'ini ver
                UserOperationClaim userOperationClaim = new UserOperationClaim
                {
                    UserId = addedUser.Id,
                    OperationClaimId = 2
                };
                await _userOperationClaimRepository.AddAsync(userOperationClaim);

                //AccessToken oluştur
                AccessToken accessToken = await _authService.CreateAccessToken(addedUser);

                RegisteredDto registeredDto = _mapper.Map<RegisteredDto>(addedUser);
                registeredDto.AccessToken = accessToken;
                return registeredDto;
            }
        }
    }
}
