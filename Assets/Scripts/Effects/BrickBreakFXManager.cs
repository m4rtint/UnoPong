using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBreakFXManager : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem blueParticleFX;
    public static BrickBreakFXManager instance;

    /// <summary>
    /// Plays Brick Break FX at Location
    /// </summary>
    /// <param name="location">Location of brick break shown</param>
    public void PlayBrickBreakAt(Vector2 location)
    {
        blueParticleFX.transform.position = location;
        blueParticleFX.Play();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

}

namespace MPHT
{
    public enum Color
    {
        Blue,
        Green,
        Red,
        Yellow
    }
}