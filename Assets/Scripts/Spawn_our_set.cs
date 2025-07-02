using UnityEngine;

public class Spawn_our_set : MonoBehaviour
{
    public GameObject objectToSpawn;      // 소환할 프리팹
    public BoxCollider2D spawnArea;       // 스폰 범위 기준
    public float spawnInterval = 3f;      // 소환 주기
    public float fixedX = 111f;           // 고정 X 위치
    public float fixedY = 36.5f;          // 고정 Y 위치
    public float Attack = 1f;
    public float health = 1f;
    [Tooltip("소환되는 오브젝트의 태그를 지정하세요.")]
    public string spawnTag = "Team_our";  // 인스펙터에서 지정할 태그

    public int upgradeScore = 0; // Upgrade 점수 추가
    public GameObject Board_Defence; // 인스펙터에서 할당

    private float specialYCooldown = 3.0f; // 쿨타임(초)
    private float lastSpecialYTime = -999f; // 마지막 실행 시각

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
            obj.AddComponent<Move_our>(); // 이동 및 정지 스크립트 추가
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