using System;
using UnityEngine;

public class GameStats : MonoBehaviour
{
    public static GameStats Instance { get { return instance; } }
    private static GameStats instance;

    //coin
    public int totalCoin;
    public int coinCollectedThisSession;

    //Action
    public Action<int> OnCollectCoin;


    private void Awake()
    {
        instance = this;
    }

    public void CollectCoin()
    {
        coinCollectedThisSession++;
        OnCollectCoin?.Invoke(coinCollectedThisSession);
    }

    public void ResetSession()
    {
      coinCollectedThisSession = 0;

      OnCollectCoin?.Invoke(coinCollectedThisSession);

        ScoreManager.coinAmount = 0;
    }

}
