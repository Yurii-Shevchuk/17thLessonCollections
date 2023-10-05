using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17thLessonCollections
{
    internal class VotingOption
    {
        private string _voteOption;

        public VotingOption(string voteOption)
        {
            _voteOption = voteOption;
        }

        public string VoteOption => _voteOption;

        public override string ToString()
        {
            return $"{VoteOption}";
        }
    }
}
