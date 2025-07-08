using UnityEngine;

public class Drag_spawn : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;
    private Vector3 originalPosition;

    void Start()
    {
        // ������Ʈ�� ���� ��ġ ����
        originalPosition = transform.position;
    }

    void OnMouseDown()
    {
        // ���콺�� ������Ʈ�� �Ÿ� ���
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
        // �巡�� ���� �� ���� ��ġ�� ����
        transform.position = originalPosition;
    }
}
