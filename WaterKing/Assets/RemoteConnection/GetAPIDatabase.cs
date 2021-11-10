using System;
using System.Net;
using System.Collections;
using SimpleJSON;
using System.Net.NetworkInformation;
using UnityEngine.Networking;
using UnityEngine;

public static class GetAPIDatabase
{
    // Retreive an item from the database
    // Endpoint: http://waterkinggame.com/LAMPAPI/get_item.php
    public static string GetItem(string strJsonInput)
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "get_item");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";

            string strJsonResult = (string)wc.UploadString(strURL, "POST", strJsonInput);
            return strJsonResult;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} No data found.", ex);
            return null;
        }
    }

    // Retreive all items from the database
    // Endpoint: http://waterkinggame.com/LAMPAPI/get_items.php
    public static string GetItems()
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "get_items");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
                                  "Windows NT 5.2; .NET CLR 1.0.3705;)");
            string strJsonResult = (string)wc.DownloadString("http://waterkinggame.com/LAMPAPI/get_items.php");
            return strJsonResult;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} . error occured", ex);
            return null;
        }
    }

    // Retreive an event from the database
    // Endpoint: http://waterkinggame.com/LAMPAPI/get_event.php
    public static string GetEvent(string strJsonInput)
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "get_event");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";
        
            string strJsonResult = (string)wc.UploadString(strURL, "POST", strJsonInput);
            return strJsonResult;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} No data found.", ex);
            return null;
        }
    }

    // Retreive all events from the database
    // Endpoint: http://waterkinggame.com/LAMPAPI/get_events.php
    public static string GetEvents()
    {
        // string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "get_events");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
                                  "Windows NT 5.2; .NET CLR 1.0.3705;)");
            string strJsonResult = (string)wc.DownloadString("http://waterkinggame.com/LAMPAPI/get_events.php");
            return strJsonResult;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} . error occured", ex);
            return null;
        }
    }

    // Retreive a vehicle from the database
    // Endpoint: http://waterkinggame.com/LAMPAPI/get_vehicle.php
    public static string GetVehicle(string strJsonInput)
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "get_vehicle");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";

            string strJsonResult = (string)wc.UploadString(strURL, "POST", strJsonInput);
            return strJsonResult;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} No data found.", ex);
            return null;
        }
    }

    // Retreive all vehicles from the database
    // Endpoint: http://waterkinggame.com/LAMPAPI/get_vehicles.php
    public static string GetVehicles()
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "get_vehicles");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
                                  "Windows NT 5.2; .NET CLR 1.0.3705;)");
            string strJsonResult = (string)wc.DownloadString("http://waterkinggame.com/LAMPAPI/get_vehicles.php");
            return strJsonResult;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} . error occured", ex);
            return null;
        }
        // gets json info at the url
        /* UnityWebRequest vehicleInfo = UnityWebRequest.Get(strURL);

         yield return vehicleInfo.SendWebRequest();

         if (vehicleInfo.isNetworkError || vehicleInfo.isHttpError)
         {
             Debug.LogError(vehicleInfo.error);
             yield break;
         }

         string json = JSON.Parse(vehicleInfo.downloadHandler.text);
         */
    }

    // Retreive a trivia from the database
    // Endpoint: http://waterkinggame.com/LAMPAPI/get_trivia.php
    public static string GetTrivia(string strJsonInput)
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "get_trivia");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";

            string strJsonResult = (string)wc.UploadString(strURL, "POST", strJsonInput);
            return strJsonResult;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} No data found.", ex);
            return null;
        }
    }

    // Retreive all trivia from the database
    // Endpoint: http://waterkinggame.com/LAMPAPI/get_trivias.php
    public static string GetTrivias()
    {
        // string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "get_trivias");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
                                  "Windows NT 5.2; .NET CLR 1.0.3705;)");
            string strJsonResult = (string)wc.DownloadString("http://waterkinggame.com/LAMPAPI/get_trivias.php");
            return strJsonResult;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} . error occured", ex);
            return null;
        }

    }

    // Retreive an obstacle from the database
    // Endpoint: http://waterkinggame.com/LAMPAPI/get_obstacle.php
    public static string GetObstacle(string strJsonInput)
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "get_obstacle");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers[HttpRequestHeader.ContentType] = "application/json";

            string strJsonResult = (string)wc.UploadString(strURL, "POST", strJsonInput);
            return strJsonResult;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} No data found.", ex);
            return null;
        }
    }

    // Retreive all obstacles from the database
    // Endpoint: http://waterkinggame.com/LAMPAPI/get_obstacles.php
    public static string GetObstacles()
    {
        // string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "get_obstacles");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
                                  "Windows NT 5.2; .NET CLR 1.0.3705;)");
            string strJsonResult = (string)wc.DownloadString("http://waterkinggame.com/LAMPAPI/get_obstacles.php");
            return strJsonResult;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} . error occured", ex);
            return null;
        }
    }

    // NOTE: This retreives one player from the database, not multiple
    // Endpoint: http://waterkinggame.com/LAMPAPI/get_players.php
    public static string GetPlayers()
    {
         string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "get_players");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
                                  "Windows NT 5.2; .NET CLR 1.0.3705;)");
            string strJsonResult = (string)wc.DownloadString("http://waterkinggame.com/LAMPAPI/get_players.php");
            return strJsonResult;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} . error occured", ex);
            return null;
        }
    }

    // Retreive items for one player from the database
    // Endpoint: http://waterkinggame.com/LAMPAPI/get_playeritems.php
    public static string GetPlayerItems()
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "get_playeritems");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
                                  "Windows NT 5.2; .NET CLR 1.0.3705;)");
            string strJsonResult = (string)wc.DownloadString(strURL);
            return strJsonResult;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} . error occured", ex);
            return null;
        }
    }

    // Retreive events for one player from the database
    // Endpoint: http://waterkinggame.com/LAMPAPI/get_playerevents.php
    public static string GetPlayerEvents()
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "get_playerevents.php");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
                                  "Windows NT 5.2; .NET CLR 1.0.3705;)");
            string strJsonResult = (string)wc.DownloadString(strURL);
            return strJsonResult;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} . error occured", ex);
            return null;
        }
    }

    // Retreive vehicles for one player from the database
    // Endpoint: http://waterkinggame.com/LAMPAPI/get_playervehicles.php
    public static string GetPlayerVehicles()
    {
        string strURL = String.Format("http://{0}/LAMPAPI/{1}.php", "waterkinggame.com", "get_playervehicles.php");
        try
        {
            WebClient wc = new WebClient();
            wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
                                  "Windows NT 5.2; .NET CLR 1.0.3705;)");
            string strJsonResult = (string)wc.DownloadString(strURL);
            return strJsonResult;
        }
        catch (System.Exception ex)
        {
            Console.WriteLine("{0} . error occured", ex);
            return null;
        }
    }

}
