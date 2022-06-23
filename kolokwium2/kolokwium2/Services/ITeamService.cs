﻿using kolokwium2.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Services
{
  public  interface ITeamService
    {
        Task<SortOfTeam> GetTeamAsync(int TeamID);
        Task AddMember(SortOfMemberRequest newMember);
    }
}
