using FoodRescue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Core.Services
{
	public interface IBusinessService
	{
		public Task<IEnumerable<Business>> GetBusinessesAsync();
		public Task<Business> GetBusinessByNameAsync(string name);
		public Task<Business> GetBusinessByIdAsync(int id);
		public Task AddBusinessAsync(Business val);
		public Task DeleteBusinessAsync(int id);
		public Task UpdateBusinessAsync(int id,Business val);
	}
}
