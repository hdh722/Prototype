using UnityEngine;

public class Spawn_our_set : MonoBehaviour
{
    public GameObject objectToSpawn;      // ��ȯ�� ������
    public BoxCollider2D spawnArea;       // ���� ���� ����
    public float spawnInterval = 3f;      // ��ȯ �ֱ�
    public float fixedX = 111f;           // ���� X ��ġ
    public float fixedY = 36.5f;          // ���� Y ��ġ
    public float Attack = 1f;
    public float health = 1f;
    [Tooltip("��ȯ�Ǵ� ������Ʈ�� �±׸� �����ϼ���.")]
    public string spawnTag = "Team_our";  // �ν����Ϳ��� ������ �±�

    public int upgradeScore = 0; // Upgrade ���� �߰�
    public GameObject Board_Defence; // �ν����Ϳ��� �Ҵ�

    private float specialYCooldown = 3.0f; // ��Ÿ��(��)
    private float lastSpecialYTime = -999f; // ������ ���� �ð�

    void SpawnObject()
    {
        int spawnCount = 1;
        if (upgradeScore == 1)
            spawnCount = 2;
        else if (upgradeScore == 2)
            spawnCount = 3;
        else if (upgradeScore == 3)
            spawnCount = 4;

        for (int i = 0; i < spawnCount; i++)
        {
            float y = fixedY + 73.0f * i;
            Vector2 spawnPos = new Vector2(fixedX, y);

            GameObject obj = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
            obj.transform.localScale = new Vector3(30f, 30f, 1f);
            obj.tag = spawnTag;
            obj.AddComponent<Move_our>(); // �̵� �� ���� ��ũ��Ʈ �߰�
        }
    }

    void SpawnObjectAtSpecialY()
    {
        int spawnCount = 1;

        for (int i = 0; i < spawnCount; i++)
        {
            float y = (fixedY);
            Vector2 spawnPos = new Vector2(fixedX, y);

            GameObject obj = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
            obj.transform.localScale = new Vector3(30f, 30f, 1f);
            obj.tag = spawnTag;
            var moveOur = obj.AddComponent<Move_our>();
            moveOur.attack = 2f;
            moveOur.health = 25f;
            moveOur.attackSpeed = 1.0f;

            var spriteRenderer = obj.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = Color.cyan;
            }
        }
    }

    void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 0f, spawnInterval);
    }

    void Update()
    {
        if (Board_Defence != null)
        {
            fixedY = Board_Defence.transform.position.y;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastSpecialYTime >= specialYCooldown)
            {
                SpawnObjectAtSpecialY();
                lastSpecialYTime = Time.time;
            }
        }
    }
}