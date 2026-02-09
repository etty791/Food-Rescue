using FoodRescue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Core.Repositories
{
    public interface IUserRepository
    {
		public Task<IEnumerable<User>> GetAllAsync();
		public Task<User> GetByIdAsync(int id);

		public Task AddAsync(User val);
		public Task DeleteAsync(int id);
		public Task UpdateAsync(int id, User value);
		public Task SaveAsync();

		Task<User> GetByCredentialsAsync(string userName, string password);
		Task<bool> ExistsAsync(string userName);

	}
}
