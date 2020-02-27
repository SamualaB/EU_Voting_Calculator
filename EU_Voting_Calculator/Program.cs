using System;
using System.Collections.Generic;

namespace EU_Voting_Calculator
{
    class Program 
    {
        static void Main(string[] args) 
        {
            var CountryString = new string[] //List of country names
            {
            "Austria",
            "Belgium",
            "Bulgaria",
            "Croatia",
            "Cyprus",
            "Czech Republic",
            "Denmark",
            "Estonia",
            "Finland",
            "France",
            "Germany",
            "Greece",
            "Hungary",
            "Ireland",
            "Italy",
            "Latvia",
            "Lithuania",
            "Luxemborg",
            "Malta",
            "Netherlands",
            "Poland",
            "Portugal",
            "Romania",
            "Slovakia",
            "Slovenia",
            "Spain",
            "Sweden",
            };

            var PopulationList = new double[] //List of population percentage
            {
               1.98,
               2.56,
               1.56,
               0.91,
               0.20,
               2.35,
               1.30,
               0.30,
               1.23,
               14.98,
               18.54,
               2.40,
               2.18,
               1.10,
               13.65,
               0.43,
               0.62,
               0.14,
               0.11,
               3.98,
               8.49,
               2.30,
               4.34,
               1.22,
               0.47,
               10.49,
               2.29,
            };

            List<Countries> CountryList = new List<Countries>(); 
            for (int i = 0; i < CountryString.Length; i++) //Loop for every item in the string array
            {
                CountryList.Add(new Countries(CountryString[i], PopulationList[i])); //Create an object from the country
            }
            var acceptRegion = 0.55 * CountryList.Count; //Multiply 0.55 by the 27 countries (Qualified majority)
            for (int i = 0; i < CountryList.Count; i++)
            {
                Console.WriteLine($"{EU_Vote_Calculator.yesVotes(CountryList).Item1} , {Math.Round(EU_Vote_Calculator.yesVotes(CountryList).Item2, 2)}"); //Iterates through the list of countries and gets all of the yes votes
                if (EU_Vote_Calculator.yesVotes(CountryList).Item1 > acceptRegion && EU_Vote_Calculator.yesVotes(CountryList).Item2 > 65) 
                {
                    Console.WriteLine("Final result Approved"); 
                }
                else
                {
                    Console.WriteLine("Final result Rejected");
                }

                Console.WriteLine("All Countries are participating");
                Console.WriteLine($"{CountryList[i].Name}, {CountryList[i].Population} \nPlease enter a vote option of Yes, No, Abstain"); //Outputs country list names, population and the string thats in quotes \n makes a newline
                var userinput = Console.ReadLine(); //User input
                switch (userinput.ToLower()) //Input to lowercase
                {
                    case "abstain": 
                        CountryList[i].VoteOption = (int)Countries.VoteOptions.Abstain; //This assigns the values to Yes, No and Abstain
                        break; 
                    case "no":
                        CountryList[i].VoteOption = (int)Countries.VoteOptions.No; //Integer function is used as the enum function assigns the vote options
                        break;
                    default:
                        CountryList[i].VoteOption = (int)Countries.VoteOptions.Yes; //Default vote yes
                        break;
                }


                Console.Clear(); //Clears the information on screen to allow for new information
            }
            for(int i = 0; i < CountryList.Count; i++) //Iterate through country list
            {
                Console.WriteLine($"{CountryList[i].Name}, {CountryList[i].Population}, {(Countries.VoteOptions)CountryList[i].VoteOption}"); //Output the country names, population and vote options
            }
        }
    }
}

