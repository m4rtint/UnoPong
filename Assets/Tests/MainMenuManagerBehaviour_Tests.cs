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
            IInputManager manager = Substitute.For<IInputManager>();
            manager.IsAnyKeyBeingPressed().Returns(KeyCode.W);
            _behaviour = new MainMenuManagerBehaviour(manager);

            KeyCode w = KeyCode.W;
            Player expectedPlayer = Player.PLAYER_ONE;

            //Act
            _behaviour.PlayerOneSelection();

            //Assert
            manager.Received().GetDirectionFromKeyCode(w);
            manager.Received().GetSchemeFromKeyCode(w);
            Assert.AreEqual(expectedPlayer, _behaviour.CurrentAmountOfPlayersJoin);
        }

        [Test]
        public void PlayerOneSelection_With_Wrong_Key_Pressed_Delegate_Not_Called_Player_Not_Incremented()
        {
            //Arrange
            IInputManager manager = Substitute.For<IInputManager>();
            KeyCode f = KeyCode.None;
            manager.IsAnyKeyBeingPressed().Returns(f);
            _behaviour = new MainMenuManagerBehaviour(manager);

            
            Player expectedPlayer = Player.PLAYER_ONE;

            //Act
            _behaviour.PlayerOneSelection();

            //Assert
            manager.DidNotReceive().GetDirectionFromKeyCode(f);
            manager.DidNotReceive().GetSchemeFromKeyCode(f);
            Assert.AreEqual(expectedPlayer, _behaviour.CurrentAmountOfPlayersJoin);
        }

        [Test]
        public void PlayerTwoSelection_With_Key_Pressed_Where_Control_Scheme_Not_Taken_CurrentPlayer_2()
        {   
            //Arrange
            IInputManager manager = Substitute.For<IInputManager>();
            manager.IsKeyBeingPressedAt(default).ReturnsForAnyArgs(KeyCode.W);
            manager.IsAnyKeyBeingPressed().Returns(KeyCode.DownArrow);
            _behaviour = new MainMenuManagerBehaviour(manager);

            //Act
            _behaviour.PlayerOneSelection();
            _behaviour.SetOfTakenControlSchemes = new HashSet<ControlScheme>() { ControlScheme.KEYS };
            _behaviour.PlayerTwoSelection();

            //Assert
            Assert.AreEqual(Player.PLAYER_TWO, _behaviour.CurrentAmountOfPlayersJoin);
        }

        [Test]
        public void PlayerTwoSelection_With_Key_Pressed_Where_Control_Scheme_Taken_CurrentPlayer_1()
        {
            //Arrange
            IInputManager manager = Substitute.For<IInputManager>();
            manager.IsKeyBeingPressedAt(default).ReturnsForAnyArgs(KeyCode.W);
            manager.IsAnyKeyBeingPressed().Returns(KeyCode.DownArrow);
            _behaviour = new MainMenuManagerBehaviour(manager);
            _behaviour.SetOfTakenControlSchemes = new HashSet<ControlScheme>() { ControlScheme.WASD };
            
            //Act
            _behaviour.PlayerOneSelection();
            _behaviour.PlayerTwoSelection();

            //Assert
            Assert.AreEqual(Player.PLAYER_ONE, _behaviour.CurrentAmountOfPlayersJoin);
        }

        [Test]
        public void PlayerTwoSelection_Without_One_ListOfOpenDirections_Throw_Exception()
        {
            //Arrange
            _behaviour.ListOfOpenDirections = new List<Direction>(){};

            //Act
            //Assert
            Assert.Catch(() => { _behaviour.PlayerTwoSelection(); });
        }

        [Test]
        public void PlayerThreeSelection_Without_Two_ListOfOpenDirections_Throw_Exception()
        {
            //Arrange
            _behaviour.ListOfOpenDirections = new List<Direction>() { };

            //Act
            //Assert
            Assert.Catch(() => { _behaviour.PlayerTwoSelection(); });
        }

        [Test]
        public void PlayerThreeSelection_With_Key_Pressed_Where_Control_Scheme_Taken_CurrentPlayer_2()
        {
            //Arrange
            IInputManager manager = Substitute.For<IInputManager>();
            KeyCode keyPressed = KeyCode.A;
            // Player One Selection
            manager.IsAnyKeyBeingPressed().Returns(KeyCode.W);
            //Player Two Selection
            manager.IsKeyBeingPressedAt(default).ReturnsForAnyArgs(KeyCode.DownArrow);
            manager.GetSchemeFromKeyCode(KeyCode.DownArrow).ReturnsForAnyArgs(ControlScheme.KEYS);
            // Player three selection
            manager.IsKeyBeingPressOnAxis(default).ReturnsForAnyArgs(keyPressed);
            manager.GetSchemeFromKeyCode(keyPressed).Returns(ControlScheme.WASD);

            _behaviour = new MainMenuManagerBehaviour(manager);

            //Act
            _behaviour.PlayerOneSelection();
            _behaviour.SetOfTakenControlSchemes.Add(ControlScheme.WASD);
            _behaviour.PlayerTwoSelection();
            _behaviour.SetOfTakenControlSchemes.Add(ControlScheme.KEYS);
            _behaviour.PlayerThreeSelection();  

            //Assert
            Assert.AreEqual(Player.PLAYER_TWO, _behaviour.CurrentAmountOfPlayersJoin);
        }

        [Test]
        public void PlayerThreeSelection_With_Key_Pressed_Where_Control_Scheme_Not_Taken_CurrentPlayer_3()
        {
            //Arrange
            IInputManager manager = Substitute.For<IInputManager>();
            KeyCode keyPressed = KeyCode.G;
            // Player One Selection
            manager.IsAnyKeyBeingPressed().Returns(KeyCode.W);
            //Player Two Selection
            manager.IsKeyBeingPressedAt(default).ReturnsForAnyArgs(KeyCode.DownArrow);
            manager.GetSchemeFromKeyCode(KeyCode.DownArrow).ReturnsForAnyArgs(ControlScheme.KEYS);
            // Player three selection
            manager.IsKeyBeingPressOnAxis(default).ReturnsForAnyArgs(keyPressed);
            manager.GetSchemeFromKeyCode(keyPressed).Returns(ControlScheme.YGHJ);
            _behaviour = new MainMenuManagerBehaviour(manager);

            //Act
            _behaviour.PlayerOneSelection();
            _behaviour.SetOfTakenControlSchemes.Add(ControlScheme.WASD);
            _behaviour.PlayerTwoSelection();
            _behaviour.SetOfTakenControlSchemes.Add(ControlScheme.KEYS);
            _behaviour.PlayerThreeSelection();

            //Assert
            Assert.AreEqual(Player.PLAYER_THREE, _behaviour.CurrentAmountOfPlayersJoin);
        }

        [Test]
        public void PlayerFourSelection_Without_Two_ListOfOpenDirections_Throw_Exception()
        {
            //Arrange
            _behaviour.ListOfOpenDirections = new List<Direction>() { };

            //Act
            //Assert
            Assert.Catch(() => { _behaviour.PlayerFourSelection(); });
        }

        [Test]
        public void PlayerFourSelection_With_Key_Pressed_Where_Control_Scheme_Taken_CurrentPlayer_3()
        {
            //Arrange
            IInputManager manager = Substitute.For<IInputManager>();
            // Player One Selection - WASD - UP
            manager.IsAnyKeyBeingPressed().Returns(KeyCode.W);
            //Player Two Selection - KEYS - Down
            manager.IsKeyBeingPressedAt(default).ReturnsForAnyArgs(KeyCode.DownArrow);
            manager.GetSchemeFromKeyCode(KeyCode.DownArrow).Returns(ControlScheme.KEYS);
            // Player three selection - YGHJ - Left
            manager.IsKeyBeingPressOnAxis(default).ReturnsForAnyArgs(KeyCode.G);
            manager.GetSchemeFromKeyCode(KeyCode.G).Returns(ControlScheme.YGHJ);
            //Player Four Selection - YGHJ - Right
            manager.IsKeyBeingPressedAt(default).Returns(KeyCode.J);
            manager.GetSchemeFromKeyCode(KeyCode.J).Returns(ControlScheme.YGHJ);

            _behaviour = new MainMenuManagerBehaviour(manager);

            //Act
            _behaviour.PlayerOneSelection();
            _behaviour.SetOfTakenControlSchemes.Add(ControlScheme.WASD);
            _behaviour.PlayerTwoSelection();
            _behaviour.SetOfTakenControlSchemes.Add(ControlScheme.KEYS);
            _behaviour.PlayerThreeSelection();
            _behaviour.SetOfTakenControlSchemes.Add(ControlScheme.YGHJ);
            _behaviour.PlayerFourSelection();

            //Assert
            Assert.AreEqual(Player.PLAYER_THREE, _behaviour.CurrentAmountOfPlayersJoin);
        }

        [Test]
        public void PlayerFourSelection_With_Key_Pressed_Where_Control_Scheme_Not_Taken_CurrentPlayer_4()
        {
            //Arrange
            IInputManager manager = Substitute.For<IInputManager>();
            // Player One Selection - WASD - UP
            manager.IsAnyKeyBeingPressed().Returns(KeyCode.W);
            //Player Two Selection - KEYS - Down
            manager.IsKeyBeingPressedAt(Direction.DOWN).Returns(KeyCode.DownArrow);
            manager.GetSchemeFromKeyCode(KeyCode.DownArrow).Returns(ControlScheme.KEYS);
            // Player three selection - YGHJ - Left
            manager.IsKeyBeingPressOnAxis(default).ReturnsForAnyArgs(KeyCode.G);
            manager.GetSchemeFromKeyCode(KeyCode.G).Returns(ControlScheme.YGHJ);
            //Player Four Selection - YGHJ - Right
            manager.IsKeyBeingPressedAt(Direction.RIGHT).Returns(KeyCode.Quote);
            manager.GetSchemeFromKeyCode(KeyCode.Quote).Returns(ControlScheme.PL);

            _behaviour = new MainMenuManagerBehaviour(manager);
            _behaviour.ListOfOpenDirections = new List<Direction>() { Direction.RIGHT };
            _behaviour.FirstChosenDirection = Direction.UP;

            //Act
            _behaviour.PlayerOneSelection();
            _behaviour.SetOfTakenControlSchemes.Add(ControlScheme.WASD);
            _behaviour.PlayerTwoSelection();
            _behaviour.SetOfTakenControlSchemes.Add(ControlScheme.KEYS);
            _behaviour.PlayerThreeSelection();
            _behaviour.SetOfTakenControlSchemes.Add(ControlScheme.YGHJ);
            _behaviour.PlayerFourSelection();

            //Assert
            Assert.AreEqual(Player.PLAYER_FOUR, _behaviour.CurrentAmountOfPlayersJoin);
        }

        [Test]
        public void CycleThroughBoards_With_Board_One_To_The_Right_Equal_Index()
        {   //1 -> 2
            //Arrange
            int expectedIndex = 1;
            _behaviour.CurrentBoardSelection = 0;

            //Act
            _behaviour.CycleThroughBoards(false);

            //Assert
            Assert.AreEqual(_behaviour.CurrentBoardSelection, expectedIndex);
        }

        [Test]
        public void CycleThroughBoards_With_Board_One_To_The_Left_Equal_Index()
        {
            //1 -> 3
            //Arrange
            int expectedIndex = 2;
            _behaviour.CurrentBoardSelection = 0;

            //Act
            _behaviour.CycleThroughBoards(true);

            //Assert
            Assert.AreEqual(expectedIndex, _behaviour.CurrentBoardSelection);
        }

        [Test]
        public void CycleThroughBoards_With_Board_Three_To_The_Left_Equal_Index()
        {
            // 3 -> 2
            //Arrange
            int expectedIndex = 1;
            _behaviour.CurrentBoardSelection = 2;

            //Act
            _behaviour.CycleThroughBoards(true);

            //Assert
            Assert.AreEqual(_behaviour.CurrentBoardSelection, expectedIndex);
        }

        [Test]
        public void CycleThroughBoards_With_Board_Three_To_The_Right_Equal_Index()
        {
            //3 -> 1
            //Arrange
            int expectedIndex = 0;
            _behaviour.CurrentBoardSelection = 2;

            //Act
            _behaviour.CycleThroughBoards(false);

            //Assert
            Assert.AreEqual(_behaviour.CurrentBoardSelection, expectedIndex);
        }

    }
}
