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
        Debug.Log("�츮�� �й�!");

        // ���� �Ͻ�����
        Time.timeScale = 0f;
        AudioListener.pause = true;

        // �й� UI ǥ�� (Pause_ui�� ������ ���, �ʿ�� ���� UI�� ����)
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
        Debug.Log("����� �й�!");

        // ���� �Ͻ�����
        Time.timeScale = 0f;
        AudioListener.pause = true;

        // �й� UI ǥ�� (Pause_ui�� ������ ���, �ʿ�� ���� UI�� ����)
        GameObject pauseUI = GameObject.FindWithTag("Gameclear_ui");
        if (pauseUI != null)
        {
            Vector3 pos = pauseUI.transform.position;
            pos.x = 410f;
            pauseUI.transform.position = pos;
        }
    }
}
