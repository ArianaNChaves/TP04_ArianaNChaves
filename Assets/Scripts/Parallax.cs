using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField, Range(0,1)] private float parallaxEffectLayer;
    private float _spriteLength;
    private Vector3 _initialPosition;

    void Start()
    {
        _initialPosition = transform.position;
        _spriteLength = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void LateUpdate()
    {
        ApplyParallax();
        ResetPosition();
    }

    private void ApplyParallax()
    {
        float deltaX = CalculateDeltaX();
        transform.position = new Vector3(_initialPosition.x + deltaX, transform.position.y, transform.position.z);
    }
    
    private float CalculateDeltaX()
    {
        return player.position.x * parallaxEffectLayer;
    }

    private void ResetPosition()
    {
        float temp = GetRelativeBackgroundPosition();
        if (temp > _initialPosition.x + _spriteLength)
        {
            _initialPosition.x += _spriteLength;
        }
        else if (temp < _initialPosition.x - _spriteLength)
        {
            _initialPosition.x -= _spriteLength;
        }
    }

    private float GetRelativeBackgroundPosition()
    {
        return player.position.x * (1 - parallaxEffectLayer);
    }
    
}