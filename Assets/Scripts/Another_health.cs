using UnityEngine;
using UnityEngine.UI;

public class Another_health : MonoBehaviour
{
    [Header("체력 설정")]
    public int health = 200; // 인스펙터에서 지정

    [Header("UI 연결")]
    public Text healthText; // UI Text 연결

    void Start()
    {
        UpdateHealthUI();
    }

    // 체력 UI 갱신 함수
    public void UpdateHealthUI()
    {
        if (healthText != null)
            healthText.text = $"{health}";
    }

    // 예시: 체력 감소 함수
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;
        UpdateHealthUI();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
