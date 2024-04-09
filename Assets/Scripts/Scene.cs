using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene : MonoBehaviour
{
    //public static bool GameIsPause = false;

    public GameObject pauseMenuUI;

    public GameObject ShopMenuUI;


    private void Start()
    {

    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
        SaveManager.Instance.Save();
        SaveManager.Instance.save.Coin += GameStats.Instance.coinCollectedThisSession;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        ShopMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void pause()
    {
        pauseMenuUI.SetActive(true);
        ShopMenuUI.SetActive(false);
        Time.timeScale = 0f;
        SaveManager.Instance.Save();
        SaveManager.Instance.save.Coin += GameStats.Instance.coinCollectedThisSession;
    }

    public void Shop()
    {
        ShopMenuUI.SetActive(true);
        
    }

    public void Quit()
    {
        Application.Quit();
        SaveManager.Instance.Save();
    }
}
