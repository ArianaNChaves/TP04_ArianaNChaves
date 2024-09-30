using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : MonoBehaviour
{
    public static event Action OnCherryTrigger;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.Instance.PlayEffect("Pickup effect");
            OnCherryTrigger?.Invoke();
            Destroy(this.gameObject);
        }
    }
}
