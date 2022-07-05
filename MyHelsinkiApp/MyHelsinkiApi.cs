using System;
using System.Collections.Generic;
using System.Text;
using APIHelpers;
using PlacePlace;

namespace MyHelsinkiApp
{

        public static class MyHelsinkiApi
    {
        const string url = "https://open-api.myhelsinki.fi/";//Loppuosa: trains/latest/1
        public static Place GetSingleEvent(string trainName)
        {
            string urlParams = trainName;
            var response = ApiHelper.RunAsync<Place>(url, urlParams).GetAwaiter().GetResult();

            return response;
        }

        
    }
    
    }

