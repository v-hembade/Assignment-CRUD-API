using JwtRoleBase.Context;
using JwtRoleBase.Interfaces;
using JwtRoleBase.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace JwtRoleBase.Services
{
    public class UsersService : IUserService
    {
        private readonly JwtContext _context;

        public  UsersService(JwtContext context)
        {
            _context = context;
        }
        public async Task<Users> AddUser(Users user)
        {
            var u = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return u.Entity;
        }

        public async Task<List<Users>> GetUsersDetails()
        {
            var u =  await _context.Users.ToListAsync();
            return u;
        }

        public async Task<Users> DeleteUser(string id)
        {
            var u = _context.Users.FirstOrDefault(x=> x.id == id);
            _context.Users.Remove(u);
            await _context.SaveChangesAsync();
            return u;
        }

        public async Task<Users> UpdateUser(string id, Users user)
        {
            var u = _context.Users.Find(id);
            u.username = user.username;
            u.password = user.password;
            u.age = user.age;
            u.age = user.age;
            u.Hobbie = user.Hobbie;
            await _context.SaveChangesAsync();
            return u;
        }

        public async Task<Users> GetUser(string id)
        {
            var user = _context.Users.FirstOrDefault(x => x.id == id);
            if (user == null)
                throw new KeyNotFoundException("User not found");

            return user;

        }
    }
}
