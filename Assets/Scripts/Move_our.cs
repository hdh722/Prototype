using UnityEngine;

public class Move_our : MonoBehaviour
{
    public float speed = 0f;
    private bool isMoving = true;

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
            }
        }
    }
}

