using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using MPHT;
using NSubstitute;

namespace Tests
{
    public class PlayerManager_Tests
    {
        IMaterials mat;

        [SetUp]
        public void Setup()
        {
            mat = Substitute.For<IMaterials>();
        }
        
        [TearDown]
        public void Teardown()
        {
            mat = null;
        }

        [Test]
        public void CheckPlayerAvailabilityCount_With_Equal_Amount_Of_Players()
        {
            //Arrange
            PlayerManagerBehaviour behaviour = new PlayerManagerBehaviour(mat);

            //Assert
            Assert.DoesNotThrow(() => { behaviour.CheckPlayerAvailabilityCount(new IPlatform[4]) ;});
        }

        [Test]
        public void CheckPlayerAvailabilityCount_With_Not_Equal_Amount_Of_Players()
        {
            //Arrange
            PlayerManagerBehaviour behaviour = new PlayerManagerBehaviour(mat);

            //Assert
            Assert.Catch(() => { behaviour.CheckPlayerAvailabilityCount(new IPlatform[2]); });
        }

        [Test]
        public void GetPositionFromDirection_With_Up_Direction()
        {
            //Arrange
            PlayerManagerBehaviour behaviour = new PlayerManagerBehaviour(mat);
            Direction dir = Direction.UP;
            Vector3 expected = new Vector3(0, 4);
            //Act
            Vector3 actual = behaviour.GetPositionFromDirection(dir);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void GetPositionFromDirection_With_Down_Direction()
        {
            //Arrange
            PlayerManagerBehaviour behaviour = new PlayerManagerBehaviour(mat);
            Direction dir = Direction.DOWN;
            Vector3 expected = new Vector3(0, -4);

            //Act
            Vector3 actual = behaviour.GetPositionFromDirection(dir);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void GetPositionFromDirection_With_Left_Direction()
        {
            //Arrange
            PlayerManagerBehaviour behaviour = new PlayerManagerBehaviour(mat);
            Direction dir = Direction.LEFT;
            Vector3 expected = new Vector3(-4, 0);

            //Act
            Vector3 actual = behaviour.GetPositionFromDirection(dir);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void GetPositionFromDirection_With_Right_Direction()
        {
            //Arrange
            PlayerManagerBehaviour behaviour = new PlayerManagerBehaviour(mat);
            Direction dir = Direction.RIGHT;
            Vector3 expected = new Vector3(4, 0);

            //Act
            Vector3 actual = behaviour.GetPositionFromDirection(dir);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void PlatformInitialize_With_Up_Direction_And_Intialize_Ran()
        {
            //Arrange
            PlayerManagerBehaviour behaviour = new PlayerManagerBehaviour(mat);
            IPlatform playerPlat = Substitute.For<IPlatform>();
            Direction dir = Direction.UP;
            Player player = Player.PLAYER_ONE;
            InputPlacement placement = InputPlacement.KEYS;

            //Act
            behaviour.PlatformInitialize(playerPlat, dir, player, placement);

            //Assert
            playerPlat.ReceivedWithAnyArgs().Initialize(default, default, default, default, default, default);
        }

        [Test]
        public void GetRotationFromDirection_With_Direction_Up()
        {
            //Arrange
            PlayerManagerBehaviour behaviour = new PlayerManagerBehaviour(mat);
            Direction dir = Direction.UP;
            Quaternion expectedDirection = Quaternion.identity;

            //Act
            Quaternion actualDirection = behaviour.GetRotationFromDirection(dir);

            //Assert
            Assert.AreEqual(expectedDirection, actualDirection);
        }

        [Test]
        public void GetRotationFromDirection_With_Direction_Down()
        {
            //Arrange
            PlayerManagerBehaviour behaviour = new PlayerManagerBehaviour(mat);
            Direction dir = Direction.UP;
            Quaternion expectedDirection = Quaternion.identity;

            //Act
            Quaternion actualDirection = behaviour.GetRotationFromDirection(dir);

            //Assert
            Assert.AreEqual(expectedDirection, actualDirection);
        }

        [Test]
        public void GetRotationFromDirection_With_Direction_Left()
        {
            //Arrange
            PlayerManagerBehaviour behaviour = new PlayerManagerBehaviour(mat);
            Direction dir = Direction.LEFT;
            Quaternion expectedDirection = Quaternion.Euler(0, 0, 90);

            //Act
            Quaternion actualDirection = behaviour.GetRotationFromDirection(dir);

            //Assert
            Assert.AreEqual(expectedDirection, actualDirection);
        }

        [Test]
        public void GetRotationFromDirection_With_Direction_Right()
        {
            //Arrange
            PlayerManagerBehaviour behaviour = new PlayerManagerBehaviour(mat);
            Direction dir = Direction.RIGHT;
            Quaternion expectedDirection = Quaternion.Euler(0, 0, 90);

            //Act
            Quaternion actualDirection = behaviour.GetRotationFromDirection(dir);

            //Assert
            Assert.AreEqual(expectedDirection, actualDirection);
        }
    }
}
