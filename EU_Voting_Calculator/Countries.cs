using System;
using System.Collections.Generic;
using System.Text;

namespace EU_Voting_Calculator
{
    public class Countries
    {
        
        public enum vote_options //enum is a enumeration for specific values
        {
            Yes, 
            No,
            Abstain
        }
        public int vote_option { get; set; }
        public string Name { get; set; } 
        private double _population; 
        public double Population 
        {
            get //This gets the backing variable
            {
                return _population; 
            }
            set { //Set the backing variable
                if (value < 0) //If the value passed is less than 0
                {
                    _population = 0;
                }
                else 
                {
                    _population = value; //The value that is passed to the population variable is set the backing varaiable _population
                }
            }
        }
        public Countries(string newName, double newPopulation) 
        {
            Name = newName; //String country.Name gets and sets
            Population = newPopulation; //Double country.Population gets and sets
        }
    }
}
