using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CoinScore : MonoBehaviour
{
    [SerializeField] private int _score;

    public event UnityAction<int> CoinScoreChanged;

    private void Start()
    {
        CoinScoreChanged?.Invoke(_score);
    }

    public void ApplyCoin(int coins)
    {
        _score += coins;
        CoinScoreChanged?.Invoke(_score);
    }
}
