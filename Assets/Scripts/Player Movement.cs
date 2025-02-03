using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private float rayLength = 0.1f;
    [SerializeField] private float gravity = 9.8f;
    
    private Rigidbody2D _playerRigidbody;
    private float _speed;
    
    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _speed = playerData.MovementSpeed;
    }

    private void OnEnable()
    { 
        Cherry.OnCherryTrigger += ChangeSpeed;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Update()
    {
        CheckAndHandleJump();
    }

    private void OnDisable()
    {
        Cherry.OnCherryTrigger -= ChangeSpeed;
    }

    private void ChangeSpeed()
    {
        _speed += playerData.SpeedMultiplier;
    }

    private void MovePlayer()
    {
        _playerRigidbody.velocity = new Vector2(_speed, _playerRigidbody.velocity.y);
    }

    private void CheckAndHandleJump()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            AudioManager.Instance.PlayEffect("Hit Sound");
            _playerRigidbody.AddForce(new Vector2(0, playerData.JumpForce), ForceMode2D.Impulse);
        }

        if (_playerRigidbody.velocity.y <= 0)
        {
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, _playerRigidbody.velocity.y - gravity * Time.deltaTime);
        }
    }

    private bool IsGrounded()
    {
        Vector2 origin = transform.position;
        Vector2 direction = Vector2.down;

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, rayLength, LayerMask.GetMask("Ground"));

        return hit.collider != null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 origin = transform.position;
        Vector2 direction = Vector2.down;
        Gizmos.DrawRay(origin, direction * rayLength);
    }
}
