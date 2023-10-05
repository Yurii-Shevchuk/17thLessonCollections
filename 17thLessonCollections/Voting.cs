using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17thLessonCollections
{
    internal class Voting
    {
        private List<VotingOption> _options;
        private string _votingTopic;

        public Voting(string  votingTopic, List<VotingOption> options)
        {
            _votingTopic = votingTopic;
            _options = options;
        }

        public int numOfOptions => _options.Count;

        public string VotingTopic => _votingTopic;

        public List<VotingOption> Options => _options;
        
    }
}
