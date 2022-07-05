using System;

namespace PlacePlace
{ 
public class Place
{
    public string id { get; set; }
    public Name name { get; set; }
    public Source_Type source_type { get; set; }
    public string info_url { get; set; }
    public DateTime modified_at { get; set; }
    public Location location { get; set; }
    public Description description { get; set; }
    public Tag[] tags { get; set; }
    public object[] extra_searchwords { get; set; }
    public string opening_hours_url { get; set; }
}

public class Name
{
    public string fi { get; set; }
    public string en { get; set; }
    public string sv { get; set; }
    public object zh { get; set; }
}

public class Source_Type
{
    public int id { get; set; }
    public string name { get; set; }
}

public class Location
{
    public float lat { get; set; }
    public float lon { get; set; }
    public Address address { get; set; }
}

public class Address
{
    public string street_address { get; set; }
    public string postal_code { get; set; }
    public string locality { get; set; }
    public string neighbourhood { get; set; }
}

public class Description
{
    public string intro { get; set; }
    public string body { get; set; }
    public Image[] images { get; set; }
}

public class Image
{
    public string url { get; set; }
    public string copyright_holder { get; set; }
    public License_Type license_type { get; set; }
    public string media_id { get; set; }
}

public class License_Type
{
    public int id { get; set; }
    public string name { get; set; }
}

public class Tag
{
    public string id { get; set; }
    public string name { get; set; }
}
}
