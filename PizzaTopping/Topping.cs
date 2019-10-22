using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTopping
{
    public interface ITopping
    {
        string[] toppings { get; set; }
    }

    public class Topping : ITopping
    {
        public string[] toppings { get; set; }
    }
}
