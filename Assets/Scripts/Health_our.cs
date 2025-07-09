using UnityEngine;
using UnityEngine.UI;

public class Health_our : MonoBehaviour
{
    [Header("우리팀 체력")]
    public int health = 200; // 초기 체력

    [Header("UI 연동")]
    public Text healthText; // UI Text 연결

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

    // 데미지: 체력 감소 함수
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;
        UpdateHealthUI();
    }
}
