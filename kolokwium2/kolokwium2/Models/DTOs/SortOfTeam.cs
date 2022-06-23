using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Models.DTOs
{
    public class SortOfTeam
    {
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public SortOfOrganization Organization { get; set; }
        public IEnumerable<SomeSortOfMember> Members { get; set; }

    }
}
