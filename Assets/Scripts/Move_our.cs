using UnityEngine;

public class Move_our : MonoBehaviour
{
    public float speed = 0f;
    private bool isMoving = true;

    public float health = 5f;
    public float attack = 1f;
    float attackSpeed = 2f;

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
        // �̵��� ������ ���� health ����
        if (!isMoving)
        {
            // �ڽ� ������Ʈ���� ParticleSystem ã�Ƽ� Play
            ParticleSystem childParticle = GetComponentInChildren<ParticleSystem>();
            if (childParticle != null)
            {
                childParticle.Play();
            }

            health -= 1f;
            Debug.Log($"�۵���, health: {health}");

            // ���� ����� Another_health�� ü�� ����
            Another_health[] allTargets = FindObjectsOfType<Another_health>();
            Another_health closest = null;
            float minDist = float.MaxValue;
            Vector3 myPos = transform.position;

            foreach (var target in allTargets)
            {
                float dist = Vector3.Distance(myPos, target.transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    closest = target;
                }
            }

            if (closest != null)
            {
                closest.TakeDamage((int)attack);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Team_another") && other.name == "LockStone")
        {
            Debug.Log("!i");
            isMoving = false;

            if (!isAttacking)
            {
                isAttacking = true;
                InvokeRepeating(nameof(AttackAction), 0f, attackSpeed);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Team_another") && other.name == "LockStone")
        {
            isMoving = true;
            isAttacking = false;
            CancelInvoke(nameof(AttackAction));
        }
    }
}

