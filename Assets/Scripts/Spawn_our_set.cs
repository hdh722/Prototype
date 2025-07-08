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

    public GameObject Board_Defence; // �ν����Ϳ��� �Ҵ�

    [SerializeField]private float specialYCooldown = 3.0f; // ��Ÿ��(��)
    private float lastSpecialYTime = -999f; // ������ ���� �ð�

    void SpawnObject()
    {
        float[] yPositions = { 334.3f, 279.3f, 226.3f, 170.5f, 115.5f };

        int spawnCount = 1; // �ʿ�� spawnCount�� �����ϼ���

        for (int i = 0; i < spawnCount; i++)
        {
            float y = yPositions[Random.Range(0, yPositions.Length)];
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

            var spriteRenderer = obj.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = Color.cyan;
            }
        }
    }

    void Start()
    {
        // ���� �ð����� SpawnObject�� �ڵ����� ȣ��
        InvokeRepeating(nameof(SpawnObject), 3f, spawnInterval);
    }

    void Update()
    {

        // ��Ÿ���� 0�� ���� �����̽��ٷ� ��ȯ �� ��Ÿ�� ����
        //if (Mathf.Approximately(specialYCooldown, 0f) && Input.GetKeyDown(KeyCode.Space))
        //{
        //    specialYCooldown = 3f;
        //    SpawnObjectAtSpecialY();
        //    lastSpecialYTime = Time.time;
        //}

        // ��Ÿ���� 0.1 �̻��̸� 1�ʿ� 1�� ����
        //if (specialYCooldown >= 0.1f)
        //{
        //    if (Time.time - lastSpecialYTime >= 1f)
        //    {
        //        specialYCooldown -= 1f;
        //        if (specialYCooldown < 0f)
        //            specialYCooldown = 0f;
        //        lastSpecialYTime = Time.time;
        //    }
        //}
    }
}