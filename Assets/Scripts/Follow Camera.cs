using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void LateUpdate()
    {
        if (target != null)
        {
            UpdatePosition();
        }
    }

    private void UpdatePosition()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
}
