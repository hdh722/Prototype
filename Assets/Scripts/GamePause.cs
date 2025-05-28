using UnityEngine;

public class GamePause : MonoBehaviour
{
    private bool isPaused = false;

    // 버튼에서 이 메서드를 OnClick에 연결하세요.
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
    void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        // 필요하다면 일시정지 UI 표시 등 추가
    }
    void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        // 필요하다면 일시정지 UI 숨김 등 추가
    }
}

