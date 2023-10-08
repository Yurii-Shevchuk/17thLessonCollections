using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17thLessonCollections
{
    internal class VotingSystem
    {
        private Dictionary<User, VotingOption> _userVotes = new Dictionary<User, VotingOption>();
        private List<VotingOption> _votingOptions;
        private Voting _voting;
        public VotingSystem(string votingTopic, List<VotingOption> options)
        {
            _voting = CreateNewVoting(votingTopic, options);
            _votingOptions = _voting.Options;
        }

        public Dictionary<User, VotingOption> UserVotes => _userVotes;

        public List<VotingOption> VotingOptions => _votingOptions;

        public Voting Voting => _voting;

        public Voting CreateNewVoting(string votingTopic, List<VotingOption> options)
        {
            return new Voting(votingTopic, options);
        }

        public bool Vote(VotingOption option, User user) 
        {
            if(UserVotes.TryAdd(user, option) && !user.HasVoted)
            {
                user.HasVoted = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CountVotes()
        {
            foreach(var votingOption in VotingOptions)
            {
                Console.WriteLine($"\"{votingOption.ToString()}\" has got {UserVotes.Values.Count(vote => vote == votingOption)} vote(s).");
            }
            Console.WriteLine($"Total number of votes is {UserVotes.Count}");
        }

        public void ShowVoters()
        {
            foreach (KeyValuePair<User, VotingOption> kv in UserVotes)
            {
                Console.WriteLine($"{kv.Key.Name} has voted for {kv.Value}");
            }
        }
    }
}
