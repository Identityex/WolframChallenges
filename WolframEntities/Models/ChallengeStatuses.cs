using System;
using System.Collections.Generic;

namespace WolframEntities.Models
{
    public partial class ChallengeStatuses
    {
        public ChallengeStatuses()
        {
            Challenges = new HashSet<Challenges>();
        }

        public int ChallengeStatusId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Challenges> Challenges { get; set; }
    }
}
