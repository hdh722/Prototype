using UnityEngine;

public class Move_our : MonoBehaviour
{
    public float speed = 0f;
    private bool isMoving = true;

    public float health = 5f;
    public float attack = 1f;
    public float attackSpeed = 2f;

    private bool isAttacking = false;

    public GameObject hitParticlePrefab; // 파티클 프리팹 연결

    void Update()
    {
        if (isMoving)
        {
            // x축으로 이동
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            // x값이 695 이상이면 이동 멈춤
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
        // x값이 695인 경우에만 health 감소
        if (Mathf.Approximately(transform.position.x, 695f))
        {
            // 자식 오브젝트에서 ParticleSystem 찾아서 Play
            ParticleSystem childParticle = GetComponentInChildren<ParticleSystem>();
            if (childParticle != null)
            {
                childParticle.Play();
            }

            health -= 1f;
            Debug.Log($"작동중, health: {health}");

            // Another_health의 체력 감소
            Another_health anotherHealth = FindObjectOfType<Another_health>();
            if (anotherHealth != null)
            {
                anotherHealth.TakeDamage((int)attack);
            }

            // health가 0 이하가 되면 반복 중지 및 오브젝트 파괴
            if (health <= 0f)
            {
                CancelInvoke(nameof(AttackAction));
                Debug.Log("health가 0이 되어 공격 중지 및 오브젝트 파괴");
                Destroy(gameObject);
            }
        }
    }
}

