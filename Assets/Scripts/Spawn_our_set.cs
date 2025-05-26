using UnityEngine;

public class Spawn_our_set : MonoBehaviour
{
    public GameObject objectToSpawn;      // 소환할 프리팹
    public BoxCollider2D spawnArea;       // 스폰 범위 기준
    public float spawnInterval = 3f;      // 소환 주기
    public float lifetime = 5f;           // 소환 후 유지 시간
    public float fixedX = 0f;             // 고정 X 위치 (또는 랜덤도 가능)

    void SpawnObject()
    {
        Bounds bounds = spawnArea.bounds;

        float minY = bounds.min.y;
        float maxY = bounds.max.y;
        float randomY = Random.Range(minY, maxY);
        Vector2 spawnPos = new Vector2(fixedX, randomY);

        GameObject obj = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);

        // 크기, 태그 설정 등 추가
        obj.transform.localScale = new Vector3(30f, 30f, 1f);
        obj.tag = "Team_our";

        // 시간 지나면 자동 삭제
        Destroy(obj, 5f);
    }
    void Start()
    {
            // 시작 후 일정 시간마다 SpawnObject() 실행
            InvokeRepeating(nameof(SpawnObject), 0f, spawnInterval);
    }
}
