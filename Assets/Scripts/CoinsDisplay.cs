using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsDisplay : MonoBehaviour
{
    [SerializeField] int coins = 100;
    Text coinsText;
    private void Start()
    {
        coinsText = GetComponent<Text>();
        UpdateDisplay();   
    }

    private void UpdateDisplay()
    {
        coinsText.text = coins.ToString();
    }
    
    public void AddCoins(int moreCoins)
    {
        coins += moreCoins;
        UpdateDisplay();
    }

    public void SpendCoins(int someCoins)
    {
        if (coins >= someCoins)
        {
            coins -= someCoins;
            UpdateDisplay();
        }
    }
}
