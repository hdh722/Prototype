using UnityEngine;
using UnityEngine.UI; // ���Ž� UI ������Ʈ�� ����� �� �ʿ�
public class Timer : MonoBehaviour
{
    public float timeRemaining = 60f; // ���� �ð� (�� ����)
    public bool isTimerRunning = true;
    public Text timerText; // TextMeshProUGUI ��� Text ���

    void Update()
    {
        if (isTimerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                isTimerRunning = false;
                UpdateTimerDisplay(timeRemaining);
                // Ÿ�̸� ���� �̺�Ʈ ó��
            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(0, timeToDisplay);
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // 10�� ������ �� �۾� ���� ���������� ����, �ƴϸ� ������� ����
        if (timeToDisplay <= 10f)
        {
            timerText.color = Color.red;
        }
        else
        {
            timerText.color = Color.white;
        }
    }
}
