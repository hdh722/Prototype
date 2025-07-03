using UnityEngine;

public class Game_end : MonoBehaviour
{
    private Helath_our ourHealth;
    private Another_health anotherHealth;
    private Timer timer; // Timer 참조 추가
    private bool ourTeamGameOver = false;
    private bool anotherTeamGameOver = false;
    private bool isTimeOver = false; // 시간 종료 플래그

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ourHealth = FindObjectOfType<Helath_our>();
        anotherHealth = FindObjectOfType<Another_health>();
        timer = FindObjectOfType<Timer>(); // Timer 컴포넌트 찾기
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

        // 타이머가 0 이하가 되면 게임 종료
        if (timer != null && !isTimeOver && timer.timeRemaining <= 0f)
        {
            isTimeOver = true;
            GameOverOurTeam(); // 시간 종료 시 우리팀 패배 처리 (원하는 방식으로 변경 가능)
        }
    }

    void GameOverOurTeam()
    {
        Debug.Log("탐험 실패");

        // 게임 일시정지
        Time.timeScale = 0f;
        AudioListener.pause = true;

        // 패배 UI 표시 (Pause_ui와 동일한 방식, 필요시 별도 UI로 변경)
        GameObject pauseUI = GameObject.FindWithTag("Gameover_ui");
        if (pauseUI != null)
        {
            Vector3 pos = pauseUI.transform.position;
            pos.x = 500f;
            pauseUI.transform.position = pos;
        }
    }

    void GameOverAnotherTeam()
    {
        Debug.Log("탐험 성공");

        // 게임 일시정지
        Time.timeScale = 0f;
        AudioListener.pause = true;

        // 패배 UI 표시 (Pause_ui와 동일한 방식, 필요시 별도 UI로 변경)
        GameObject pauseUI = GameObject.FindWithTag("Gameclear_ui");
        if (pauseUI != null)
        {
            Vector3 pos = pauseUI.transform.position;
            pos.x = 500f;
            pauseUI.transform.position = pos;
        }
    }
}
