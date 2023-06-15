using APT_Storage.DataAccess.Data_Context;
using APT_Storage.DataAccess.Repository.Contracts;
using APT_Storage.Domain.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APT_Storage.DataAccess.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> CreateUserAsync(User user)
        {
            var newUser = await _context.AddAsync(new User());
            if(newUser != null)
            {
                return newUser.Entity;
            }
            return null;
        }

        public async Task<User> DeleteUserAsync(int userId)
        {
            //var userToDelete = _context.Users.Find(userId);
            var userToDelete = _context.Users.Where(x => x.Id == userId).FirstOrDefault();
            if(userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                _context.SaveChanges();
            }
            return null;
        }

        public async Task<ICollection<User>> GetAllUsers()
        {
             return _context.Users.ToList();
        }

        //public Task<ICollection<User>> GetAllUsersOrderedByDateCreated(DateOnly date)
        //{
        //    _context.Users.OrderBy(user => user.DateCreated).Tolist();
        //}

        public Task<User> GetUserById(int userId)
        {

            var userById = _context.Users.FirstOrDefault(x => x.Id == userId);
            return Task.FromResult(userById);
        }

        public Task<User> UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            _context.SaveChangesAsync();
            return Task.FromResult(user);
        }
    }
}
