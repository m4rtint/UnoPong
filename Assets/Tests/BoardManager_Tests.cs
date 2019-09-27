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
        [Test]
        public void CheckTemplate_Not_Same_Size_Boards_Should_Throw_Error()
        {
            //Arrange
            BoardManagerBehaviour board = new BoardManagerBehaviour();

            //Assert
            Assert.Catch<Exception>(() => { board.CheckTemplate(new bool[2], new GameObject[1]); });
        }

        [Test]
        public void CheckTemplate_Same_Size_Boards_Should_Not_Throw_Error()
        {
            //Arrange
            BoardManagerBehaviour board = new BoardManagerBehaviour();

            //Assert
            Assert.DoesNotThrow(() => { board.CheckTemplate(new bool[1], new GameObject[1]); });
        }

        [Test]
        public void BoardOutlineBricks_With_Simple_Template_Of_Square_Equal_Boards()
        {
            //Arrange
            BoardManagerBehaviour behaviour = new BoardManagerBehaviour();
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
            bool[] actualShape = behaviour.BoardOutlinedBricks(originalShape, width);

            //Assert
            Assert.AreEqual(expectedShape, actualShape);
        }

        [Test]
        public void BoardOutlineBricks_With_Simple_Template_Of_Line_Equal_Boards()
        {
            //Arrange
            BoardManagerBehaviour behaviour = new BoardManagerBehaviour();
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
            bool[] actualShape = behaviour.BoardOutlinedBricks(originalShape, width);

            //Assert
            Assert.AreEqual(expectedShape, actualShape);
        }

        [Test]
        public void BoardOutlineBricks_With_Big_Donut_Equal_Boards()
        {
            //Arrange
            BoardManagerBehaviour behaviour = new BoardManagerBehaviour();
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
            bool[] actualShape = behaviour.BoardOutlinedBricks(originalShape, width);

            //Assert
            Assert.AreEqual(expectedShape, actualShape);
        }
    }
}
