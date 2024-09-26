using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void LateUpdate()
    {
        if (player != null)
        {
            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
    }
}
