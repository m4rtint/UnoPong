using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MPHT
{
    public class InputManager : MonoBehaviour
    {
        public static float OnHorizontalPressed()
        {
            return Input.GetAxis("Horizontal");
        }
    }
}
