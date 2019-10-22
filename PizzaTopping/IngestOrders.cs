using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PizzaTopping
{
    class IngestOrders
    {
        public string GetJsonFromWeb()
        {
            using (WebClient client = new WebClient())
            {
                string result =null;

                try
                {
                    // To do - refactor url to config  
                    result = client.DownloadString("http://files.olo.com/pizzas.json");
                }
                catch (WebException webExp)
                {
                    // log excption
                    Console.Error.WriteLine($"{webExp.Message}");
                }

                return result;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Success - array of ITopping. If Fails return null</returns>
        public ITopping[] GetPizzaToppings(string jsonFile)
        {
            if (jsonFile == null)
                return null;

            ITopping[] iTopping = null;
            try
            {                          
                //var json = File.ReadAllText("App_Data/pizzas.json");

                iTopping = JsonConvert.DeserializeObject<Topping[]>(jsonFile);
            }
            // For local load testing
            //catch (FileNotFoundException fileNotFoundExp)
            //{
            //    // log error
            //    Console.Error.WriteLine($"Json file Not Found. Please check location. {fileNotFoundExp.Message}");
            //}
            catch (Exception exp)
            {
                // catch exception in case json file is not formatted properly
                Console.Error.WriteLine($"{exp.Message}");
            }

            return iTopping;
        }
    }
}
