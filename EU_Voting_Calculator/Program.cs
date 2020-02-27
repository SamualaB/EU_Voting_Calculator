using System;
using System.Collections.Generic;

namespace Voting_Calculator_Version_1 
{
    class Program 
    {
        static void Main(string[] args) 
        {
            var country_string = new string[] //List of country names
            {
            "Austria", "Belgium", "Bulgaria", "Croatia",
            "Cyprus", "Czech Republic", "Denmark", "Estonia",
            "Finland", "France", "Germany", "Greece", 
            "Hungary", "Ireland", "Italy", "Latvia", 
            "Lithuania", "Luxemborg", "Malta", "Netherlands",
            "Poland", "Portugal", "Romania", "Slovakia",
            "Slovenia", "Spain", "Sweden",
            };

            var population_list = new double[] //List of population percentage
            {
               1.98, 2.56, 1.56, 0.91, 0.20,
               2.35, 1.30, 0.30, 1.23, 14.98,
               18.54, 2.40, 2.18, 1.10, 13.65,
               0.43, 0.62, 0.14, 0.11, 3.98,
               8.49, 2.30, 4.34, 1.22, 0.47,
               10.49, 2.29,
            };

            List<Countries> country_list = new List<Countries>(); 
            for (int i = 0; i < country_string.Length; i++) //Loop for every item in the string array
            {
                country_list.Add(new Countries(country_string[i], population_list[i])); //Create an object from the country
            }
            var qual_majority = 0.55 * country_list.Count; //Multiply 0.55 by the 27 countries (Qualified majority)
            for (int i = 0; i < country_list.Count; i++)
            {
                Console.WriteLine("'Yes' votes: " + $"{EU_Vote_Calculator.yes_votes(country_list).Item1}" + ", Population percentage: " + $"{Math.Round(EU_Vote_Calculator.yes_votes(country_list).Item2, 2)}"); //Iterates through the list of countries and gets all of the yes votes
                if (EU_Vote_Calculator.yes_votes(country_list).Item1 > qual_majority && EU_Vote_Calculator.yes_votes(country_list).Item2 > 65) 
                {
                    Console.WriteLine("Outcome: Final result Approved"); 
                }
                else
                {
                    Console.WriteLine("Outcome: Final result Rejected");
                }

                Console.WriteLine("All Countries are participating");
                Console.WriteLine($"{country_list[i].Name}, {country_list[i].Population} \nPlease enter a vote option of Yes, No, Abstain"); //Outputs country list names, population and the string thats in quotes \n makes a newline
                var userinput = Console.ReadLine(); //User input
                switch (userinput.ToLower()) //Input to lowercase
                {
                    case "abstain": 
                        country_list[i].vote_option = (int)Countries.vote_options.Abstain; //This assigns the values to Yes, No and Abstain
                        break; 
                    case "no":
                        country_list[i].vote_option = (int)Countries.vote_options.No; //Integer function is used as the enum function assigns the vote options
                        break;
                    default:
                        country_list[i].vote_option = (int)Countries.vote_options.Yes; //Default vote yes
                        break;
                }


                Console.Clear(); //Clears the information on screen to allow for new information
            }
            for(int i = 0; i < country_list.Count; i++) //Iterate through country list
            {
                Console.WriteLine($"{country_list[i].Name}, {country_list[i].Population}, {(Countries.vote_options)country_list[i].vote_option}"); //Output the country names, population and vote options
            }
        }
    }
}

