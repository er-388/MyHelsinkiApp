using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using MyHelsinkiApp;
using MyHelsinkiActivities;
using MyHelsinkiEvents;
using System.Collections.Generic;

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
            /* string input = "v2/activity/418816d7-07b7-4501-8139-4fe9c36e6aae";
             Activity haettava = MyHelsinkiApi.GetSingleActivity(input);
             foreach(var i in haettava.availableMonths)
             {
                 Console.WriteLine(i);
             }*/


            //string input2 = "v1/events/";
            //Place haku = MyHelsinkiApi.GetSingleEvent(input2);


            string tag = "Teatteri";
            EventsList haku = await MyHelsinkiApi.GetEvents(20, tag);

            foreach (Event muuta in haku.data)
            {

                Console.WriteLine(muuta.name.fi + "\n" + muuta.location.address.street_address);
            }


            // Aadan terveiset
            //Erkin terveiset
            // hetan terveiset
            Console.WriteLine("****************************************************");
            int numberInput = 4;
            if (numberInput == 4)
            {
                Console.Write("Kirjoita hakusana (tai paina ENTER palataksesi takaisin): ");
                string searchTerm = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(searchTerm) == false)
                {
                    Console.Write("Montako hakutulosta haluat? ");
                    if (Int32.TryParse(Console.ReadLine(), out int searchLimit) == true)
                    {
                        try
                        {
                            IEnumerable<Event> searchResult = await SearchForEvent(searchLimit, searchTerm);
                            
                            if (searchResult.Count() > 0)
                            {
                                foreach (var eventti in searchResult)
                                {
                                    Console.WriteLine(eventti.name.fi);
                                    Console.WriteLine("alkaa " + eventti.event_dates.starting_day);
                                }
                            }
                            
                            else if (searchResult.Count() == 0)
                            {
                                Console.WriteLine("Yhtään tapahtumaa ei löytynyt!");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Yhtään tapahtumaa ei löytynyt!");
                        }
                    }
                }
            }
                
        
        }

        static async Task<IEnumerable<Event>> SearchForEvent(int limit, string searchTerm)//Erkki
        {
            //Hakee API:sta kaikki tapahtumat ja palauttaa limitin verran tapahtumia aikajärjestyksessä seuraavan 60 päivän sisältä
            EventsList searchList = await MyHelsinkiApi.FindAllEvents();
            //Haetaan käyttäjän hakusanalla käyttäjän suodattama määrä tapahtumia
            var results =
                searchList.data.
                Where(e => e.name.fi.ToLower().
                Contains(searchTerm.ToLower()) &&
                e.event_dates.starting_day > DateTime.Now.Date
                && e.event_dates.starting_day < DateTime.Now.AddDays(60)).
                OrderBy(e => e.event_dates.starting_day)
                .Take(limit);
            //var results = searchList.data.Where(e => e.name.fi.ToLower().Contains(searchTerm.ToLower())).Take(limit);

            return results;
        }
       
    }
   
}
