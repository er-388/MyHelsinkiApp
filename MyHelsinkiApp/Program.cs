using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;

namespace MyHelsinkiApp
{
    class Program
    {
        //private static void GetSingleTrain()
        //{
        //    Console.WriteLine("jotain tähän");
            
        //}
        static void Main(string[] args)
        {
            string input = "v2/place/4";
            Place haettava = MyHelsinkiApi.GetSingleTrain(input);

            Console.WriteLine(haettava.name.fi);
            
            // Aadan terveiset
            //Erkin terveiset
            // hetan terveiset


        }
       
    }
   
}
