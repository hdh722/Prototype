using UnityEngine;

public class GamePause : MonoBehaviour
{
    private bool isPaused = false;

    // ��ư���� �� �޼��带 OnClick�� �����ϼ���.
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
        // �ʿ��ϴٸ� �Ͻ����� UI ǥ�� �� �߰�
    }
    void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        // �ʿ��ϴٸ� �Ͻ����� UI ���� �� �߰�
    }
}

