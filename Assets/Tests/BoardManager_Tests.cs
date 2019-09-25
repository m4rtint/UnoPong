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
        public void test_not_matching_amount_of_values_on_board()
        {
            //Arrange
            BoardManagerBehaivours board = new BoardManagerBehaivours();

            //Assert
            Assert.Catch<Exception>(() => { board.CheckTemplate(new bool[2], new GameObject[1]); });
        }

        [Test]
        public void test_Matching_amount_of_boards()
        {
            //Arrange
            BoardManagerBehaivours board = new BoardManagerBehaivours();

            //Assert
            Assert.DoesNotThrow(() => { board.CheckTemplate(new bool[1], new GameObject[1]); });
        }


    }
}
