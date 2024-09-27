using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    
    private Rigidbody2D _playerRigidbody;
    
    private const float JumpThreshold = 0.01f;

    private void Start()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Update()
    {
        CheckAndHandleJump();
    }

    private void MovePlayer()
    {
        _playerRigidbody.velocity = new Vector2(playerData.MovementSpeed, _playerRigidbody.velocity.y);
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
