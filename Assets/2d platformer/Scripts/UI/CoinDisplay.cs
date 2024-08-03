using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] private CoinScore _coinScorer;
    [SerializeField] private TMP_Text _coinDisplay;

    private void OnEnable()
    {
        _coinScorer.CoinScoreChanged += OnCoinChanged;
    }

    private void OnDisable()
    {
        _coinScorer.CoinScoreChanged -= OnCoinChanged;
    }

    private void OnCoinChanged(int coinScore)
    {
        _coinDisplay.text = "Score: " + coinScore.ToString();
    }
}