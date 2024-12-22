using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static bool isContinue=false;
    public static int HighScore = 0;
    private void Awake()
    {
        
        s_instance = this;
        m_state = GameState.Playing;
        if(isContinue==false)
        {
            PlayerPrefs.SetInt("SCORE", 0);
            score = 0;
        }
        else if(isContinue==true)
        {
            score = PlayerPrefs.GetInt("SCORE", score);
            isContinue = false;
        }
    }
    private void Update()
    {
        PlayerPrefs.SetInt("SCORE", score);
        if(score>PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
    }
    public GameState state
    {
        get { return m_state; }
        set
        {
            m_state = value;
            if(GameState.End == value)
            {
                // 游戏结束
                var canvas = GameObject.Find("Canvas");
                var prefab = Resources.Load("GameOverPanel");
                var panel = GameObject.Instantiate(prefab) as GameObject;
                panel.transform.SetParent(canvas.transform, false);
            }
        }
    }

    private GameState m_state = GameState.Ready;
    public int score
    {
        get { return m_score; }
        set 
        {
            if (value != m_score)
                EventDispatcher.instance.DispatchEvent(EventNameDef.EVENT_ADD_COIN, value);
            m_score = value; 
        }
    }
    private int m_score;


    private static GameMgr s_instance;
    public static GameMgr instance { get { return s_instance; } }
}

public enum GameState
{
    Ready,
    Playing,
    End,
}
