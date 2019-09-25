using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float force = 10f;
    // Start is called before the first frame update
    void Start()
    {
        var x = Random.Range(0, 1.0f);
        var y = Random.Range(0, 1.0f);
        PushBall(new Vector2(x,y));
    }

    void PushBall(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().AddForce(direction * force);
    }
}
