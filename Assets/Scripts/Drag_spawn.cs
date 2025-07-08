using UnityEngine;

public class Drag_spawn : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private Vector3 originalPosition;

    void Start()
    {
        // 오브젝트의 원래 위치 저장
        originalPosition = transform.position;
    }

    void OnMouseDown()
    {
        // 마우스와 오브젝트의 거리 계산
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z);
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z) + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        // 드래그 해제 시 원래 위치로 복귀
        transform.position = originalPosition;
    }
}
