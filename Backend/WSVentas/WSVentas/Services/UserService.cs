﻿using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WSVentas.Models;
using WSVentas.Models.Common;
using WSVentas.Models.Request;
using WSVentas.Models.Response;
using WSVentas.Tools;

namespace WSVentas.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSetting;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSetting = appSettings.Value;
        }


        public UserResponse Auth(AuthRequest model)
        {
            UserResponse userResponse = new UserResponse();

            using (var db = new VentaHDLContext())
            {
                string spassword = Encrypt.GetSHA256(model.Password);

                var usuario = db.Usuario.Where(d => d.Email == model.Email && d.Password == spassword).FirstOrDefault();

                if (usuario == null)
                    return null;

                userResponse.Email = usuario.Email;
                userResponse.Token = GetToken(usuario);
            }
            return userResponse;
        }


        private string GetToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var llave = Encoding.ASCII.GetBytes(_appSetting.Secreto);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                        new Claim[]
                        {
                            new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                            new Claim(ClaimTypes.Email, usuario.Email)
                        }
                    ),
                Expires = DateTime.UtcNow.AddDays(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }


    }
}
