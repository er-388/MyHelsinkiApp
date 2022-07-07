using System;
using System.Collections.Generic;
using System.Text;
using APIHelpers;
using System.Threading.Tasks;
using MyHelsinkiApp;
using MyHelsinkiActivities;
using MyHelsinkiEvents;
using MyHelsinkiPlaces;  //tämä lisätty /heta

namespace MyHelsinkiApp
{

    public static class MyHelsinkiApi
    {
        const string url = "https://open-api.myhelsinki.fi";//Loppuosa: trains/latest/1
        public static Place GetSinglePlace(string trainName)
        {
            string urlParams = trainName;
            var response = ApiHelper.RunAsync<Place>(url, urlParams).GetAwaiter().GetResult();

            return response;
        }



        public static Activity GetSingleActivity(string trainName)
        {
            string urlParams = trainName;
            var response = ApiHelper.RunAsync<Activity>(url, urlParams).GetAwaiter().GetResult();

            return response;
        }
        public static Event GetSingleEvent(string trainName)
        {
            string urlParams = trainName;
            var response = ApiHelper.RunAsync<Event>(url, urlParams).GetAwaiter().GetResult();

            return response;
        }

        public static async Task<EventsList> GetEvents(int limit, string tag)
        {
            string eventUrl = url + "/v1/events/";

            string urlParams = "";

            if (limit > 0)
            {
                urlParams = "?limit=" + limit + "&tags_search=" + tag;
            }

            var response = await ApiHelper.RunAsync<EventsList>(eventUrl, urlParams);
            return response;

        }


        /* public static async Task<EventsList> EventSearch(int hakuNro, string tag)
         {
             bool found = true;

             Console.WriteLine("Mitä haluat hakea?");
             Console.WriteLine("Aktiviteetteja - Paina 1.");
             Console.WriteLine("Tapahtumia - Paina 2.");
             Console.WriteLine("Paikkoja - Paina 3.");

             int hakuNro = int.Parse(Console.ReadLine());

             if( hakuNro == 2)
             {
                     Console.WriteLine("Syötä hakusana");
                     string hakusana = Console.ReadLine();

                     while(found == true)
                     {
                         try
                         {
                             EventsList hakuja = await MyHelsinkiApi.EventSearch(20, tag);
                             Console.WriteLine(hakuja);

                         foreach (Event cityEvent in hakuja.data)
                             {

                                 Console.WriteLine(hakuja.data + "\n" + hakuja.data);
                                 break;
                             }
                         return hakuja;
                     }

                         catch(Exception)
                         {
                             Console.WriteLine("Hakusanalla ei löytynyt tapahtumia.");
                             continue;
                         }


                     }

             }*/





        public static async Task<PlacesList> GetPlaces(int limit, string tag) // tämä lisätty kokonaan / heta
        {
            string placeUrl = url + "/v1/places/";

            string urlParams = "";

            if (limit > 0)
            {
                urlParams = "?limit=" + limit + "&tags_search=" + tag;
            }

            var response = await ApiHelper.RunAsync<PlacesList>(placeUrl, urlParams);
            return response;

        }
    }

}
    
    


