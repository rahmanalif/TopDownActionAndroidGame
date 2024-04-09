using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : GameStats
{
    public static ScoreManager instance;

    [SerializeField]
    public Text CoinCount;
    public static int coinAmount;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int coinValue)
    {
        coinAmount += coinValue;
        CoinCount.text = "X" + coinAmount.ToString();
    }
}
