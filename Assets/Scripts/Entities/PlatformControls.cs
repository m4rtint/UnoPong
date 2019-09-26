using MPHT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControls : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private Rigidbody2D RigidBody
    {
        get
        {
            if (_rigidBody == null)
            {
                _rigidBody = GetComponent<Rigidbody2D>();
            }

            return _rigidBody;
        }
    }
    private PlayerPlatform _playerPlat;
    private PlayerPlatform PlayerPlat
    {
        get
        {
            if (_playerPlat == null)
            {
                _playerPlat = GetComponent<PlayerPlatform>();
            }

            return _playerPlat;
        }
    }

    private void Awake()
    {
        WorldManager.OnFixedUpdate += PlatformControlOnUpdate;
    }

    private void OnDestroy()
    {
        WorldManager.OnFixedUpdate -= PlatformControlOnUpdate;
    }

    private void PlatformControlOnUpdate()
    {
        TranslatePlatform();
    }
    

    private void TranslatePlatform()
    {
        if (MPHT.InputManager.OnHorizontalPressed(PlayerPlat.Input) > 0)
        {
            transform.position += new Vector3(0.3f, 0);
        }
        else if (MPHT.InputManager.OnHorizontalPressed(PlayerPlat.Input) < 0)
        {
            transform.position -= new Vector3(0.3f, 0);
        }
    }
}
