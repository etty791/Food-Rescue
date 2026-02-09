using AutoMapper;
using Food_Rescue.Models;
using FoodRescue.Core.DTO;
using FoodRescue.Core.Entities;
using FoodRescue.Core.Services;
using FoodRescue.Service;
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
		private readonly IUserService _userService;

		public CharitiesController(ICharityService charityService,IMapper mapper, IUserService userService)
        {
            _charityService = charityService;
			_mapper = mapper;
			_userService= userService;	
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
			if (await _userService.IsUserNameTakenAsync(value.UserName))
			{
				return Conflict("User name already exists");
			}

			var userEntity = new User { UserName = value.UserName, Password = value.Password, Role = eRole.Charity };
			var createdUser = await _userService.AddUserAsync(userEntity);

			var charity = _mapper.Map<Charity>(value);
			charity.User = createdUser;
			charity.UserId = createdUser.Id;

			await _charityService.AddCharityAsync(charity);

			return Ok();
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
			var user = await _userService.GetUserByIdAsync(charity.UserId);
			if (user != null)
			{
				user.UserName = value.UserName;
				user.Password = value.Password;
				await _userService.UpdateUserAsync(user.Id, user);
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
			await _userService.DeleteUserAsync(id);
			await _charityService.DeleteCharityAsync(id);	
			return Ok(c);

		}
	}
}
