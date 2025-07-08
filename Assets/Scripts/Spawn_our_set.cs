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

    public GameObject Board_Defence; // 인스펙터에서 할당

    [SerializeField]private float specialYCooldown = 3.0f; // 쿨타임(초)
    private float lastSpecialYTime = -999f; // 마지막 실행 시각

    void SpawnObject()
    {
        float[] yPositions = { 334.3f, 279.3f, 226.3f, 170.5f, 115.5f };

        int spawnCount = 1; // 필요시 spawnCount를 조정하세요

        for (int i = 0; i < spawnCount; i++)
        {
            float y = yPositions[Random.Range(0, yPositions.Length)];
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

            var spriteRenderer = obj.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.color = Color.cyan;
            }
        }
    }

    void Start()
    {
        // 일정 시간마다 SpawnObject를 자동으로 호출
        InvokeRepeating(nameof(SpawnObject), 3f, spawnInterval);
    }

    void Update()
    {

        // 쿨타임이 0일 때만 스페이스바로 소환 및 쿨타임 설정
        //if (Mathf.Approximately(specialYCooldown, 0f) && Input.GetKeyDown(KeyCode.Space))
        //{
        //    specialYCooldown = 3f;
        //    SpawnObjectAtSpecialY();
        //    lastSpecialYTime = Time.time;
        //}

        // 쿨타임이 0.1 이상이면 1초에 1씩 감소
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