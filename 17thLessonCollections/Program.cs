using System.Collections.Generic;

namespace _17thLessonCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our voting system. Please create a voting to be able to use it");
            VotingSystem voting = CreateVotingFromConsole();
            var showVotingTopic = (VotingSystem voting) => Console.WriteLine($"Current voting topic is: {voting.Voting.VotingTopic}");
            while (true)
            {
                Console.WriteLine("Please choose one of the options below");
                Console.WriteLine("\n");
                Console.WriteLine("1. Create a new voting");
                Console.WriteLine("2. Vote");
                Console.WriteLine("3. Count votes");
                Console.WriteLine("\n");
                Console.Write("Please choose an option: ");
                int input;
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Your input was incorrect, please try again");
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("There is no possible way this program could have THIS many functions, try better");
                    continue;
                }
                switch (input)
                {
                    case 1:
                        voting = CreateVotingFromConsole();
                        break;

                    case 2:
                        showVotingTopic(voting);
                        ReadVoteFromConsole(voting);
                        break;
                    case 3:
                        showVotingTopic(voting);
                        Console.WriteLine();
                        voting.CountVotes();
                        Console.WriteLine();
                        voting.ShowVoters();
                        Console.WriteLine();
                        
                        break;
                }

                
            }

            static void ReadVoteFromConsole(VotingSystem voting)
            {
                Console.Write("Enter name of a voter: ");
                string voterName = Console.ReadLine().Trim();
                Console.WriteLine("Now type one of the options you'd like to vote for:");
                foreach (var option in voting.VotingOptions)
                {
                    Console.WriteLine(option);
                }
                string votingOption = Console.ReadLine().Trim();
                VotingOption match = voting.VotingOptions.Find(vote => vote.ToString().ToLower().Contains(votingOption.ToLower()));
                if (match == null)
                {
                    Console.WriteLine("Error processing your option, try again");
                    return;
                }
                else
                {
                    voting.Vote(match, new User(voterName, false));
                }
            }

            static VotingSystem CreateVotingFromConsole()
            {
                List<VotingOption> options = new List<VotingOption>();
                Console.Write("Enter voting topic: ");
                string votingTopic = Console.ReadLine().Trim();

                Console.Write("Enter amount of options: ");
                int amountOfOptions = int.Parse(Console.ReadLine().Trim());
                for (int i = 0; i < amountOfOptions; i++)
                {
                    Console.Write($"Enter voting option number {i + 1} of total {amountOfOptions}: ");
                    string votingOption = Console.ReadLine().Trim();
                    options.Add(new VotingOption(votingOption));
                }
                return new VotingSystem(votingTopic, options);
            }
        }
    }
}