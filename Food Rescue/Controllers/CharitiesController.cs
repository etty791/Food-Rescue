using AutoMapper;
using Food_Rescue.Models;
using FoodRescue.Core.DTO;
using FoodRescue.Core.Entities;
using FoodRescue.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FoodRescue.API.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class CharitiesController : ControllerBase
    {
		private readonly ICharityService _charityService;
		private readonly IMapper _mapper;

		public CharitiesController(ICharityService charityService,IMapper mapper)
        {
            _charityService = charityService;
			_mapper = mapper;
        }
        // GET: api/<BusinessesController>
        [HttpGet]
		public async Task<ActionResult> Get()
		{
			var c =await _charityService.GetCharitiesAsync();
			return Ok(_mapper.Map<List<CharityDTO>>(c));
		}

		// GET api/<BusinessesController>/5
		[HttpGet("{id}")]
		public async Task<ActionResult> Get(int id)
		{
			var c =await _charityService.GetCharityByIdAsync(id);
			if (c == null)
			{
				return NotFound();
			}
			return Ok(_mapper.Map<CharityDTO>(c));
		}

		// POST api/<BusinessesController>
		[HttpPost]
		public async Task<ActionResult> Post([FromBody] CharityPostModel value)
		{
			var charity = _mapper.Map<Charity>(value);

			var c =await _charityService.GetCharityByNameAsync(value.Name);
			if (c == null)
			{
				await _charityService.AddCharityAsync(charity);
				return Ok();
			}
			return Conflict();
		}

		// PUT api/<BusinessesController>/5
		[HttpPut("{id}")]
		public async Task<ActionResult> Put(int id, [FromBody] CharityPostModel value)
		{
			var charity = _mapper.Map<Charity>(value);
			charity.Id = id;
			var c =await _charityService.GetCharityByNameAsync(value.Name);
			if (c == null)
			{
				return NotFound();
			}
			await _charityService.UpdateCharityAsync(id, charity);
			return Ok();
		}

		// DELETE api/<BusinessesController>/5
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var c =await _charityService.GetCharityByIdAsync(id);
			if (c == null)
			{
				return NotFound();
			}
			await _charityService.DeleteCharityAsync(id);	
			return Ok(c);

		}
	}
}
