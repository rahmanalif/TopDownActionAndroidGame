using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PickUPCoin();
        }     
    }

    private void PickUPCoin()
    {
        ScoreManager.instance.ChangeScore(coinValue);
        GameStats.Instance.CollectCoin();
    }
}
