using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using MPHT;
using NSubstitute;

namespace Tests
{
	public class MainMenuManagerBehaviour_Tests
	{
        MainMenuManagerBehaviour _behaviour;
        [SetUp]
        public void Setup()
        {
            _behaviour = new MainMenuManagerBehaviour(InputManager.Instance);
        }

        [TearDown]
        public void Teardown()
        {
            _behaviour = null;
        }

        [Test]
        public void OppositeDirection_With_Direction_Up_Equal_Direction_Down()
		{
            //Arrange
            Direction dir = Direction.UP;
            Direction expectedDir = Direction.DOWN;

            //Act
            Direction actualDir = _behaviour.OppositeDirection(dir);

            //Assert
            Assert.AreEqual(expectedDir, actualDir);
		}

		[Test]
		public void OppositeDirection_With_Direction_Down_Equal_Direction_Up()
		{
            //Arrange
            Direction dir = Direction.DOWN;
            Direction expectedDir = Direction.UP;

            //Act
            Direction actualDir = _behaviour.OppositeDirection(dir);

            //Assert
            Assert.AreEqual(expectedDir, actualDir);
        }

		[Test]
		public void OppositeDirection_With_Direction_Left_Equal_Direction_Right()
		{
            //Arrange
            Direction dir = Direction.LEFT;
            Direction expectedDir = Direction.RIGHT;

            //Act
            Direction actualDir = _behaviour.OppositeDirection(dir);

            //Assert
            Assert.AreEqual(expectedDir, actualDir);
        }

		[Test]
		public void OppositeDirection_With_Direction_Right_Equal_Direction_Left()
		{
            //Arrange
            Direction dir = Direction.RIGHT;
            Direction expectedDir = Direction.LEFT;

            //Act
            Direction actualDir = _behaviour.OppositeDirection(dir);

            //Assert
            Assert.AreEqual(expectedDir, actualDir);
        }

        [Test]
        public void DirectionToDeactivate_With_First_Choice_Up_With_Equal_Set()
		{
            //Arrange
            Direction firstDirection = Direction.UP;
            HashSet<Direction> expectedSet = new HashSet<Direction>() { Direction.UP, Direction.LEFT, Direction.RIGHT};

            //Act
            HashSet<Direction> actualSet = _behaviour.DirectionToDeactivate(firstDirection, ControlScheme.KEYS);

            //Assert
            Assert.AreEqual(expectedSet, actualSet);
        }

		[Test]
		public void DirectionToDeactivate_With_First_Choice_Left_With_Equal_Set()
		{
            //Arrange
            Direction firstDirection = Direction.LEFT;
            HashSet<Direction> expectedSet = new HashSet<Direction>() { Direction.UP, Direction.DOWN, Direction.LEFT };

            //Act
            HashSet<Direction> actualSet = _behaviour.DirectionToDeactivate(firstDirection, ControlScheme.KEYS);

            //Assert
            Assert.AreEqual(expectedSet, actualSet);
        }


		[Test]
		public void DirectionToDeactivate_With_First_Choice_Up_Second_Choice_Down_With_Equal_Set()
		{
            //Arrange
            Direction firstDirection = Direction.UP;
            Direction secondDirection = Direction.DOWN;
            HashSet<Direction> expectedSet = new HashSet<Direction>() { Direction.UP, Direction.DOWN};

            //Act
            _behaviour.DirectionToDeactivate(firstDirection, ControlScheme.KEYS);
            HashSet<Direction> actualSet = _behaviour.DirectionToDeactivate(secondDirection, ControlScheme.PL);

            //Assert
            Assert.AreEqual(expectedSet, actualSet);
        }

		[Test]
		public void DirectionToDeactivate_With_First_Choice_Left_Second_Choice_Right_With_Equal_Set()
		{
            //Arrange
            Direction firstDirection = Direction.LEFT;
            Direction secondDirection = Direction.RIGHT;
            HashSet<Direction> expectedSet = new HashSet<Direction>() { Direction.LEFT, Direction.RIGHT };

            //Act
            _behaviour.DirectionToDeactivate(firstDirection, ControlScheme.KEYS);
            HashSet<Direction> actualSet = _behaviour.DirectionToDeactivate(secondDirection, ControlScheme.PL);

            //Assert
            Assert.AreEqual(expectedSet, actualSet);
        }

        [Test]
        public void PlayerOneSelection_With_W_Pressed_Delegate_Called_With_Correct_Arguments()
        {
            //Arrange
            //InputManager.Instance.IsAnyKeyBeingPressed().Returns(KeyCode.A);
            IInputManager manager = Substitute.For<IInputManager>();
            manager.IsAnyKeyBeingPressed().Returns(KeyCode.W);
            _behaviour = new MainMenuManagerBehaviour(manager);

            KeyCode w = KeyCode.W;
            Player expectedPlayer = Player.PLAYER_TWO;

            //Act
            _behaviour.PlayerOneSelection();

            //Assert
            manager.Received().GetDirectionFromKeyCode(w);
            manager.Received().GetSchemeFromKeyCode(w);
            Assert.AreEqual(expectedPlayer, _behaviour.CurrentPlayer);
        }

        [Test]
        public void PlayerOneSelection_With_Wrong_Key_Pressed_Delegate_Not_Called_Player_Not_Incremented()
        {
            Assert.True(false);
        }
    }
}
