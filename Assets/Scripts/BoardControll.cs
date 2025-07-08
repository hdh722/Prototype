using UnityEngine;

public class BoardControll : MonoBehaviour
{
    public float moveAmount = 100f; // 초당 y값 이동량

    void Update()
    {
        Vector3 pos = transform.position;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.y += moveAmount * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.y -= moveAmount * Time.deltaTime;
        }

        // y값이 범위를 벗어나면 경계값으로 고정
        if (pos.y > 334f)
        {
            pos.y = 334f;
        }
        else if (pos.y < 115f)
        {
            pos.y = 115f;
        }

        transform.position = pos;
    }

    // Small_Stone 태그 오브젝트와 닿으면 내 자식 파티클 재생 후 Small_Stone 삭제
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Small_Stone"))
        {
            PlayMyParticle();
            Destroy(other.gameObject);
        }
    }

    private void PlayMyParticle()
    {
        // 내 자식에서 ParticleSystem 찾기
        ParticleSystem ps = GetComponentInChildren<ParticleSystem>();
        if (ps != null)
        {
            ps.Play();
        }
    }
}
