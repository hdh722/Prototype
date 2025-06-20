using UnityEngine;

public class MoveSmallStone : MonoBehaviour
{
    public float speed = 100f; // 초당 이동 속도

    void Update()
    {
        float currentSpeed = speed;
        if (transform.position.x <= 600f)
        {
            currentSpeed += 40f;
        }
        if (transform.position.x <= 350f)
        {
            currentSpeed += 70f;
        }
        transform.position += Vector3.left * currentSpeed * Time.deltaTime;

        // x가 100 이하라면 파괴 및 피해
        if (transform.position.x <= 100f)
        {
            // Helath_our에 데미지 주기 (또는 Another_health로 변경 가능)
            Helath_our healthTarget = FindObjectOfType<Helath_our>();
            if (healthTarget != null)
            {
                healthTarget.TakeDamage(15);
            }
            Destroy(gameObject);
        }
    }
}