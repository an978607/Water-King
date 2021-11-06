using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class VehicleDatabase : MonoBehaviour
{
    private static GameObject vehicleDatabaseObject;
    public Vehicles vehicles;

    private void Awake()
    {
        vehicleDatabaseObject = GameObject.FindGameObjectWithTag("VehicleDatabase");
        BuildDatabase();
    }

    public static GameObject GetVehicleDatabaseObject() => vehicleDatabaseObject;

    private void BuildDatabase()
    {
        // Call Remote Connection endpoint
        string json = "{\"list\":" + GetAPIDatabase.GetVehicles() + "}";
        // Convert json to list
        vehicles.list = Deserialization.DeserializeVehicles(json); 
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
