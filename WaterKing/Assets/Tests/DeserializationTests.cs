using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class DeserializationTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void JSON_String_Should_Create_List_Of_Vehicles()
        {
            string json = "{ \"list\":[" +
                "{ \"id\":0,\"name\":\"TestVehicle1\",\"description\":\"\",\"price\":12,\"isUnlocked\":true,\"speed\":59.0}," +
                "{ \"id\":1,\"name\":\"TestVehicle1\",\"description\":\"\",\"price\":12,\"isUnlocked\":true,\"speed\":59.0}," +
                "{ \"id\":2,\"name\":\"Vehicle 2 Test\",\"description\":\"\",\"price\":13,\"isUnlocked\":false,\"speed\":76.0}," +
                "{ \"id\":3,\"name\":\"Vehicle 3 Test\",\"description\":\"\",\"price\":99,\"isUnlocked\":true,\"speed\":100.0}]}";

            string[] descriptions =
            {
                    "",
                    "",
                    "",
                    "",
                };

            string[] name =
            {
                    "TestVehicle1",
                    "TestVehicle1",
                    "Vehicle 2 Test",
                    "Vehicle 3 Test",
                };

            bool[] isUnlocked =
            {
                    true,
                    true,
                    false,
                    true
                };

            int[] price =
            {
                    12,
                    12,
                    13,
                    99
                };

            double[] speed =
            {
                    59.0,
                    59.0,
                    76.0,
                    100.0
                };

            var vehicles = Deserialization.DeserializeVehicles(json);
            for (int i = 0; i < vehicles.Count; i++)
            {
                Assert.AreEqual(i, vehicles[i].GetVehicleID());
                Assert.AreEqual(name[i], vehicles[i].name);
                Assert.AreEqual(descriptions[i], vehicles[i].description);
                Assert.AreEqual(price[i], vehicles[i].price);
                Assert.AreEqual(isUnlocked[i], vehicles[i].GetUnlockedStatus());
                Assert.AreEqual(speed[i], vehicles[i].GetSpeed());
            }

            // Use the Assert class to test conditions
        }

        public void JSON_String_Should_Create_List_Of_Trivia()
        {
            //string json = "{ \"list\":[" +
            //   "{ \"id\":0,\"question\":\"TestVehicle1\",\"AnswerList\":\"[one, two]\",\"correctAnswer\":1,\"reward\"}," +
            //   "{ \"id\":1,\"question\":\"TestVehicle1\",\"description\":\"\",\"price\":12,\"isUnlocked\":true,\"speed\":59.0}," +
            //   "{ \"id\":2,\"question\":\"Vehicle 2 Test\",\"description\":\"\",\"price\":13,\"isUnlocked\":false,\"speed\":76.0}," +
            //   "{ \"id\":3,\"question\":\"Vehicle 3 Test\",\"description\":\"\",\"price\":99,\"isUnlocked\":true,\"speed\":100.0}]}";

            //string[] descriptions =
            //{
            //        "",
            //        "",
            //        "",
            //        "",
            //    };

            //string[] name =
            //{
            //        "TestVehicle1",
            //        "TestVehicle1",
            //        "Vehicle 2 Test",
            //        "Vehicle 3 Test",
            //    };

            //bool[] isUnlocked =
            //{
            //        true,
            //        true,
            //        false,
            //        true
            //    };

            //int[] price =
            //{
            //        12,
            //        12,
            //        13,
            //        99
            //    };

            //double[] speed =
            //{
            //        59.0,
            //        59.0,
            //        76.0,
            //        100.0
            //    };

            //var vehicles = Deserialization.DeserializeVehicles(json);
            //for (int i = 0; i < vehicles.Count; i++)
            //{
            //    Assert.AreEqual(i, vehicles[i].GetVehicleID());
            //    Assert.AreEqual(name[i], vehicles[i].name);
            //    Assert.AreEqual(descriptions[i], vehicles[i].description);
            //    Assert.AreEqual(price[i], vehicles[i].price);
            //    Assert.AreEqual(isUnlocked[i], vehicles[i].GetUnlockedStatus());
            //    Assert.AreEqual(speed[i], vehicles[i].GetSpeed());
            //}
        }

        public void JSON_String_Should_Create_List_Of_Obstacles()
        {

        }

        [Test]
        public void JSON_String_Should_Create_List_Of_Items()
        {
            string json = "{ \"list\":[" +
                "{ \"id\":0,\"name\":\"TestItem1\",\"description\":\"description1\",\"price\":12,\"isUnlocked\":true}," +
                "{ \"id\":1,\"name\":\"TestItem2\",\"description\":\"description2\",\"price\":11,\"isUnlocked\":true}," +
                "{ \"id\":2,\"name\":\"TestItem3\",\"description\":\"description3\",\"price\":13,\"isUnlocked\":false}," +
                "{ \"id\":3,\"name\":\"TestItem4\",\"description\":\"description4\",\"price\":99,\"isUnlocked\":true}]}";

            string[] descriptions =
            {
                    "description1",
                    "description2",
                    "description3",
                    "description4",
                };

            string[] name =
            {
                    "TestItem1",
                    "TestItem2",
                    "TestItem3",
                    "TestItem4",
                };

            bool[] isUnlocked =
            {
                    true,
                    true,
                    false,
                    true
                };

            int[] price =
            {
                    12,
                    11,
                    13,
                    99
                };

            var items = Deserialization.DeserializeItems(json);
            for (int i = 0; i < items.Count; i++)
            {
                Assert.AreEqual(i, items[i].GetItemID()); // Fix
                Assert.AreEqual(name[i], items[i].name);
                Assert.AreEqual(descriptions[i], items[i].description);
                Assert.AreEqual(price[i], items[i].price);
                Assert.AreEqual(isUnlocked[i], items[i].GetUnlockedStatus());
            }
        }

        [Test]
        public void JSON_String_Should_Create_List_Of_Events()
        {
            string json = "{ \"list\":[" +
                "{ \"id\":0,\"Name\":\"EventItem1\",\"description\":\"description1\",\"price\":12,\"isUnlocked\":true}," +
                "{ \"id\":1,\"Name\":\"EventItem2\",\"description\":\"description2\",\"price\":11,\"isUnlocked\":true}," +
                "{ \"id\":2,\"Name\":\"EventItem3\",\"description\":\"description3\",\"price\":13,\"isUnlocked\":false}," +
                "{ \"id\":3,\"Name\":\"EventItem4\",\"description\":\"description4\",\"price\":99,\"isUnlocked\":true}]}";

            string[] descriptions =
            {
                    "description1",
                    "description2",
                    "description3",
                    "description4",
                };

            string[] name =
            {
                    "EventItem1",
                    "EventItem2",
                    "EventItem3",
                    "EventItem4",
                };

            bool[] isUnlocked =
            {
                    true,
                    true,
                    false,
                    true
                };

            int[] price =
            {
                    12,
                    11,
                    13,
                    99
                };

            var events = Deserialization.DeserializeEvents(json);
            for (int i = 0; i < events.Count; i++)
            {
                Assert.AreEqual(i, events[i].GetEventID()); // Fix
                Assert.AreEqual(name[i], events[i].Name);
                Assert.AreEqual(descriptions[i], events[i].description);
                Assert.AreEqual(price[i], events[i].price);
                Assert.AreEqual(isUnlocked[i], events[i].GetUnlockedStatus());
            }
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator DeserializationTestsWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
