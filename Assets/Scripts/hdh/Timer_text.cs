using UnityEngine;
using UnityEngine.UI; // 레거시 UI 컴포넌트를 사용할 때 필요
public class Timer : MonoBehaviour
{
    public float timeRemaining = 60f; // 시작 시간 (초 단위)
    public bool isTimerRunning = true;
    public Text timerText; // TextMeshProUGUI 대신 Text 사용

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
                // 타이머 종료 이벤트 처리
            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(0, timeToDisplay);
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // 10초 이하일 때 글씨 색을 붉은색으로 변경, 아니면 흰색으로 복원
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
