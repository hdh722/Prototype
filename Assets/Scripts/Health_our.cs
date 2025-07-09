using UnityEngine;
using UnityEngine.UI;

public class Health_our : MonoBehaviour
{
    [Header("�츮�� ü��")]
    public int health = 200; // �ʱ� ü��

    [Header("UI ����")]
    public Text healthText; // UI Text ����

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateHealthUI();
    }

    // ü�� UI ���� �Լ�
    public void UpdateHealthUI()
    {
        if (healthText != null)
            healthText.text = $"{health}";
    }

    // ������: ü�� ���� �Լ�
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;
        UpdateHealthUI();
    }
}
