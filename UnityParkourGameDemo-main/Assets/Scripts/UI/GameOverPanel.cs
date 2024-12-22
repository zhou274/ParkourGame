
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverPanel : MonoBehaviour
{
    public Button restartBtn;
    public TextMeshProUGUI HighSocre;

    void Start()
    {
        restartBtn.onClick.AddListener(() => 
        {
            GameMgr.instance.state = GameState.Playing;
            SceneManager.LoadScene(1);
        });
    }
    public void Update()
    {
        HighSocre.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
    public void Continue()
    {
        GameMgr.instance.state = GameState.Playing;
        GameMgr.isContinue = true;
        SceneManager.LoadScene(1);
    }
}
