using UnityEngine;
using UnityEngine.SceneManagement;
public class Button_Event : MonoBehaviour
{
    private bool isPaused = false;
    public void TogglePause()
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }
    void PauseGame()    //�Ͻ�����
    {
        Time.timeScale = 0f;
        isPaused = true;
        AudioListener.pause = true; 
        // �Ͻ����� ui
        GameObject pauseUI = GameObject.FindWithTag("Pause_ui");
        if (pauseUI != null)
        {
            Vector3 pos = pauseUI.transform.position;
            pos.x = 500f;
            pauseUI.transform.position = pos;
        }
    }
    void ResumeGame()   //�Ͻ����� ����
    {
        Time.timeScale = 1f;
        isPaused = false;
        AudioListener.pause = false;
        // �Ͻ����� ui
        GameObject pauseUI = GameObject.FindWithTag("Pause_ui");
        if (pauseUI != null)
        {
            Vector3 pos = pauseUI.transform.position;
            pos.x = -1000f;
            pauseUI.transform.position = pos;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        isPaused = false;
        AudioListener.pause = false;
    }
    public void Giveup()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void GoTitle()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Stage1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Stage_1");
    }
    public void Stage2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Stage_2");
    }
    public void Stage3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Stage_3");
    }
    public void Stage4()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Stage_4");
    }
    public void Touchtostart()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void GameOff()
    {
        Application.Quit();
    }
}