using System;
using System.Net;
using System.Net.NetworkInformation;
using UnityEngine;

public static class PostAPIDatabase
{

    // Posts JSON string input of Item to the database
    // Endpoint for Items: http://waterkinggame.com/LAMPAPI/Items.php
    public static void PostItem(string strJsonInput)
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "Items");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";

            string strJsonResult = (string)wc.UploadString(strURL, "POST", strJsonInput);

            // Now do something with the recieved JSON string
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} String failed to upload.", ex);
        }
    }

    // Posts JSON string input of Event to the database
    // Endpoint for Events: http://waterkinggame.com/LAMPAPI/Events.php
    public static void PostEvent(string strJsonInput)
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "Events");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";

            string strJsonResult = (string)wc.UploadString(strURL, "POST", strJsonInput);

            // Now do something with the recieved JSON string
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} String failed to upload.", ex);
        }
    }

    // Posts JSON string input of Vehicle to the database
    // Endpoint for Vehicles: http://waterkinggame.com/LAMPAPI/Vehicles.php
    public static void PostVehicle(string strJsonInput)
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "Vehicles");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";

            string strJsonResult = (string)wc.UploadString(strURL, "POST", strJsonInput);

            // Now do something with the recieved JSON string
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} String failed to upload.", ex);
        }

    }

    // Posts JSON string input of Trivia to the database
    // Endpoint for Trivia: http://waterkinggame.com/LAMPAPI/Trivia.php
    public static void PostTrivia(string strJsonInput)
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "Trivia");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";

            string strJsonResult = (string)wc.UploadString(strURL, "POST", strJsonInput);

            // Now do something with the recieved JSON string
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} String failed to upload.", ex);
        }
    }

    // Posts JSON string input of Obstacle to the database
    // Endpoint for Obstacles: http://waterkinggame.com/LAMPAPI/Obstacles.php
    public static void PostObstacle(string strJsonInput)
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "Obstacles");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";

            string strJsonResult = (string)wc.UploadString(strURL, "POST", strJsonInput);

            // Now do something with the recieved JSON string
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} String failed to upload.", ex);
        }
    }

    public static void PostPlayer(string strJsonInput)
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "Players");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";

            string strJsonResult = (string)wc.UploadString(strURL, "POST", strJsonInput);

            // Now do something with the recieved JSON string
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} String failed to upload.", ex);
        }
    }

    // initializes player items. 
    // use an empty json string like {}
    public static void PostPlayerItems(string strJsonInput)
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "PlayerItems");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";

            string strJsonResult = (string)wc.UploadString(strURL, "POST", strJsonInput);

            // Now do something with the recieved JSON string
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} String failed to upload.", ex);
        }
    }

    // initializes player events. 
    // use an empty json string like {}
    public static void PostEvents(string strJsonInput)
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "PlayerEvents");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";

            string strJsonResult = (string)wc.UploadString(strURL, "POST", strJsonInput);

            // Now do something with the recieved JSON string
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} String failed to upload.", ex);
        }
    }


    // initializes player vehicles. 
    // use an empty json string like {}
    public static void PostVehicles(string strJsonInput)
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "PlayerVehicles");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";

            string strJsonResult = (string)wc.UploadString(strURL, "POST", strJsonInput);

            // Now do something with the recieved JSON string
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} String failed to upload.", ex);
        }
    }
}