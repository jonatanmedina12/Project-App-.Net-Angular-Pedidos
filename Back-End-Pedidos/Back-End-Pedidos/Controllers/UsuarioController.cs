using Data;
using Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Models.Entidades;
using System.Security.Cryptography;
using System.Text;

namespace Back_End_Pedidos.Controllers
{

    public class UsuarioController : BaseController
    {
        private readonly ApplicationDbContext _db;
        private readonly ITokenServicio _tokenServicio;

        public UsuarioController(ApplicationDbContext db, ITokenServicio tokenServicio)
        {
            _db = db;
            _tokenServicio = tokenServicio;

        }
        [HttpPost("registro")]
        public async Task<ActionResult<UsuarioDto>> Registro(RegistroDto registroDto)
        {

            if (await UsuarioExiste(registroDto.Username)) return BadRequest("UserName ya esta Registrado");

            using var hmac = new HMACSHA512();
            var usuario = new Usuario
            {
                Username = registroDto.Username,
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registroDto.Password)),
                passwordSalt = hmac.Key
            };
            _db.Usuarios.Add(usuario);
            await _db.SaveChangesAsync();
            return new UsuarioDto
            {
                Username = usuario.Username,
                Token = _tokenServicio.CrearToken(usuario)
            };

        }
        private async Task<bool> UsuarioExiste(string Username)
        {

            return await _db.Usuarios.AnyAsync(u => u.Username == Username.ToLower());

        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioDto>> Login(LoginDto loginDto)
        {
            var usuario = await _db.Usuarios.SingleOrDefaultAsync(x => x.Username == loginDto.Username);
            if (usuario == null) return Unauthorized("Usuario no válido");

            using var hmac = new HMACSHA512(usuario.passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            if (!computedHash.SequenceEqual(usuario.passwordHash))
                return Unauthorized("Contraseña no válida");

            return new UsuarioDto
            {
                Username = usuario.Username,
                Token = _tokenServicio.CrearToken(usuario),
            };
        }

    }
}
