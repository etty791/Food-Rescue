using FoodRescue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Core.Repositories
{
	public interface IBusinessRepository
	{
		public Task<IEnumerable<Business>> GetAllAsync();
		public Task<Business> GetByIdAsync(int id);
		public Task<Business> GetByNameAsync(string name);

		public Task AddAsync(Business val);
		public Task DeleteAsync(int id);
		public Task UpdateAsync(int id, Business value);
		public Task SaveAsync();
	}
}
