using System;
using System.Collections.Generic;

namespace WolframEntities.Models
{
    public partial class ChallengeTypes
    {
        public ChallengeTypes()
        {
            Challenges = new HashSet<Challenges>();
        }

        public int ChallengeTypeId { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Challenges> Challenges { get; set; }
    }
}
