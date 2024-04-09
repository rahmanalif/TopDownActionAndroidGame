using System;

[System.Serializable]
public class SaveState
{
    public int Coin { set; get; }
    public DateTime LastSaveTime { set; get; }

    public SaveState()
    {

        Coin = 0;
        LastSaveTime = DateTime.Now;

    }

}
