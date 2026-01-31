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
	public class BusinessService : IBusinessService
	{
		private readonly IBusinessRepository _businessRepository;
        public BusinessService(IBusinessRepository businessRepository)
        {
            _businessRepository = businessRepository;
        }

		public async Task AddBusinessAsync(Business val)
		{
			await _businessRepository.AddAsync(val);
			await _businessRepository.SaveAsync();
		}

		public async Task DeleteBusinessAsync(int id)
		{
			await _businessRepository.DeleteAsync(id);
			await _businessRepository.SaveAsync();
		}

		public async Task<Business> GetBusinessByIdAsync(int id)
		{
			return await _businessRepository.GetByIdAsync(id);
		}

		public async Task<IEnumerable<Business>> GetBusinessesAsync()
		{
			return await _businessRepository.GetAllAsync();
		}

		public async Task UpdateBusinessAsync(int id, Business val)
		{
			await _businessRepository.UpdateAsync(id, val);
			await _businessRepository.SaveAsync();
		}

		public async Task<Business> GetBusinessByNameAsync(string name)
		{
			return await _businessRepository.GetByNameAsync(name);
		}
	}
}
