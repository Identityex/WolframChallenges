using System;
using System.Collections.Generic;

namespace WolframEntities.Models
{
    public partial class Challenges
    {
        public int ChallengeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ChallengeTypeId { get; set; }
        public int? ChallengeStatusId { get; set; }

        public virtual ChallengeStatuses ChallengeStatus { get; set; }
        public virtual ChallengeTypes ChallengeType { get; set; }
    }
}
