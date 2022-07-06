using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using MyHelsinkiApp;
using MyHelsinkiActivities;
using MyHelsinkiEvents;

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
            string input = "v2/activity/418816d7-07b7-4501-8139-4fe9c36e6aae";
            Activity haettava = MyHelsinkiApi.GetSingleActivity(input);
            foreach(var i in haettava.availableMonths)
            {
                Console.WriteLine(i);
            }
            

            string input2 = "v1/events/";
            //Place haku = MyHelsinkiApi.GetSingleEvent(input2);

            //Console.WriteLine(haku.name.fi);
            
            // Aadan terveiset
            //Erkin terveiset
            // hetan terveiset


        }
       
    }
   
}
