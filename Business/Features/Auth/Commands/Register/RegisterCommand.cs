using AutoMapper;
using DataAccess.Abstracts;
using Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business.Features.Auth.Commands.Register
{
    public class RegisterCommand : IRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public class RegisterComandHandler : IRequestHandler<RegisterCommand>
        {
            private readonly IMapper _mapper;
            private readonly IUserRepository _userRepository;

            public RegisterComandHandler(IMapper mapper)
            {
                _mapper = mapper;
            }

            public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                User user = _mapper.Map<User>(request);

                using HMACSHA512 hmac = new();


                user.PasswordHash = hmac.Key;
                user.PasswordSalt = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));

                await _userRepository.AddAsync(user);
                
            }
        }
    }
}
