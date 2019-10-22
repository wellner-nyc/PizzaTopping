using Xunit;
using PizzaTopping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace PizzaTopping.Tests
{
    public class PizzaCalcEngineTests
    {
        public PizzaCalcEngineTests()
        {

        }

        [Fact()]
        public void CalculateNumberOfToppings_NullTest()
        {            
            PizzaCalcEngine pCalcEng = new PizzaCalcEngine();
            Dictionary<string, int> results = pCalcEng.CalculateNumberOfToppings(true, 3, null);
            Assert.True(results == null);
        }

        [Fact()]
        public void CalculateNumberOf3Toppings_Test()
        {
            PizzaCalcEngine pCalcEng = new PizzaCalcEngine();
            Dictionary<string, int> results = pCalcEng.CalculateNumberOfToppings(true, 3, MoqTopping(55));
            Assert.True(results.Count() == 3);
        }

        [Fact()]
        public void CalculateNumberOf10Toppings_Test()
        {
            PizzaCalcEngine pCalcEng = new PizzaCalcEngine();
            Dictionary<string, int> results = pCalcEng.CalculateNumberOfToppings(true, 10, MoqTopping(55));

            // We only have 4 different toppings
            Assert.False(results.Count() == 10);
        }

        private Topping[] MoqTopping(int numberElements)
        {
            IList<Topping> moqArr = new List<Topping>();
            for(int x=0; x<numberElements; x++)
            {
                Topping mq = new Mock<Topping>().Object;           
                switch((x + 1) / 5)
                {
                    case 1:
                        mq.toppings = new string[] { "Falfel", "pepperoni", "corn", "2345" };
                        break;
                    case 2:
                        mq.toppings = new string[] { "pepperoni"};
                        break;
                    case 3:
                        mq.toppings = new string[] { "corn", "2345" };
                        break;
                    default:
                        mq.toppings = new string[] { "pepperoni" };
                        break;
                }
                
                moqArr.Add(mq);
            }
            return moqArr.ToArray();
        }

    }
}