using UnityEngine;
using UnityEngine.UI;

public class Another_health : MonoBehaviour
{
    [Header("ü�� ����")]
    public int health = 200; // �ν����Ϳ��� ����

    [Header("UI ����")]
    public Text healthText; // UI Text ����

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

    // ����: ü�� ���� �Լ�
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
