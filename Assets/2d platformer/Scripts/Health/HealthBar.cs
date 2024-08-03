using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartLenpLate;

    private List<Heart> _hearts = new List<Heart>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
        //Slider.value = 1;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        int createHealth = value - _hearts.Count;

        if (_hearts.Count < value)
        {
            for (int i = 0; i < createHealth; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > value && _hearts.Count != 0)
        {
            int delateHeath = _hearts.Count - value;

            for (int i = 0; i < delateHeath; i++)
            {
                DestroyHeart(_hearts[_hearts.Count - 1]);
            }
        }
    }

    private void DestroyHeart(Heart heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();
    }

    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heartLenpLate, transform);
        _hearts.Add(newHeart.GetComponent<Heart>());
        newHeart.ToFill();
    }
}
