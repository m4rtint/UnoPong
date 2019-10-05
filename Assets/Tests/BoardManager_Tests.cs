using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using MPHT;

namespace Tests
{
    public class BoardManager_Tests
    {
        BoardManagerBehaviour behaviour;
        [SetUp]
        public void SetUp()
        {
            behaviour = new BoardManagerBehaviour();
        }

        [TearDown]
        public void TearDown()
        {
            behaviour = null;
        }

        [Test]
        public void CheckTemplate_Not_Same_Size_Boards_Should_Throw_Error()
        {
            //Assert
            Assert.Catch<Exception>(() => { behaviour.CheckTemplate(new bool[2], new GameObject[1]); });
        }

        [Test]
        public void CheckTemplate_Same_Size_Boards_Should_Not_Throw_Error()
        {
            //Arrange
            bool[] expectedBoard = CreateBoardWith(13);

            //Assert
            Assert.DoesNotThrow(() => { behaviour.CheckTemplate(expectedBoard, new GameObject[13]); });
        }

        [Test]
        public void CheckTemplate_Same_Size_Boards_And_Divisible_By_13_Should_Not_Throw_Error()
        {
            //Arrange
            bool[] expectedBoard = CreateBoardWith(169);

            //Assert
            Assert.DoesNotThrow(() => { behaviour.CheckTemplate(expectedBoard, new GameObject[169]); });
        }

        [Test]
        public void CheckTemplate_Same_Size_Boards_But_Not_Divisible_By_13_Throw_error()
        {
            //Arrange
            bool[] expectedBoard = CreateBoardWith(15);

            //Assert
            Assert.Catch<Exception>(() => { behaviour.CheckTemplate(expectedBoard, new GameObject[15]); });
        }

        private bool[] CreateBoardWith(int activated)
        {
            bool[] tempBoard = new bool[activated];
            for (int i = 0; i < activated; i++)
            {
                tempBoard[i] = true;
            }

            return tempBoard;
        }

        [Test]
        public void BoardOutlineBricks_With_Simple_Template_Of_Square_Equal_Boards()
        {
            //Arrange
            int width = 5;
            bool[] originalShape = {
                false, false, false, false, false,
                false, true, true, true, false,
                false, true, true, true, false,
                false, true, true, true, false,
                false, false, false, false, false,
            };

            bool[] expectedShape =
            {
                false, false, false, false, false,
                false, true, true, true, false,
                false, true, false, true, false,
                false, true, true, true, false,
                false, false, false, false, false,
            };

            //Act
            bool[] actualShape = behaviour.OutlinedBricks(originalShape, width);

            //Assert
            Assert.AreEqual(expectedShape, actualShape);
        }

        [Test]
        public void BoardOutlineBricks_With_Simple_Template_Of_Line_Equal_Boards()
        {
            //Arrange
            int width = 5;
            bool[] originalShape = {
                true, false, false, false, false,
                false, true, false, false, false,
                false, false, true, false, false,
                false, false, false, true, false,
                false, false, false, false, true,
            };

            bool[] expectedShape =
            {
                true, false, false, false, false,
                false, true, false, false, false,
                false, false, true, false, false,
                false, false, false, true, false,
                false, false, false, false, true,
            };

            //Act
            bool[] actualShape = behaviour.OutlinedBricks(originalShape, width);

            //Assert
            Assert.AreEqual(expectedShape, actualShape);
        }

        [Test]
        public void BoardOutlineBricks_With_Big_Donut_Equal_Boards()
        {
            //Arrange
            int width = 6;
            bool[] originalShape = {
                true, true, true, true, true, true,
                true, true, true, true, true, true,
                true, true, true, true, true, true,
                true, true, true, true, true, true,
                true, true, true, true, true, true,
                true, true, true, true, true, true,
            };

            bool[] expectedShape =
            {
                true, true, true, true, true, true,
                true, false, false, false, false, true,
                true, false, false, false, false, true,
                true, false, false, false, false, true,
                true, false, false, false, false, true,
                true, true, true, true, true, true,
            };

            //Act
            bool[] actualShape = behaviour.OutlinedBricks(originalShape, width);

            //Assert
            Assert.AreEqual(expectedShape, actualShape);
        }

        [Test]
        public void IndexToVector2_Index_At_0_Equal_Vector()
        {
            //Arrange
            int index = 0;
            int widthHeight = 13;
            Vector2 expectedVector2 = new Vector2(-3f, 3f);

            //Act
            Vector2 actualVector2 = behaviour.IndexToVector(index, widthHeight);

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
            Vector2 actualVector2 = behaviour.IndexToVector(index, widthHeight);

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
            Vector2 actualVector2 = behaviour.IndexToVector(index, widthHeight);

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
            Vector2 actualVector2 = behaviour.IndexToVector(index, widthHeight);

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
            Vector2 actualVector2 = behaviour.IndexToVector(index, widthHeight);

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
            Vector2 actualVector2 = behaviour.IndexToVector(index, widthHeight);

            //Assert
            Assert.AreEqual(expectedVector2, actualVector2);
        }
    }
}
