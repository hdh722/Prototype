using UnityEngine;

public class Move_our : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        // ¶Ç´Â new Vector2(-1, 0) * speed * Time.deltaTime
    }
}

