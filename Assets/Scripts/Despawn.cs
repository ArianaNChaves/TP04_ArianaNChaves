using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 8f);
    }
}
