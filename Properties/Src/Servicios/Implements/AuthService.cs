using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog_dotnet_api.Properties.Src.DTOs;
using blog_dotnet_api.Properties.Src.Entities;
using blog_dotnet_api.Properties.Src.Repositories.Interface;
using blog_dotnet_api.Properties.Src.Servicios.Interface;
using Microsoft.AspNetCore.Identity;

namespace blog_dotnet_api.Properties.Src.Servicios.Implements
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IPasswordHasher<User> _pwHash;

        public AuthService(IUserRepository userRepository, ITokenService tokenService, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _pwHash = passwordHasher;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            string message = "Credenciales incorrectar, intente nuevamente.";

            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email.ToString());

            if(user is null){
                throw new Exception(message);
            }

            var hasher = new PasswordHasher<User>();

            var result = hasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);
            if(result == PasswordVerificationResult.Failed){
                throw new Exception(message);
            }

            var token = _tokenService.GenerateTokenAsync(user);

            return token;
        }

        public async Task<string> Register(RegisterDto registerDto)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(registerDto.Email);

            if(existingUser != null){
                throw new InvalidOperationException("El email ya se encuentra registrado.");
            }

            var user = new User {Email = registerDto.Email};
            user.PasswordHash = _pwHash.HashPassword(user, registerDto.Password);

            var result = await _userRepository.AddUser(user);
            
            if(!result){
                throw new InvalidOperationException("Error al registrar usuario");
            }

            var userRegistered = await _userRepository.GetUserByEmailAsync(user.Email) ?? throw new Exception("Error en el servidor.");
            
            var token = _tokenService.GenerateTokenAsync(userRegistered);

            return token;
        } 

    }
}