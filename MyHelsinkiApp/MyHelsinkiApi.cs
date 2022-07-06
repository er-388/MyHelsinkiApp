using System;
using System.Collections.Generic;
using System.Text;
using APIHelpers;
using PlacePlace;
using ActivitiesActivities;
using EventEvent;

namespace MyHelsinkiApp
{

        public static class MyHelsinkiApi
    {
        const string url = "https://open-api.myhelsinki.fi/";//Loppuosa: trains/latest/1
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


    }
    
    }

