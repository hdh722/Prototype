using UnityEngine;

public class Spawn_our_set : MonoBehaviour
{
    public GameObject objectToSpawn;      // ��ȯ�� ������
    public BoxCollider2D spawnArea;       // ���� ���� ����
    public float spawnInterval = 3f;      // ��ȯ �ֱ�
    public float lifetime = 5f;           // ��ȯ �� ���� �ð�
    public float fixedX = 0f;             // ���� X ��ġ (�Ǵ� ������ ����)
    public float Attack = 1f;
    public float health = 1f;
    [Tooltip("��ȯ�Ǵ� ������Ʈ�� �±׸� �����ϼ���.")]
    public string spawnTag = "Team_our";  // �ν����Ϳ��� ������ �±�

    void SpawnObject()
    {
        Bounds bounds = spawnArea.bounds;

        float minY = bounds.min.y;
        float maxY = bounds.max.y;
        float randomY = Random.Range(minY, maxY);
        Vector2 spawnPos = new Vector2(fixedX, randomY);

        GameObject obj = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);

        // ũ��, �±� ���� �� �߰�
        obj.transform.localScale = new Vector3(30f, 30f, 1f);
        obj.tag = spawnTag; // �ν����Ϳ��� ������ �±� ���

        // �ð� ������ �ڵ� ����
        Destroy(obj, lifetime);
    }
    void Start()
    {
            // ���� �� ���� �ð����� SpawnObject() ����
            InvokeRepeating(nameof(SpawnObject), 0f, spawnInterval);
    }
}
