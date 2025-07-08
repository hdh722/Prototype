using UnityEngine;

public class BoardControll : MonoBehaviour
{
    public float moveAmount = 100f; // �ʴ� y�� �̵���

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

        // y���� ������ ����� ��谪���� ����
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

    // Small_Stone �±� ������Ʈ�� ������ �� �ڽ� ��ƼŬ ��� �� Small_Stone ����
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
        // �� �ڽĿ��� ParticleSystem ã��
        ParticleSystem ps = GetComponentInChildren<ParticleSystem>();
        if (ps != null)
        {
            ps.Play();
        }
    }
}
