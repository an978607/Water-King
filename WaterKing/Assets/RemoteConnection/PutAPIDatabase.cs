using System;
using System.Net;
using System.Net.NetworkInformation;
using UnityEngine;

public class PutAPIDatabase : MonoBehaviour
{

    // Update Locations info for player
    // Endpoint for updating locations: http://waterkinggame.com/LAMPAPI/update_locations.php
    public void UpdateLocations(string strJsonInput)
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
    public void UpdatePlayer(string strJsonInput)
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


}