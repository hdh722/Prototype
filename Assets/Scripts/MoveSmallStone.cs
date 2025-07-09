using UnityEngine;

public class MoveSmallStone : MonoBehaviour
{
    public float speed = 200f; // 초당 이동 속도

    void Update()
    {
        float currentSpeed = speed;
        if (transform.position.x <= 650f)
        {
            currentSpeed += 70f;
        }
        if (transform.position.x <= 350f)
        {
            currentSpeed += 130f;
        }
        transform.position += Vector3.left * currentSpeed * Time.deltaTime;

        // x가 100 이하라면 파괴 및 피해
        if (transform.position.x <= 100f)
        {
            Debug.Log("SmallStone 충돌, 데미지 적용 시도");
            // Helath_our에 데미지 주기 (또는 Another_health로 변경 가능)
            Health_our healthTarget = FindObjectOfType<Health_our>();
            if (healthTarget != null)
            {
                healthTarget.TakeDamage(45);
            }
            Destroy(gameObject);
        }
    }
}
