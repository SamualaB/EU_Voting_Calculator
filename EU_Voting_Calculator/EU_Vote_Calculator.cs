using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Voting_Calculator_Version_1
{
    class EU_Vote_Calculator 
    { 
        public static (double,decimal) yes_votes(List<Countries> countries) //ualified Majority voting rule 
        { 
            var x = from country in countries //Each individual country
                    where country.vote_option == (int)Countries.vote_options.Yes //Checks for the yes votes 
                    select country; 

            double population = default; //Sets population to default value

            for(int i = 0; i < x.Count(); i++) //Increments the population 
            {
                population += x.ElementAt(i).Population; 
            }

            return (x.Count(),(decimal)population); //Returns the the count iteration for the votes
        }
    }
}
