using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MPHT
{
    public class InputManager : MonoBehaviour
    {
        internal const string _WASD = "WASD";
        internal const string _YGHJ = "YGHJ";
        internal const string _PL = "PL";
        internal const string _KEY = "KEYS";

        internal const string _Horizontal = "_Horizontal";
        internal const string _Vertical = "_Vertical";

        public static float OnHorizontalPressed(InputPlacement placement)
        {
            return OnKeysPressed(placement, true);
        }

        public static float OnVerticalPressed(InputPlacement placement)
        {
            return OnKeysPressed(placement, false);
        }

        private static float OnKeysPressed(InputPlacement placement, bool isHorizontal)
        {
            string axisName = "";
            switch (placement)
            {
                case InputPlacement.WASD:
                    axisName = _WASD;
                    break;
                case InputPlacement.YGHJ:
                    axisName = _YGHJ;
                    break;
                case InputPlacement.PL:
                    axisName = _PL;
                    break;
                case InputPlacement.KEYS:
                    axisName = _KEY;
                    break;
            }
            string axis = isHorizontal ? _Horizontal : _Vertical;
            return (axisName.Length == 0) ? 0 : Input.GetAxis(axisName + axis);
        }
    }

    public enum InputPlacement
    {
        WASD,
        YGHJ,
        PL,
        KEYS
    }
}
