using System;
using System.Net;
using System.Net.NetworkInformation;
using UnityEngine;

public static class PutAPIDatabase
{

    // Update Locations info for player
    // It will ask for the fields score, isUnlocked, and locationName. Those fields for that location name will update
    // Endpoint for updating locations: http://waterkinggame.com/LAMPAPI/update_locations.php
    public static void UpdateLocations(string strJsonInput)
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "update_locations");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";

            string strJsonResult = (string)wc.UploadString(strURL, "PUT", strJsonInput);

            // Now do something with the recieved JSON string
            Debug.Log(strJsonResult);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} String failed to upload.", ex);
        }
    }

    // Update Player info
    // Endpoint for updating player info: http://waterkinggame.com/LAMPAPI/update_player.php
    public static void UpdatePlayer(string strJsonInput)
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "update_player");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";

            string strJsonResult = (string)wc.UploadString(strURL, "PUT", strJsonInput);

            Debug.Log(strJsonResult);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} String failed to upload.", ex);
        }
    }

    // Update Player items info: http://waterkinggame.com/LAMPAPI/update_playeritems.php
    // It expects the fields isUnlocked, itemName. The isUnlocked for that item name will update
    // need to change the item values but use the ones currently in the database for now, like "test1","test2",etc
    public static void UpdatePlayerItems(string strJsonInput)
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "update_playeritems");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";

            string strJsonResult = (string)wc.UploadString(strURL, "PUT", strJsonInput);

            Debug.Log(strJsonResult);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} String failed to upload.", ex);
        }
    }

    // Update Player vehicles info: http://waterkinggame.com/LAMPAPI/update_playervehicles.php
    // It expects the fields isUnlocked, vehicleName. The isUnlocked for that vehicle name will update
    public static void UpdatePlayerVehicles(string strJsonInput)
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "update_playervehicles");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";

            string strJsonResult = (string)wc.UploadString(strURL, "PUT", strJsonInput);

            Debug.Log(strJsonResult);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} String failed to upload.", ex);
        }
    }

    // Update Player events info: http://waterkinggame.com/LAMPAPI/update_playerevents.php
    // It expects the fields isUnlocked, eventName. The isUnlocked for that event name will update
    // need to change the item values but use the ones currently in the database for now, like "event1","event2",etc
    public static void UpdatePlayerEvents(string strJsonInput)
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "update_playerevents");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";

            string strJsonResult = (string)wc.UploadString(strURL, "PUT", strJsonInput);

            Debug.Log(strJsonResult);
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} String failed to upload.", ex);
        }
    }

}