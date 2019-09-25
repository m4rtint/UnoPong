using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControls : MonoBehaviour
{
    [SerializeField]
    private bool isAddForce = false;
    [SerializeField]
    private float force = 3000f;
    private Rigidbody2D rigidBody;
    private Rigidbody2D RigidBody
    {
        get
        {
            if (rigidBody == null)
            {
                rigidBody = GetComponent<Rigidbody2D>();
            }

            return rigidBody;
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAddForce)
        {
            AddForceUpdate();
        }
        else
        {
            TranslatePlatform();
        }
    }

    private void AddForceUpdate()
    {
        if (MPHT.InputManager.OnHorizontalPressed() > 0)
        {
            RigidBody.velocity = Vector2.zero;
            RigidBody.AddForce(Vector2.right * force);
        }
        else if (MPHT.InputManager.OnHorizontalPressed() < 0)
        {
            RigidBody.velocity = Vector2.zero;
            RigidBody.AddForce(Vector2.left * force);
        }
        else
        {
            RigidBody.velocity = Vector2.zero;
        }
    }

    private void TranslatePlatform()
    {
        if (MPHT.InputManager.OnHorizontalPressed() > 0)
        {
            transform.position += new Vector3(0.3f, 0);
        }
        else if (MPHT.InputManager.OnHorizontalPressed() < 0)
        {
            transform.position -= new Vector3(0.3f, 0);
        }
    }
}
