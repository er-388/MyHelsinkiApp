using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using PlacePlace;
using MyHelsinkiApp;

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
            Place haettava = MyHelsinkiApi.GetSingleEvent(input);

            Console.WriteLine(haettava.name.fi);

            string input2 = "v1/event/linkedevents:agg-182";
            Place haku = MyHelsinkiApi.GetSingleEvent(input2);

            Console.WriteLine(haku.name.fi);

            
            // Aadan terveiset
            //Erkin terveiset
            // hetan terveiset


        }
       
    }
   
}
