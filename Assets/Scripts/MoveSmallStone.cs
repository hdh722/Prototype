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
            Debug.Log("SmallStone �浹, ������ ���� �õ�");
            // Helath_our�� ������ �ֱ� (�Ǵ� Another_health�� ���� ����)
            Health_our healthTarget = FindObjectOfType<Health_our>();
            if (healthTarget != null)
            {
                healthTarget.TakeDamage(45);
            }
            Destroy(gameObject);
        }
    }
}
