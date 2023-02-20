using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_DotnetCore.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SuperHeroController : ControllerBase
	{
		private static List<SuperHero> heroes = new List<SuperHero>
			{
				new SuperHero
				{
					Id = 1,
					Name = "Spider Man",
					FirstName = "Hamza",
					LastName = "Ahmad",
					Place = "Bahria Town"
				},
				new SuperHero
				{
					Id = 2,
					Name = "Super Man",
					FirstName = "Talat",
					LastName = "Naeem",
					Place = "Kot Momin"
				}
			};
		[HttpGet]
		public async Task<ActionResult<List<SuperHero>>> Get()
		{
			return Ok(heroes);
		}
		[HttpGet ("{id}")]
		public async Task<ActionResult<SuperHero>> GetHerobyId(int id)
		{
			//return heroes[id];
			var hero = heroes.Find(h => h.Id == id);
			if (hero == null)
			{
				return BadRequest("Hero Not Found");
			}
			return Ok(hero);
		}
		[HttpPost]
		public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
		{
			heroes.Add(hero);
			return Ok(heroes);
		}
		[HttpPut]
		public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
		{
			var hero = heroes.Find(h => h.Id == request.Id);
			if (hero == null)
			{
				return BadRequest("Hero Not Found");
			}
			hero.Name = request.Name;
			hero.FirstName = request.FirstName;
			hero.LastName = request.LastName;
			hero.Place = request.Place;
			return Ok(heroes);
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult<SuperHero>> DeleteHero(int id)
		{
			//return heroes[id];
			var hero = heroes.Find(h => h.Id == id);
			if (hero == null)
			{
				return BadRequest("Hero Not Found");
			}
			heroes.Remove(hero);
			return Ok(heroes);
		}
	}
}
