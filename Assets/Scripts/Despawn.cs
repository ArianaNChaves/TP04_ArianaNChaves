using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    private const float DespawnTime = 8f;
    private void Start()
    {
        Destroy(this.gameObject, DespawnTime);
    }
}
