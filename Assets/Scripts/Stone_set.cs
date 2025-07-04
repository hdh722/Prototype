using UnityEngine;
using System.Collections;

public class Stone_set : MonoBehaviour
{
    public GameObject objectToSpawn; // 소환할 프리팹
    public float fixedX = 711f;      // 고정 X 위치
    public float fixedZ = -0.1f;      // 고정 z 위치
    public string spawnTag = "Small_Stone"; // 소환되는 오브젝트의 태그

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            float waitTime = Random.Range(2.5f, 5f);
            yield return new WaitForSeconds(waitTime);

            // y값을 49~255 사이에서 랜덤으로 설정
            float randomY = Random.Range(49f, 255f);
            Vector2 spawnPos = new Vector2(fixedX, randomY);

            GameObject obj = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
            obj.tag = spawnTag;
            obj.transform.localScale = new Vector3(10f, 10f, 1f);
        }
    }

    void Update()
    {

    }
}
