/////////////////////////////////////
//VARIABLES
/////////////////////////////////////
using UnityEngine;
using System.Collections.Generic;

public partial class GameData
{
    public static Vector2 ScreenResolution;
    public static string MapSize;
    public static GameObject GAME_MAP;
    public static int MaxPlayers;
    public static int MaxCivilians;
    public static int MaxAutos;
    public static int TotalCivilians;
    public static int TotalAutos;
    public static bool NightLights;
    public static float sunLight;
    public static bool NavigationDisplayActive;
    public static bool NavigationSpawnDisplayActive;
    public static bool agentDisplayPath;
    public static bool autoDisplayPath;
    public static bool canContinue;//not used
    public static string gameSpeed;
    public static float minuteToRealTime = 1f;
    public static float timer;
    public static int min;
    public static int hour;
    public static string ampm;
    public static int dayOfWeek;
    public static int numberOfWeeks;
    public static int dayOfMonth;
    public static int monthOfYear;
    public static int year;



    public static string[] MALE_FIRST_NAMES = { "Alex", "Bernard", "Charles", "Donald", "Edgar", "Felix", "Greg", "Hector", "Ivan", "Jovan", "Kevin", "Lucas", "Morty", "Norman", "Oscar", "Patrick", "Quincey", "Roger", "Steven", "Thoedore", "Ulysis", "Victor", "Winston", "Xavier", "Yuri", "Zeke", };
    public static string[] FEMALE_FIRST_NAMES = { "Angie", "Brenda", "Crystal", "Dedra", "Elanore", "Fiona", "Gabriella", "Helen", "Isabelle", "Jackie", "Kristen", "Lori", "Mandy", "Nancy", "Olivia", "Paige", "Quinn", "Rosa", "Stacy", "Tiffany", "Ursa", "Victoria", "Winnie", "Xenia", "Yasmine", "Zoe", };
    public static string[] LAST_NAMES = { "Abney", "Bachman", "Cranfield", "Dearborn", "Etheridge", "Figgins", "Guthman", "Hutchinson", "Iveson", "Jenkins", "Kellogg", "Lazowski", "MacFarlane", "Newbury", "O’Brien", "Peabody", "Quayle", "Ravitz", "Sadler", "Taggart", "Ulbricht", "Varney", "Wagnon", "Xenos", "Yarborough", "Zalewski", };
    public static string[] MALE_NICK_NAMES = { "Banana", "Sausage", "Mandingo", "Twitch", "Butters", "Fingers", "Lucky", "Professor", "Bubbles", "Pistol", "Cheech", "Cadillac", "Money", "Snake", "Ice", "Laser", "Stickman", "Lips", "Widow Maker", "Tiny", "Black Widow", "Baby Face", "Mustach", "Speedy", "Sneaky", "King", "Queen", "Greese", "Slick", "Serge", "Captain", "Green Horn", "Woodchuck", "Tiger", "Cockroach", "Noodles", "Uncle", "Rosco", "Ninja", "Ancient", "Undertaker", "Cabbie", "Dusty", "Ashy", "Twinkles", "Snitch", "Weasel" };
    public static string[] FEMALE_NICK_NAMES = { "Bubbles", "Cheech", "Money", "Ice", "Lips", "Widow Maker", "Tiny", "Black Widow", "Wiskers", "Speedy", "Sneaky", "Queen", "Greese", "Slick", "Captain", "Green Horn", "Woodchuck", "Tiger", "Cabbie", "Stinky", "Twinkles", "Hoover", "Snitch", "Rainbow", "Glitter", "Bombshell", "Jugs", "Chopper", "Bobit", "Jewels", "Diamond", "Pearls", "Ruby" };
    public static string[] BUSINESSES = { "Accountant", "Lawyer", "Counselor", "Doctor", "Actor", "Zoo Keeper", "Investigator", "Broker", "Teacher", "Student", "Pilot", "Barber", "Bartender", "Baker", "Construction", "Chiropractor", "Clergy", "Game Designer", "Dancer", "Driller", "RuffNeck", "Fire Fighter", "Scientist", "Pool Shark", "Athlete", "Farmer", "Janitor", "Jeweler", "Investor", "Clerk", "Taxi Driver", "Seamstriss", "Worker", "Dog Walker", "Mechanic", };
    public static string[] AUTO_MODEL_NAMES = { "Cougar", "Rambler", "Lazer", "Pinto", "Vesica", "Viking" };
    public static string[] DAYS_IN_WEEK = { "Sun", "Mon", "Tue", "Wed", "Thur", "Fri", "Sat" };
    public static string[] MONTHS_IN_YEAR = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
    public static int[] DAYS_IN_MONTH = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    public static string[] NEIGHBORHOOD_FIRST_NAME = { "Langly", "Dragon", "Lilly", "Pelican", "Sparrow", "Eagle", "Strawberry", "Peach", "Citrus", "Candy", "Ether", "Freedom", "Acme", "Corporate", "Government", "Lavendar", "Donkey", "Slummers", "Chaos", "Rose", "Canary", "Inner", "Outter", "Private", "French", };
    public static string[] NEIGHBORHOOD_LAST_NAME = { "Heights", "Bay", "Lakes", "Valley", "Hills", "Flats", "Peaks", "View", "Cove", "Bend", "Gardens", "Shores", "Point", "Square", "Circle", "Harbor", "Docks", "Ridge", "Park", "Groves", "Meadows", "Shire", "Palms" };
}





