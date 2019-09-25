using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class Utilities_Tests
    {
        [Test]
        public void IndexToVector2_Index_At_0_Equal_Vector()
        {
            //Arrange
            int index = 0;
			int widthHeight = 13;
			Vector2 expectedVector2 = new Vector2(-3f, 3f);

			//Act
			Vector2 actualVector2 = MPHT.Utilities.IndexToVector(index, widthHeight);

            //Assert
            Assert.AreEqual(expectedVector2, actualVector2);
        }

		[Test]
		public void IndexToVector2_Index_At_1_Equal_Vector()
		{
			//Arrange
			int index = 1;
			int widthHeight = 13;
			Vector2 expectedVector2 = new Vector2(-2.5f, 3f);

			//Act
			Vector2 actualVector2 = MPHT.Utilities.IndexToVector(index, widthHeight);

			//Assert
			Assert.AreEqual(expectedVector2, actualVector2);
		}

		[Test]
		public void IndexToVector2_Index_At_30_Equal_Vector()
		{
			//Arrange
			int index = 30;
			int widthHeight = 13;
			Vector2 expectedVector2 = new Vector2(-1, 2);

			//Act
			Vector2 actualVector2 = MPHT.Utilities.IndexToVector(index, widthHeight);

			//Assert
			Assert.AreEqual(expectedVector2, actualVector2);
		}

		[Test]
		public void IndexToVector2_Index_At_Negative_One_Equal_Vector()
		{
			//Arrange
			int index = 30;
			int widthHeight = 13;
			Vector2 expectedVector2 = new Vector2(-1, 2);

			//Act
			Vector2 actualVector2 = MPHT.Utilities.IndexToVector(index, widthHeight);

			//Assert
			Assert.AreEqual(expectedVector2, actualVector2);
		}

		[Test]
		public void IndexToVector2_Index_At_Negative_Onethousand_Equal_Vector()
		{
			//Arrange
			int index = -1000;
			int widthHeight = 13;
			Vector2 expectedVector2 = Vector2.zero;

			//Act
			Vector2 actualVector2 = MPHT.Utilities.IndexToVector(index, widthHeight);

			//Assert
			Assert.AreEqual(expectedVector2, actualVector2);
		}

		[Test]
	    public void IndexToVector2_Index_At_Over_Amount_Equal_Vector()
		{
			//Arrange
			int index = 1000;
	        int widthHeight = 13;
	        Vector2 expectedVector2 = Vector2.zero;

	        //Act
	        Vector2 actualVector2 = MPHT.Utilities.IndexToVector(index, widthHeight);

	        //Assert
	        Assert.AreEqual(expectedVector2, actualVector2);
		}

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
