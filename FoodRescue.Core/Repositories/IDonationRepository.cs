using FoodRescue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Core.Repositories
{
	public interface IDonationRepository
	{
		public Task<IEnumerable<Donation>> GetAllAsync();
		public Task<Donation> GetByIdAsync(int id);
		public Task AddAsync(Donation val);
		public Task DeleteAsync(int id);
		public Task UpdateAsync(int id, Donation value);
		public Task SaveAsync();
		public Task<IEnumerable<Donation>> GetByBusinessIdAsync(int businessId);

	}
}
