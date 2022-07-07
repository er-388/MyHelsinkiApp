using System;
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
        public static Place GetSinglePlace(string placeName)
        {
            string urlParams = placeName;
            var response = ApiHelper.RunAsync<Place>(url, urlParams).GetAwaiter().GetResult();

            return response;
        }


        public static async Task<Event> GetSingleEvent(string eventName)
        {
            string urlParams = eventName;
            var response = await ApiHelper.RunAsync<Event>(url, urlParams);

            return response;

        }


        public static Activity GetSingleActivity(string activityName)
        {
            string urlParams = activityName;
            var response = ApiHelper.RunAsync<Activity>(url, urlParams).GetAwaiter().GetResult();

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



        public static async Task<EventsList> FindAllEvents()
        {

            string eventUrl = url + "/v1/events/";

            string urlParams = "";


            EventsList searchList = await ApiHelper.RunAsync<EventsList>(eventUrl, urlParams);

            return searchList;
        }



        public static async Task<ActivityList> GetActivities(int limit)
        {
            string ActivityUrl = url + "/v2/activities";
            string urlParams = "?limit=" + limit;

            var response = await ApiHelper.RunAsync<ActivityList>(ActivityUrl, urlParams);
            return response;
        }

        public static async Task<EventsList> EventSearchByTag(int maara, string hakusana)
        {
                {
                    try
                    {
                        EventsList hakuja = await MyHelsinkiApi.GetEvents(maara, hakusana);
                      

                        return hakuja;
                    }

                    catch (Exception)
                    {
                        
                        Console.WriteLine("Hakusanalla ei löytynyt tapahtumia.");
                        EventsList empty = new EventsList();
                        return empty;
              
                }
                


            }

            }

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

    
    


