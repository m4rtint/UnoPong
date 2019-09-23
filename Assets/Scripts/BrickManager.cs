using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    private Brick[] bricks;
    private ParticleSystem[] brickBreaks;

    private Brick[] Bricks {
        get
        {
            if (bricks == null)
            {
                bricks = GetComponentsInChildren<Brick>();
            }

            return bricks;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
