using UnityEngine;

public class Char_move : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    void Start()
    {
        Debug.Log("testttttttt");
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // ¡ç ¡æ Å°
        float moveY = Input.GetAxisRaw("Vertical");   // ¡è ¡é Å°

        Vector3 movement = new Vector3(moveX, moveY, 0);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}
