using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public float volume;

    public Platform currentPlatform;
    public int currentSceneIndex;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        InitGame();
    }

    private void InitGame()
    {
        currentPlatform = Platform.PC;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void ChangeIndex(int index)
    {
        currentSceneIndex = index;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void RetryScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

public enum Platform
{
    Mobile,
    PC
}