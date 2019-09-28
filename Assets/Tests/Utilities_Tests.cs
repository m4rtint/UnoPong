using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class Utilities_Tests
    {

        [Test]
        public void RandomPlayer_Run_100_Times_With_4_Players_Expected_Min_Max()
		{
			//Arrange
			int times = 100;
            int players = 4;
            int min = int.MaxValue;
            int max = 0;

            MPHT.Player expectedMax = MPHT.Player.PLAYER_FOUR;
            MPHT.Player expectedMin = MPHT.Player.PLAYER_ONE;

            //Act
            for (int i = 0; i < times; i++)
			{
				int player = (int)MPHT.Utilities.RandomPlayer(players);
                min = Mathf.Min(min, player);
                max = Mathf.Max(max, player);
               
			}

            //Assert
            Assert.AreEqual((MPHT.Player)min, expectedMin);
            Assert.AreEqual((MPHT.Player)max, expectedMax);
        }

        [Test]
        public void RandomPlayer_Run_100_Times_With_3_Players_Expected_Min_Max()
        {
            //Arrange
            int times = 100;
            int players = 3;
            int min = int.MaxValue;
            int max = 0;

            MPHT.Player expectedMax = MPHT.Player.PLAYER_THREE;
            MPHT.Player expectedMin = MPHT.Player.PLAYER_ONE;

            //Act
            for (int i = 0; i < times; i++)
            {
                int player = (int)MPHT.Utilities.RandomPlayer(players);
                min = Mathf.Min(min, player);
                max = Mathf.Max(max, player);

            }

            //Assert
            Assert.AreEqual((MPHT.Player)min, expectedMin);
            Assert.AreEqual((MPHT.Player)max, expectedMax);
        }

        [Test]
        public void RandomPlayer_With_10_Players_Throw_Exception()
        {
            //Assert
            Assert.Catch(() => { MPHT.Utilities.RandomPlayer(10); });
        }
    }
}
