using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTopping
{
    class Program
    {
        static void Main(string[] args)
        {
            IngestOrders lo = new IngestOrders();
            ITopping[] iTopping = lo.GetPizzaToppings(lo.GetJsonFromWeb());
            if(iTopping != null)
            {
                PizzaCalcEngine pizzaCalcEng = new PizzaCalcEngine();
                Dictionary<string, int> toppingsCount = pizzaCalcEng.CalculateNumberOfToppings(true, 20, iTopping);

                int rank = 1;
                foreach(var item in toppingsCount)
                {
                    Console.WriteLine($"Rank {rank}  ;Topping {item.Key}  ;number of times ordered {item.Value}");
                    rank++;
                }
            }            

            Console.ReadLine();       
        }

        
    }
}
