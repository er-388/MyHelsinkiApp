
using System;

namespace ActivitiesActivities

{

    public class Activity
    {
        public string id { get; set; }
        public DateTime updated { get; set; }
        public Descriptions descriptions { get; set; }
        public string duration { get; set; }
        public string durationType { get; set; }
        public Open open { get; set; }
        public Medium[] media { get; set; }
        public Address address { get; set; }
        public Company company { get; set; }
        public string[] tags { get; set; }
        public Priceeur priceEUR { get; set; }
        public string[] availableMonths { get; set; }
        public string[] meantFor { get; set; }
        public string siteUrl { get; set; }
        public string storeUrl { get; set; }
    }

    public class Descriptions
    {
        public En en { get; set; }
        public Fi fi { get; set; }
    }

    public class En
    {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Fi
    {
        public string name { get; set; }
        public string description { get; set; }
    }

    public class Open
    {
        public Sunday sunday { get; set; }
        public Tuesday tuesday { get; set; }
        public Wednesday wednesday { get; set; }
        public Monday monday { get; set; }
        public Friday friday { get; set; }
        public Thursday thursday { get; set; }
        public Saturday saturday { get; set; }
    }

    public class Sunday
    {
        public bool open { get; set; }
        public object from { get; set; }
        public object to { get; set; }
    }

    public class Tuesday
    {
        public bool open { get; set; }
        public object from { get; set; }
        public object to { get; set; }
    }

    public class Wednesday
    {
        public bool open { get; set; }
        public object from { get; set; }
        public object to { get; set; }
    }

    public class Monday
    {
        public bool open { get; set; }
        public object from { get; set; }
        public object to { get; set; }
    }

    public class Friday
    {
        public bool open { get; set; }
        public object from { get; set; }
        public object to { get; set; }
    }

    public class Thursday
    {
        public bool open { get; set; }
        public object from { get; set; }
        public object to { get; set; }
    }

    public class Saturday
    {
        public bool open { get; set; }
        public object from { get; set; }
        public object to { get; set; }
    }

    public class Address
    {
        public Location location { get; set; }
        public string postalCode { get; set; }
        public string streetName { get; set; }
        public string city { get; set; }
    }

    public class Location
    {
        public float lat { get; set; }
        public float _long { get; set; }
    }

    public class Company
    {
        public string name { get; set; }
        public string businessId { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }

    public class Priceeur
    {
        public int from { get; set; }
        public object to { get; set; }
        public string pricingType { get; set; }
    }

    public class Medium
    {
        public string id { get; set; }
        public string kind { get; set; }
        public string copyright { get; set; }
        public string name { get; set; }
        public string alt { get; set; }
        public string originalUrl { get; set; }
        public string smallUrl { get; set; }
        public string largeUrl { get; set; }
    }
}