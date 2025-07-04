using UnityEngine;

public class MoveSmallStone : MonoBehaviour
{
    public float speed = 200f; // �ʴ� �̵� �ӵ�

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

        // x�� 100 ���϶�� �ı� �� ����
        if (transform.position.x <= 100f)
        {
            // Helath_our�� ������ �ֱ� (�Ǵ� Another_health�� ���� ����)
            Helath_our healthTarget = FindObjectOfType<Helath_our>();
            if (healthTarget != null)
            {
                healthTarget.TakeDamage(45);
            }
            Destroy(gameObject);
        }
    }
}