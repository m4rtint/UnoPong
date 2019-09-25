using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using MPHT;

namespace Tests
{
    public class PlayerManager_Tests
    {
        [Test]
        public void CheckPlayerAvailabilityCount_With_Equal_Amount_Of_Players()
        {
            //Arrange
            PlayerManagerBehaivour behaivour = new PlayerManagerBehaivour();

            //Assert
            Assert.DoesNotThrow(() => { behaivour.CheckPlayerAvailabilityCount(new PlayerPlatform[4]) ;});
        }

        [Test]
        public void CheckPlayerAvailabilityCount_With_Not_Equal_Amount_Of_Players()
        {
            //Arrange
            PlayerManagerBehaivour behaivour = new PlayerManagerBehaivour();

            //Assert
            Assert.Catch(() => { behaivour.CheckPlayerAvailabilityCount(new PlayerPlatform[2]); });
        }
    }
}
