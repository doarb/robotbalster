using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class KillCounter : MonoBehaviour
{
    public static KillCounter instance;
    public TextMeshProUGUI killText;
    public GameObject restartButton;
    public int killsToWin = 1;
    private int killCount = 0; 

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        restartButton.SetActive(false);
        UpdateKillText();
    }

    public void AddKill()
    {
        if (killCount <= killsToWin)
        {
            killCount++;
        }
        UpdateKillText();
        
    }

    private void UpdateKillText()
    {
        if (killText != null)
        {
            if (killCount >= killsToWin)
            {
                killText.text = "You win!";
                restartButton.SetActive(true);
            }
            else
            {
                killText.text = "Kills: " + killCount;
            }
            
        }
    }
    public void ResetKillCount()
    {
        killCount = 0;
        UpdateKillText();
    }

    public int GetKillCount()
    {
        return killCount;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
