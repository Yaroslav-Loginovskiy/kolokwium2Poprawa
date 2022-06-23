using kolokwium2.Models;
using kolokwium2.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Services
{
    public class TeamService : ITeamService
    {
        private readonly MainContext _context;

        public TeamService(MainContext context)
        {
            context = _context;
        }
        public async Task AddMember(SortOfMemberRequest newMember)
        {
            var member = await _context.Members.Where(e => e.MemberId == newMember.MemberID).FirstOrDefaultAsync();
            if (member == null) throw new Exception();
            _context.Add(new Member { MemberName = newMember.MemberName, MemberSurname = newMember.MemberSurname });
            await _context.SaveChangesAsync();
        }

        public async Task<SortOfTeam> GetTeamAsync(int TeamID)
        {
            var team = await _context.Teams.Where(e => e.TeamId == TeamID).FirstOrDefaultAsync();
            if (team == null) throw new Exception();
            return await _context.Teams
                .Select(e => new SortOfTeam
                {
                    TeamName = e.TeamName,
                    TeamDescription = e.TeamDescription,
                    Organization = new SortOfOrganization { OrganizationName = e.Organization.OrganizationName, OrganizationDomain = e.Organization.OrganizationDomain },
                    Members = e.Memberships.Select(e => new SomeSortOfMember { MemberName = e.Member.MemberName, MemberSurname = e.Member.MemberSurname }).OrderBy(e => e.MemberName)
                }).SingleOrDefaultAsync();
        }
    }
}
