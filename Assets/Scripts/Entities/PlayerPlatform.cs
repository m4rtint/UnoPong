using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MPHT;

public interface IPlatform
{
    void Initialize(Vector3 position, Quaternion rotation, Direction direction, Player player, Material mat, InputPlacement placement);
    Direction Direction { get; }
    Player Player { get; }
}

[RequireComponent(typeof(PlatformControls))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerPlatform : MonoBehaviour, IPlatform
{
    private Direction _direction;
    private Player _player;
    private SpriteRenderer _spriteRenderer;
    private InputPlacement _inputPlacement;

    public Direction Direction => _direction;
    public Player Player => _player;
    public InputPlacement Input => _inputPlacement;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Initialize(Vector3 position, Quaternion rotation, Direction direction, Player player, Material mat, InputPlacement placement)
    {
        _direction = direction;
        _player = player;
        _spriteRenderer.material = mat;
        _inputPlacement = placement;
        transform.position = position;
        transform.rotation = rotation;
    }
}
