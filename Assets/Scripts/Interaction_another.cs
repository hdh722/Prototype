using UnityEngine;

public class Interaction_another : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Team_another"))
        {
            Move_our move = other.GetComponent<Move_our>();
            if (move != null)
            {
                move.speed = 0f;
                Debug.Log("¿Ãµø ∏ÿ√„");
            }
        }
    }
}
