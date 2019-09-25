using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    [SerializeField]
    private MPHT.Effect _effect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == MPHT.Tags.Ball)
        {
            MPHT.FXObjectPooler.Instance.SpawnFromPool(_effect, transform.position, Quaternion.identity);
            SimpleCameraShake.Instance.PlayShake();
            gameObject.SetActive(false);
        }
    }
}
