using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaTopping
{
    public class PizzaCalcEngine
    {        
        public Dictionary<string, int> CalculateNumberOfToppings(Boolean sort, int topCount, ITopping[] pizzaToppings )
        {
            if (pizzaToppings == null)
                return null;

            Dictionary<string, int> toppingsCount = new Dictionary<string, int>();

            foreach (var pizzaTopping in pizzaToppings)
            {
                if(pizzaTopping.toppings != null)
                {
                    foreach (var toppingName in pizzaTopping.toppings)
                    {
                        // remove white space and change to lower case for better matching
                        if (toppingsCount.ContainsKey(toppingName.ToLower().Trim()))
                        {
                            // increase counter
                            toppingsCount[toppingName.ToLower().Trim()]++;
                        }
                        else
                        {
                            toppingsCount.Add(toppingName.ToLower().Trim(), 1);
                        }
                    }
                }
            }

            // Added sort flag in case this library could be used with non-sorting results 
            if (sort)
            {
                return toppingsCount.OrderByDescending(entry => entry.Value)
                        .Take(topCount)
                        .ToDictionary(x => x.Key, x => x.Value);                
            }
            else
            {
                return toppingsCount;
            }           
        }
            
    }
}
