using UnityEngine;

public class Move_our : MonoBehaviour
{
    public float speed = 0f;
    private bool isMoving = true;

    public float health = 5f;
    public float attack = 1f;
    public float attackSpeed = 2f;

    private bool isAttacking = false;

    public GameObject hitParticlePrefab; // ��ƼŬ ������ ����

    void Update()
    {
        if (isMoving)
        {
            // x������ �̵�
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            // x���� 695 �̻��̸� �̵� ����
            if (transform.position.x >= 695f)
            {
                isMoving = false;
                Vector3 pos = transform.position;
                pos.x = 695f;
                transform.position = pos;

                if (!isAttacking)
                {
                    isAttacking = true;
                    InvokeRepeating(nameof(AttackAction), 0f, attackSpeed);
                }
            }
        }
    }

    void AttackAction()
    {
        // x���� 695�� ��쿡�� health ����
        if (Mathf.Approximately(transform.position.x, 695f))
        {
            // �ڽ� ������Ʈ���� ParticleSystem ã�Ƽ� Play
            ParticleSystem childParticle = GetComponentInChildren<ParticleSystem>();
            if (childParticle != null)
            {
                childParticle.Play();
            }

            health -= 1f;
            Debug.Log($"�۵���, health: {health}");

            // Another_health�� ü�� ����
            Another_health anotherHealth = FindObjectOfType<Another_health>();
            if (anotherHealth != null)
            {
                anotherHealth.TakeDamage((int)attack);
            }

            // health�� 0 ���ϰ� �Ǹ� �ݺ� ���� �� ������Ʈ �ı�
            if (health <= 0f)
            {
                CancelInvoke(nameof(AttackAction));
                Debug.Log("health�� 0�� �Ǿ� ���� ���� �� ������Ʈ �ı�");
                Destroy(gameObject);
            }
        }
    }
}

