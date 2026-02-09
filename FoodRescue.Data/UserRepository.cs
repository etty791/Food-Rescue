using FoodRescue.Core.Entities;
using FoodRescue.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Data
{
	public class UserRepository : IUserRepository
	{
		private readonly DataContext _context;

		public UserRepository(DataContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<User>> GetAllAsync()
		{
			return await _context.users.ToListAsync();
		}

		public async Task<User> GetByIdAsync(int id)
		{
			return await _context.users.FindAsync(id);
		}

		public async Task AddAsync(User val)
		{
			await _context.users.AddAsync(val);
		}

		public async Task UpdateAsync(int id, User value)
		{
			var existingUser = await GetByIdAsync(id);
			if (existingUser != null)
			{
				existingUser.UserName = value.UserName;
				existingUser.Password = value.Password;
				existingUser.Role = value.Role;
			}
		}

		public async Task DeleteAsync(int id)
		{
			var user = await GetByIdAsync(id);
			if (user != null)
			{
				_context.users.Remove(user);
			}
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync();
		}

		public async Task<User> GetByCredentialsAsync(string userName, string password)
		{
			return await _context.users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
		}

		public async Task<bool> ExistsAsync(string userName)
		{
			return await _context.users.AnyAsync(u => u.UserName == userName);
		}
	}
}
