using System;
using System.Collections.Generic;
using System.Text;
using APIHelpers;
using System.Threading.Tasks;
using MyHelsinkiApp;
using MyHelsinkiActivities;
using MyHelsinkiEvents;

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
    public static async Task<Event> GetSingleEvent(string trainName)
    {
        string urlParams = trainName;
        var response = await ApiHelper.RunAsync<Event>(url, urlParams);

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
        public static async Task<PlaceList> GetPlaces()
        {
            string eventUrl = url + "/v1/places/";

            string urlParams = "";

            var response = await ApiHelper.RunAsync<PlaceList>(eventUrl, urlParams);
            return response;

        }
        public static async Task<ActivityList> GetActivities(int limit)
        {
            string ActivityUrl = url + "/v2/activities";
            string urlParams = "?limit=" + limit;

            var response = await ApiHelper.RunAsync<ActivityList>(ActivityUrl, urlParams);
            return response;
        }
    }
    }
    
    


