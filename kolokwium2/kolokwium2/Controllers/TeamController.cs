using kolokwium2.Models.DTOs;
using kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : Controller
    {
        private readonly ITeamService teamService;

        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTeamAsync(int id)//change name to Async later
        {
            try
            {
                var team = await teamService.GetTeamAsync(id);
                return Ok(team);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPost]
        public async Task<IActionResult> AddMemberAsync(SortOfMemberRequest newMember)
        {
            try
            {
                await teamService.AddMember(newMember);
                return Ok("Successfully added");
            }
            catch (Exception ex)
            {
                return BadRequest("Member has not been added");
            }

        }
    }
}
