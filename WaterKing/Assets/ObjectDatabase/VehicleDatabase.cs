using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class VehicleDatabase : MonoBehaviour
{
    private static GameObject vehicleDatabaseObject;
    public static  Dictionary<string, Vehicle> vehicles;

    private void Awake()
    {
        vehicleDatabaseObject = GameObject.FindGameObjectWithTag("VehicleDatabase");
        if (vehicles == null)
        {
            BuildDatabase();
        }
    }

    public static GameObject GetVehicleDatabaseObject() => vehicleDatabaseObject;

    private void BuildDatabase()
    {

        // Call Remote Connection endpoint
        string json = "{\"list\":" + GetAPIDatabase.GetVehicles() + "}";
        // Convert json to list
        List<Vehicle> vehicleList = Deserialization.DeserializeVehicles(json);
        vehicles = new Dictionary<string, Vehicle>();

        foreach (Vehicle v in vehicleList)
        {
            if (vehicles.ContainsKey(v.name))
            {
                Debug.LogError("VehicleDatabase: Unable to add duplicate vehicle, check remote database");
                continue;
            }

            vehicles.Add(v.name, v);
        }
    }

    [System.Serializable]
    public class Vehicles
    {
        private static Vehicles vehiclesInstance = null;
        public List<Vehicle> list;
        public static Vehicles GetInstance() => vehiclesInstance = (vehiclesInstance != null) ? vehiclesInstance : new Vehicles();

        private Vehicles ()
        {
            list = new List<Vehicle>();
        }
    }
}
