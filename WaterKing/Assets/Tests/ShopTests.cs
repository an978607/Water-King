using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ShopTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void Should_Get_Next_Price()
        {
            int[] starting_prices =
            {
                2000,
                7000,
                3000
            };

            int[] next_prices_for_2000 =
            {
                4000,
                8000,
                16000,
                24000
            };

            int[] next_prices_for_7000 =
            {
                14000,
                21000
            };

            int[] next_prices_for_3000 =
            {
                6000,
                12000,
                24000,
                48000,
                96000,
                192000
            };

            for (int i = 2; i <= next_prices_for_2000.Length; i++)
            {
                int value = ShopManager.GetNextPrice(starting_prices[0], i);
                Assert.AreEqual(next_prices_for_2000[i - 2], value);
            }

            for (int i = 2; i <= next_prices_for_7000.Length; i++)
            {
                int value = ShopManager.GetNextPrice(starting_prices[1], i);
                Assert.AreEqual(next_prices_for_7000[i - 2], value);
            }

            for (int i = 2; i <= next_prices_for_3000.Length; i++)
            {
                int value = ShopManager.GetNextPrice(starting_prices[2], i);
                Assert.AreEqual(next_prices_for_3000[i - 2], value);
            }
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator ShopTestsWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
