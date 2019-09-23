using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTime : MonoBehaviour
{
    public float scale = 100f;
    public float bulletTimeScale = 0.1f;

    private void Start()
    {
        Time.timeScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Time.timeScale = bulletTimeScale;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Time.timeScale = scale;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
    }
}
