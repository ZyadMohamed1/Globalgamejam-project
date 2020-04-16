using UnityEngine.UI;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger instance = null;

    public bool isTimer;
    public float time;
    public Text timer;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void Open(string toolName, GameObject tool, Transform spawnPos)
    {
        GameObject Tool = Instantiate(tool, spawnPos.position, spawnPos.rotation);
    }

    private void Update()
    {
        Timer();
    }

    void Timer()
    {
        if(isTimer && time > 0)
        {
            time -= Time.deltaTime;
            timer.text = time.ToString("0.0");
        }
    }

    void Win()
    {

    }

    void GameOver()
    {

    }
}
