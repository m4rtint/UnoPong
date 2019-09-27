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
        [Test]
        public void OppositeDirection_With_Direction_Up_Equal_Direction_Down()
		{
            Assert.True(false);
		}

		[Test]
		public void OppositeDirection_With_Direction_Down_Equal_Direction_Up()
		{
            Assert.True(false);
        }

		[Test]
		public void OppositeDirection_With_Direction_Left_Equal_Direction_Right()
		{
            Assert.True(false);
        }

		[Test]
		public void OppositeDirection_With_Direction_Right_Equal_Direction_Left()
		{
            Assert.True(false);
        }

        [Test]
        public void DirectionToDeactivate_With_First_Choice_Up_With_Equal_Set()
		{
            Assert.True(false);
        }

		[Test]
		public void DirectionToDeactivate_With_First_Choice_Down_With_Equal_Set()
		{
            Assert.True(false);
        }

		[Test]
		public void DirectionToDeactivate_With_First_Choice_Left_With_Equal_Set()
		{
            Assert.True(false);
        }

		[Test]
		public void DirectionToDeactivate_With_First_Choice_Right_With_Equal_Set()
		{
            Assert.True(false);
        }

		[Test]
		public void DirectionToDeactivate_With_First_Choice_Up_Second_Choice_Down_With_Equal_Set()
		{
            Assert.True(false);
        }

		[Test]
		public void DirectionToDeactivate_With_First_Choice_Left_Second_Choice_Right_With_Equal_Set()
		{
            Assert.True(false);
        }

		[Test]
		public void DirectionToDeactivate_With_First_Choice_Right_Second_Choice_Left_Third_Choice_Up_With_Equal_Set()
		{
            Assert.True(false);
        }

        [Test]
        public void PlayerOneSelection_With_W_Pressed_Delegate_Called_With_Correct_Arguments()
        {
            Assert.True(false);
            // TODO - chosen Direction, current player, controls should be correct
        }

        [Test]
        public void PlayerOneSelection_With_Wrong_Key_Pressed_Delegate_Not_Called_Player_Not_Incremented()
        {
            Assert.True(false);
        }
    }
}
