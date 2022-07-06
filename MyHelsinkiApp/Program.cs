using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using MyHelsinkiApp;
using MyHelsinkiActivities;
using MyHelsinkiEvents;
using MyHelsinkiPlaces;

namespace MyHelsinkiApp
{
    class Program
    {
        //private static void GetSingleTrain()
        //{
        //    Console.WriteLine("jotain tähän");
            
        //}


        static async Task Main(string[] args)
        {
           /*string input = "v2/activity/418816d7-07b7-4501-8139-4fe9c36e6aae";
            Activity haettava = MyHelsinkiApi.GetSingleActivity(input);
            foreach(var i in haettava.availableMonths)
            {
                Console.WriteLine(i);
            }*/
            

            //string input2 = "v1/events/";
            //Place haku = MyHelsinkiApi.GetSingleEvent(input2);

            
            string tag = "Teatteri";
            EventsList haku = await MyHelsinkiApi.GetEvents(20, tag);

            foreach(Event muuta in haku.data)
            {

                Console.WriteLine(muuta.name.fi + "\n" + muuta.location.address.street_address);
            }


            //hetan places:
            //string tag2 = "RecordStore";
            Console.WriteLine(""); // esim. Souvenirs, RecordStore, Academy, Jewellery, Finnish jne
           // Console.WriteLine("");
            string tag2 = Console.ReadLine();
            PlacesList A = await MyHelsinkiApi.GetPlaces(10, tag2);

            foreach (Place TÄMÄ in A.data)
            {

                Console.WriteLine(TÄMÄ.name.fi + "\n" + TÄMÄ.info_url + "\n" + TÄMÄ.location.address.street_address); 
            }


            /*
            Console.WriteLine("Haluatko etsiä paikkaa X?");
            Console.Write("Vastaa Y/N");
            string userChoice = Console.ReadLine();


            string message = " ";
            if (userChoice == "Y")
            {
                message = "Tähän se viesti kun löytyi.";
            }
            else if (userChoice == "N")
            {
                message = "Valitettavasti tätä ei löytynyt";

            }
            Console.WriteLine(message);*/


            // Aadan terveiset
            //Erkin terveiset
            // hetan terveiset


        }
       
    }
   
}
