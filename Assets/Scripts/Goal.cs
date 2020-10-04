using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private int requiredCoins;
    private Game game;
    [SerializeField]
    private TMPro.TextMeshProUGUI coinText;
    // Use this for initialization
    void Start()
    {
        game = FindObjectOfType<Game>();
        requiredCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    public void CheckForCompletion(int coinCount)
    {
        if (coinCount >= requiredCoins)
        {
            game.LoadNextLevel();
        }
        else
        {
            coinText.text = string.Format("Not enough coins!\nYou need {0} more to continue.", requiredCoins-coinCount);
        }
    }
}
