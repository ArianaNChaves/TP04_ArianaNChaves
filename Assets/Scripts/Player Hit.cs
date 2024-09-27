using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    [SerializeField] private UiManager uiManager;
    private SpriteRenderer _spriteRenderer;
    private Color _defaultColor;
    private Color _hitColor;


    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _defaultColor = Color.white;
        _hitColor = Color.red;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Hit();
            uiManager.AppearLosePanel();
        }
    }

    private void Hit()
    {
        AudioManager.Instance.StopMusic();
        AudioManager.Instance.PlayEffect("Defeat Sound");
        _spriteRenderer.color = _hitColor;
    }
}
