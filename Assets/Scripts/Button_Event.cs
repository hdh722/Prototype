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
            pos.x = 496f;
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
        Debug.Log("���� �����");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        isPaused = false;
        AudioListener.pause = false;
    }
    public void Giveup()
    {
        Debug.Log("���� ����");
        SceneManager.LoadScene("Lobby");
    }
    public void Setting()
    {
        Debug.Log("����");
    }
    public void Gogame()
    {
        Debug.Log("���� ����");
        SceneManager.LoadScene("Stage_1");
    }
}