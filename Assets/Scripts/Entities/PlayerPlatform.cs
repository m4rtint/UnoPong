using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPHT;

public interface IPlatform
{
    void Initialize(Vector3 position, Quaternion rotation, Direction direction, Player player, Material mat);
    Direction Direction { get; }
    Player Player { get; }
}

[RequireComponent(typeof(SpriteRenderer))]
public class PlayerPlatform : MonoBehaviour, IPlatform
{
    private Direction _direction;
    private Player _player;
    private SpriteRenderer _spriteRenderer;

    public Direction Direction => _direction;
    public Player Player => _player;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize(Vector3 position, Quaternion rotation, Direction direction, Player player, Material mat)
    {
        _direction = direction;
        _player = player;
        _spriteRenderer.material = mat;
        transform.position = position;
        transform.rotation = rotation;
    }
}
