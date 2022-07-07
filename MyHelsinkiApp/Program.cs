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



        static async Task Main(string[] args)
        {

            bool displayMainMenu = true;
            while (displayMainMenu)
            {
                displayMainMenu = await MainMenu();
            } 
        }


            public static async Task<bool> MainMenu()
            {
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine("    Welcome to My Helsinki app");
                Console.WriteLine("    What would you like to search?");

                Console.WriteLine("    1. Activities in Helsinki Area");
                Console.WriteLine("    2. Events in Helsinki Area");
                Console.WriteLine("    3. Places in Helsinki Area");
                Console.WriteLine("    4. Exit");

                bool userInput = int.TryParse(Console.ReadLine(), out int userChoice);
                if (!userInput)
                {
                    Console.WriteLine("    Wrong format of input, please try to enter numbers");
                    return true;
                }
                else
                {
                    switch (userChoice)
                    {
                        case 1:
                            {
                                bool displayActivityMenu = true;
                                while (displayActivityMenu)
                                {
                                    displayActivityMenu = ActivityMenu().Result;
                                }
                                return true;
                            }
                        case 2:
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

                                
                                return true;
                            }

                        case 3:
                            {
                                return true;
                            }
                        case 4:
                            {
                                Console.WriteLine("    Thank you for using My Helsinki App, hope to see you again!");
                                return false;
                            }

                        default:
                            {
                                Console.WriteLine("    Wrong format of input, please try to enter numbers 1-4");
                                return false;
                            }
                    }
                }
            }


            
        

        public static async Task<bool> ActivityMenu()
        {
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("    How would you like to search for activities?");

            Console.WriteLine("    1. Search by city name");
            Console.WriteLine("    2. Search by opening month");
            Console.WriteLine("    3. Search by category");
            Console.WriteLine("    4. Automatic recommendation");
            Console.WriteLine("    5. Exit");
            
            

            bool userInput = int.TryParse(Console.ReadLine(), out int userChoice);
            if (!userInput)
            {
                Console.WriteLine("Wrong format of input, please try to enter numbers");
                return true;
            }
            else
            {
                // get all activities
                ActivityList activityList = await GetAllActivities(152);
                switch (userChoice)
                {
                    case 1:
                        {
                            // check city name
                            SearchByCity(activityList);
                            
                            return true;
                        }
                    case 2:
                        {
                            // check months
                            SearchByMonth(activityList);
                            return true;
                        }
                    case 3:
                        {
                            // check tags
                            SearchByMonth(activityList);
                            return true;
                        }
                    case 4:
                        {
                            // automatic recommendadtion
                            AutomaticRecommendation(activityList);
                            return true;
                        }
                    case 5:
                        {
                            Console.WriteLine("Returning to the main menu...");
                            return false;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong format of input, please try to enter numbers 1-5");
                            return false;
                        }
                }
            }
        }
        public static async Task<ActivityList> GetAllActivities(int limit)
        {
            ActivityList activityList = await MyHelsinkiApi.GetActivities(limit);
            return activityList;
        }
        public static void SearchByCity(ActivityList activityList)
        {
            // display menu
            Console.WriteLine("    1. Search by city name");
            Console.WriteLine("    Please enter a city name ");
            string cityName = Console.ReadLine();
            Console.WriteLine("    Do you want to limit the results returned? We usually return 10 results.");
            Console.WriteLine("    Type 1-100 to change the number or any letter to skip this. ");
            // set the limit of displayed results
            int limit = 10;
            // check if user wants to change the limit 
            // and if the limit between 1 and 100
            if (int.TryParse(Console.ReadLine(), out int limitChange))
            {
                if (0 < limitChange && limitChange < 101)
                    limit = limitChange;
            }
            // a new list to save search result
            List<Activity> searchResult = new List<Activity>();
            foreach (Activity activity in activityList.rows)
            {
                if (searchResult.Count < limit)
                {
                    // check city name
                    if (activity.address.city.ToLower() == cityName.ToLower())
                    {
                        searchResult.Add(activity);
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    break;
                }
            }
            // display the result
            foreach (Activity activity in searchResult)
            {
                if (activity.descriptions is null || activity.descriptions.en is null || activity.descriptions.en.name is null || activity.descriptions.en.description is null || activity.siteUrl is null)
                {
                    continue;
                }
                else
                {
                    try
                    {
                        Console.WriteLine($"{activity.descriptions.en.name}\n{activity.descriptions.en.description}\n{activity.siteUrl}\n-----------------------------------------------------");
                    }
                    catch (NullReferenceException e)
                    {
                        continue;
                    }
                    catch
                    {
                        continue;
                    }

                }
            }
        }
        public static void SearchByMonth(ActivityList activityList)
        {
            Console.WriteLine("    2. Search by opening month");
            Console.WriteLine("    Please enter a month name ");
            string monthName = Console.ReadLine();
            Console.WriteLine("    Do you want to limit the results returned? We usually return 10 results.");
            Console.WriteLine("    Type 1-100 to change the number or any letter to skip this. ");
            // set the limit of displayed results
            int limit = 10;
            // check if user wants to change the limit 
            // and if the limit between 1 and 100
            if (int.TryParse(Console.ReadLine(), out int limitChange))
            {
                if (0 < limitChange && limitChange < 101)
                    limit = limitChange;
            }

            // a new list to save search result
            List<Activity> searchResult = new List<Activity>();
            foreach (Activity activity in activityList.rows)
            {
                if (searchResult.Count < limit)
                {
                    List<string> monthList = activity.availableMonths.ToList();
                    monthList.ForEach(month => month.ToLower());
                    // check city name
                    if (monthList.Contains(monthName.ToLower()))
                    {
                        searchResult.Add(activity);
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    break;
                }
            }
            // display the result
            foreach (Activity activity in searchResult)
            {
                if (activity.descriptions is null || activity.descriptions.en is null || activity.descriptions.en.name is null || activity.descriptions.en.description is null || activity.siteUrl is null || activity.availableMonths is null || activity.address.city is null)
                {
                    continue;
                }
                else
                {
                    try
                    {
                        string months = String.Join(",", activity.availableMonths);
                        Console.WriteLine($"\n\n{activity.descriptions.en.name}\n\n{months}\n\n{activity.address.city}\n\n{activity.descriptions.en.description}\n\n{activity.siteUrl}\n\n-----------------------------------------------------");
                    }
                    catch (NullReferenceException e)
                    {
                        continue;
                    }
                    catch
                    {
                        continue;
                    }

                }
            }
        }
        public static void SearchByCategory(ActivityList activityList)
        {
            // display menu
            Console.WriteLine("    3. Search by category");
            Console.WriteLine("    Please copy-paste a following category name\n");
            Console.WriteLine("    sightseeing_tours\n    LGBTQ\n    day_trip\n    coast_archipelago\n    nature_excursion\n    history\n    guided_service\n    hiking_walking_trekking\n    architecture\n    local_lifestyle\n    cruises_ferries\n    national_park\n    wildlife_bird_watching\n    minigolf\n    historical_sites\n");
            string tagName = Console.ReadLine();
            Console.WriteLine("    Do you want to limit the results returned? We usually return 10 results.");
            Console.WriteLine("    Type 1-100 to change the number or any letter to skip this. ");
            // set the limit of displayed results
            int limit = 10;
            // check if user wants to change the limit 
            // and if the limit between 1 and 100
            if (int.TryParse(Console.ReadLine(), out int limitChange))
            {
                if (0 < limitChange && limitChange < 101)
                    limit = limitChange;
            }
            // a new list to save search result
            List<Activity> searchResult = new List<Activity>();
            foreach (Activity activity in activityList.rows)
            {
                if (searchResult.Count < limit)
                {
                    List<string> tagList = activity.tags.ToList();
                    // check tag name
                    if (tagList.Contains(tagName))
                    {
                        searchResult.Add(activity);
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    break;
                }
            }
            // display the result
            foreach (Activity activity in searchResult)
            {
                if (activity.descriptions is null || activity.descriptions.en is null || activity.descriptions.en.name is null || activity.descriptions.en.description is null || activity.siteUrl is null)
                {
                    continue;
                }
                else
                {
                    try
                    {
                        var tagString = String.Join(",", activity.tags);
                        Console.WriteLine($"\n\n{activity.descriptions.en.name}\n\n{tagString}\n\n{activity.descriptions.en.description}\n\n{activity.siteUrl}\n\n-----------------------------------------------------");
                    }
                    catch (NullReferenceException e)
                    {
                        continue;
                    }
                    catch
                    {
                        continue;
                    }

                }
            }
        }
        public static void AutomaticRecommendation(ActivityList activityList)
        {
            // display menu
            Console.WriteLine("    4. Automatic recommendation");
            Console.WriteLine("    I will generate some popular activities for you");
            Console.WriteLine("    Do you want to limit the results returned? We usually return 10 results.");
            Console.WriteLine("    Type 1-100 to change the number or any letter to skip this. ");
            // set the limit of displayed results
            int limit = 10;
            // check if user wants to change the limit 
            // and if the limit between 1 and 100
            if (int.TryParse(Console.ReadLine(), out int limitChange))
            {
                if (0 < limitChange && limitChange < 101)
                    limit = limitChange;
            }
            // a new list to save search result
            List<Activity> searchResult = new List<Activity>();
            // a list to store the value generated randomly
            // in case of same result
            List<int> randInt = new List<int>();
            while (searchResult.Count < limit)
            {
                var rand = new Random();
                int newInt = rand.Next(150);
                if (randInt.Contains(newInt))
                {
                    continue;
                }
                else
                {
                    randInt.Add(newInt);
                    var activity = activityList.rows[newInt];
                    if (!(activity.descriptions is null || activity.descriptions.en is null || activity.descriptions.en.name is null || activity.descriptions.en.description is null || activity.siteUrl is null))
                    {
                        searchResult.Add(activity);
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            Console.WriteLine(searchResult.Count);
            // display the result
            foreach (Activity activity in searchResult)
            {
                try
                {
                    var tagString = String.Join(",", activity.tags);
                    Console.WriteLine($"\n\n{activity.descriptions.en.name}\n\n{tagString}\n\n{activity.descriptions.en.description}\n\n{activity.siteUrl}\n\n-----------------------------------------------------");
                }
                catch (NullReferenceException e)
                {
                    continue;
                }
                catch
                {
                    continue;
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
                e.event_dates.starting_day >= DateTime.Now.Date
                && e.event_dates.starting_day < DateTime.Now.AddDays(60)).
                OrderBy(e => e.event_dates.starting_day)
                .Take(limit);
            return results;
        }

        public static void looppi()
        {
            Console.WriteLine("Search by event name(1) / search by city(2)");


        }
    }
   
}
