using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Data", menuName = "ScriptableObjects/Player Data")]
public class PlayerData : ScriptableObject
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    
    
    public float MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
    public float JumpForce { get => jumpForce; set => jumpForce = value; }
}
