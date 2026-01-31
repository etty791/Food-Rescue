using FoodRescue.Core.DTO;
using FoodRescue.Core.Entities;
using AutoMapper;
using Food_Rescue.Models;

namespace Food_Rescue
{
	public class Mapping:Profile
	{
		public Mapping()
		{
			CreateMap<Business, BusinessPostModel>().ReverseMap();
			CreateMap<Charity, CharityPostModel>().ReverseMap();
			CreateMap<Donation, DonationPostModel>().ReverseMap();
		}
	}
}
