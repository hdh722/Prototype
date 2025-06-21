using UnityEngine;

public class Game_end : MonoBehaviour
{
    private Helath_our ourHealth;
    private Another_health anotherHealth;
    private bool ourTeamGameOver = false;
    private bool anotherTeamGameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ourHealth = FindObjectOfType<Helath_our>();
        anotherHealth = FindObjectOfType<Another_health>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ourHealth != null && !ourTeamGameOver && ourHealth.health <= 0)
        {
            ourTeamGameOver = true;
            GameOverOurTeam();
        }

        if (anotherHealth != null && !anotherTeamGameOver && anotherHealth.health <= 0)
        {
            anotherTeamGameOver = true;
            GameOverAnotherTeam();
        }
    }

    void GameOverOurTeam()
    {
        Debug.Log("우리팀 패배!");

        // 게임 일시정지
        Time.timeScale = 0f;
        AudioListener.pause = true;

        // 패배 UI 표시 (Pause_ui와 동일한 방식, 필요시 별도 UI로 변경)
        GameObject pauseUI = GameObject.FindWithTag("Gameover_ui");
        if (pauseUI != null)
        {
            Vector3 pos = pauseUI.transform.position;
            pos.x = 410f;
            pauseUI.transform.position = pos;
        }

    }
    void GameOverAnotherTeam()
    {
        Debug.Log("상대팀 패배!");

        // 게임 일시정지
        Time.timeScale = 0f;
        AudioListener.pause = true;

        // 패배 UI 표시 (Pause_ui와 동일한 방식, 필요시 별도 UI로 변경)
        GameObject pauseUI = GameObject.FindWithTag("Gameclear_ui");
        if (pauseUI != null)
        {
            Vector3 pos = pauseUI.transform.position;
            pos.x = 410f;
            pauseUI.transform.position = pos;
        }
    }
}
