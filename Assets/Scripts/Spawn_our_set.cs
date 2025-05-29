using UnityEngine;

public class Spawn_our_set : MonoBehaviour
{
    public GameObject objectToSpawn;      // ��ȯ�� ������
    public BoxCollider2D spawnArea;       // ���� ���� ����
    public float spawnInterval = 3f;      // ��ȯ �ֱ�
    public float lifetime = 5f;           // ��ȯ �� ���� �ð�
    public float fixedX = 111f;           // ���� X ��ġ
    public float fixedY = 0f;             // ���� Y ��ġ
    public float Attack = 1f;
    public float health = 1f;
    [Tooltip("��ȯ�Ǵ� ������Ʈ�� �±׸� �����ϼ���.")]
    public string spawnTag = "Team_our";  // �ν����Ϳ��� ������ �±�

    public int upgradeScore = 0; // Upgrade ���� �߰�

    void SpawnObject()
    {
        int spawnCount = 1;
        if (upgradeScore == 1)
            spawnCount = 2;
        else if (upgradeScore == 2)
            spawnCount = 3;

        for (int i = 0; i < spawnCount; i++)
        {
            float y = fixedY + 36.5f * i;
            Vector2 spawnPos = new Vector2(fixedX, y);

            GameObject obj = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
            obj.transform.localScale = new Vector3(30f, 30f, 1f);
            obj.tag = spawnTag;
            Destroy(obj, lifetime);
        }
    }

    void Start()
    {
        // ���� �� ���� �ð����� SpawnObject() ����
        InvokeRepeating(nameof(SpawnObject), 0f, spawnInterval);
    }
}
