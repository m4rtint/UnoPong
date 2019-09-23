using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksAnimation : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            float scale = Time.timeScale;
            Time.timeScale = 0;
            float z = transform.eulerAngles.z + 90;
            Debug.Log(transform.rotation.z);
            transform.LeanRotateZ(z, 2f)
                .setOnComplete(() => { Time.timeScale = scale;})
                .setIgnoreTimeScale(true);
        }
    }
}
