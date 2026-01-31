using AutoMapper;
using Food_Rescue.Models;
using FoodRescue.Core.DTO;
using FoodRescue.Core.Entities;
using FoodRescue.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodRescue.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DonationController : ControllerBase
	{
		private readonly IDonationService _donationService;
		private readonly IMapper _mapper;
		public DonationController(IDonationService donationService, IMapper mapper)
		{
			_donationService = donationService;
			_mapper = mapper;
		}
		// GET: api/<BusinessesController>
		[HttpGet]
		public async Task<ActionResult> Get()
		{
			var s = await _donationService.GetDonationsAsync();
			return Ok(_mapper.Map<IEnumerable<DonationDTO>>(s));
		}

		// GET api/<BusinessesController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult> Get(int id)
		{
			var d =await _donationService.GetDonationByIdAsync(id);
			if (d == null)
			{
				return NotFound();
			}
			return Ok(_mapper.Map<DonationDTO>(d));
		}

		// POST api/<BusinessesController>
		[HttpPost]
		public async Task<ActionResult> Post([FromBody] DonationPostModel value)
		{
			var donation = _mapper.Map<Donation>(value);
			await _donationService.AddDonationAsync(donation);
			return Ok(donation);
		}

		// PUT api/<BusinessesController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult> Put(int id, [FromBody] DonationPostModel value)
		{
			var donation = _mapper.Map<Donation>(value);
			donation.Id = id;
			var s =await _donationService.GetDonationByIdAsync(id);
			if (s == null)
			{
				return NotFound();
			}
			await _donationService.UpdateDonationAsync(id, donation);
			return Ok(s);
		}

		// DELETE api/<BusinessesController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var s =await _donationService.GetDonationByIdAsync(id);
			if (s == null)
			{
				return NotFound();
			}
			await _donationService.DeleteDonationAsync(id);
			return Ok(s);

		}
	}
}
