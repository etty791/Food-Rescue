using AutoMapper;
using FoodRescue.Core.DTO;
using FoodRescue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRescue.Core
{
	public class MappingProfile:Profile
	{
		public MappingProfile() 
		{
			CreateMap<Business,BusinessDTO>().ReverseMap();
			CreateMap<Charity,CharityDTO>().ReverseMap();
			CreateMap<Donation, DonationDTO>().ReverseMap();
		}
	}
}
