using System;
using System.Net;
using System.Net.NetworkInformation;
using UnityEngine;

public class PostAPIDatabase : MonoBehaviour
{

    // Posts JSON string input of Item to the database
    // Endpoint for Items: http://waterkinggame.com/LAMPAPI/Items.php
    public void PostItem(string strJsonInput)
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
    public void PostEvent(string strJsonInput)
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
    public void PostVehicle(string strJsonInput)
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
    public void PostTrivia(string strJsonInput)
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
    public void PostObstacle(string strJsonInput)
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

    public void PostPlayer(string strJsonInput)
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
}