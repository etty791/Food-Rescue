using FoodRescue.Core.Entities;
using FoodRescue.Core.Repositories;
using FoodRescue.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Service
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;

		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		public async Task<User> GetUserByIdAsync(int id)
		{
			return await _userRepository.GetByIdAsync(id);
		}

		public async Task<User> AddUserAsync(User user)
		{
			await _userRepository.AddAsync(user);
			return user;
		}

		public async Task UpdateUserAsync(int id, User user)
		{
			await _userRepository.UpdateAsync(id, user);
			await _userRepository.SaveAsync();
		}

		public async Task DeleteUserAsync(int id)
		{
			await _userRepository.DeleteAsync(id);
			await _userRepository.SaveAsync();
		}

		public async Task<User> GetUserByCredentialsAsync(string userName, string password)
		{
			return await _userRepository.GetByCredentialsAsync(userName, password);
		}

		public async Task<bool> IsUserNameTakenAsync(string userName)
		{
			return await _userRepository.ExistsAsync(userName);
		}
		public async Task<User> GetByUserNameAsync(string userName, string password)
		{
			return await _userRepository.GetByCredentialsAsync(userName, password);
		}

		public async Task<IEnumerable<User>> GetUsersAsync()
		{
			return await _userRepository.GetAllAsync();
		}
	}
}
