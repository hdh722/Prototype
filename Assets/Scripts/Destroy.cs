using UnityEngine;

public class Spawn_our_spawn_move : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Team_another"))
        {
            Destroy(gameObject);
        }
    }
}
