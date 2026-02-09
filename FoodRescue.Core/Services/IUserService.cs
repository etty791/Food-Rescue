using FoodRescue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Core.Services
{
	public interface IUserService
	{
		public Task<IEnumerable<User>> GetUsersAsync();
		public Task<User> GetUserByIdAsync(int id);
		public Task<User> AddUserAsync(User val);
		public Task DeleteUserAsync(int id);
		public Task UpdateUserAsync(int id, User val);
		Task<User> GetUserByCredentialsAsync(string userName, string password);
		Task<bool> IsUserNameTakenAsync(string userName);
	}
}
