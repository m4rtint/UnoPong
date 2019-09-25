using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class Utilities_Tests
    {
        [Test]
        public void IndexToVector2_index_at_0()
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
		public void IndexToVector2_index_at_1()
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
		public void IndexToVector2_index_at_30()
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
		public void IndexToVector2_index_at_negative_one()
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
		public void IndexToVector2_index_at_negative_onethousand()
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
	    public void IndexToVector2_index_at_over_amount()
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


	}
}
