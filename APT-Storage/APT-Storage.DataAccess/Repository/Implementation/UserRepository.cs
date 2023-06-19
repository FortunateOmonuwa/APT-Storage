using APT_Storage.DataAccess.Data_Context;
using APT_Storage.DataAccess.Repository.Contracts;
using APT_Storage.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

            try
            {
                if (user != null)
                {
                    await _context.Users.AddAsync(user);
                    await _context.SaveChangesAsync();
                    return user;
                }
                else
                {
                    throw new ArgumentException("The User fields cannot be empty.", nameof(user));
                }
            }

            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("An error occurred while adding the new user.", ex);
            }
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            try
            {
                var userToDelete = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
                if (userToDelete != null)
                {
                    _context.Users.Remove(userToDelete);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception($"User with id {userId} doesn't exist");
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting this user.", ex);
            }

        }

        public async Task<ICollection<User>> GetAllUsers() => await _context.Users.ToListAsync();

        //public async Task<ICollection<User>> GetAllUsersOrderedByDateCreated()
        //{
        //    try
        //    {
        //        var users = await _context.Users.OrderBy(d => d.CreatedAt).ToListAsync();
        //        return users;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("An error occurred while fetching the list of users.", ex);
        //    }
        //}

        //public async Task<ICollection<User>> GetAllUsersInDescendingOrderByDateCreated()
        //{
        //    try
        //    {
        //        var users = await _context.Users.OrderByDescending(d => d.CreatedAt).ToListAsync();
        //        return users;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("An error occurred while fetching the list of users.", ex);
        //    }
        //}


        public async Task<User> GetUserById(int userId)
        {
            try
            {
                var userById = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
                if(userById != null)
                {
                    return userById;
                }
                else
                {
                    throw new Exception ($"User with id {userId} doesn't exist");
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching this user.", ex);
            }
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            try
            {
                var userCheck = await _context.Users.FindAsync(user.Id);
                if (userCheck != null)
                {
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                    return userCheck;
                }
                else
                {
                   throw new Exception($"User doesn't exist");
                }
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException("An error occurred while updating the user details.", ex);
            }

        }
    }
}
