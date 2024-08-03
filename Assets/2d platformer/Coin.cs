using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _coins = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CoinScore coinScore))
        {
            coinScore.ApplyCoin(_coins);
            Debug.Log("Работает Coin");
        }

        Destroy(gameObject);
    }
}
