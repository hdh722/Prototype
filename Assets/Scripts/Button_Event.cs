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
    void PauseGame()    //일시정지
    {
        Time.timeScale = 0f;
        isPaused = true;
        AudioListener.pause = true; 
        // 일시정지 ui
        GameObject pauseUI = GameObject.FindWithTag("Pause_ui");
        if (pauseUI != null)
        {
            Vector3 pos = pauseUI.transform.position;
            pos.x = 496f;
            pauseUI.transform.position = pos;
        }
    }
    void ResumeGame()   //일시정지 해제
    {
        Time.timeScale = 1f;
        isPaused = false;
        AudioListener.pause = false;
        // 일시정지 ui
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
        Debug.Log("게임 재시작");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        isPaused = false;
        AudioListener.pause = false;
    }
    public void Giveup()
    {
        Debug.Log("게임 포기");
        SceneManager.LoadScene("Lobby");
    }
    public void Setting()
    {
        Debug.Log("설정");
    }
    public void Gogame()
    {
        Debug.Log("게임 시작");
        SceneManager.LoadScene("Stage_1");
    }
}