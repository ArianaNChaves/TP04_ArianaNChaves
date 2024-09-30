using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    
    private Rigidbody2D _playerRigidbody;
    private float _speed;
    
    private const float JumpThreshold = 0.01f;

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
        Debug.Log(_speed);
    }

    private void MovePlayer()
    {
        _playerRigidbody.velocity = new Vector2(_speed, _playerRigidbody.velocity.y);
    }

    private void CheckAndHandleJump()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_playerRigidbody.velocity.y) < JumpThreshold)
        {
            AudioManager.Instance.PlayEffect("Hit Sound");
            _playerRigidbody.AddForce(new Vector2(0, playerData.JumpForce), ForceMode2D.Impulse);
        }
    }
}
