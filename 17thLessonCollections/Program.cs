using System.Collections.Generic;

namespace _17thLessonCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VotingSystem voting = null;
            Console.WriteLine("Welcome to our voting system. Please choose one of the options below");

            while (true)
            {
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
                        if(voting == null)
                        {
                            Console.WriteLine("Currently there's no voting, go create a new one");
                        }
                        else
                        {
                            Console.Write("Enter name of a voter: ");
                            string voterName = Console.ReadLine().Trim();
                            Console.WriteLine("Now type one of the options you'd like to vote for:");
                            foreach(var option in voting.VotingOptions)
                            {
                                Console.WriteLine(option);
                            }
                            string votingOption = Console.ReadLine().Trim();
                            VotingOption match = voting.VotingOptions.Find(vote => vote.ToString().ToLower().Contains(votingOption.ToLower()));
                            if(match == null)
                            {
                                Console.WriteLine("Error processing your option, try again");
                                continue;
                            }
                            else
                            {
                                voting.Vote(match, new User(voterName, false));
                            }
                        }
                        break;
                    case 3:
                        if (voting == null)
                        {
                            Console.WriteLine("Currently there's no voting, go create a new one");
                        }
                        else
                        {
                            voting.CountVotes();
                            voting.ShowVoters();
                        }
                            break;
                }

                static VotingSystem CreateVotingFromConsole()
                {
                    List<VotingOption> options = new List<VotingOption>();
                    Console.Write("Enter voting topic: ");
                    string votingTopic = Console.ReadLine().Trim();

                    Console.Write("Enter amount of options: ");
                    int amountOfOptions = int.Parse(Console.ReadLine().Trim());
                    for(int i = 0; i< amountOfOptions; i++)
                    {
                        Console.Write($"Enter voting option number {i+1} of total {amountOfOptions}: ");
                        string votingOption = Console.ReadLine().Trim();
                        options.Add(new VotingOption(votingOption));
                    }
                    return new VotingSystem(votingTopic, options);
                }
            }
        }
    }
}