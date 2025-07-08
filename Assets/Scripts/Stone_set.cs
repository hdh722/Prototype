using UnityEngine;
using System.Collections;

public class Stone_set : MonoBehaviour
{
    public GameObject objectToSpawn; // ��ȯ�� ������
    public float fixedX = 711f;      // ���� X ��ġ
    public float fixedZ = -0.1f;      // ���� z ��ġ
    public string spawnTag = "Small_Stone"; // ��ȯ�Ǵ� ������Ʈ�� �±�

    // ����� Y�� �迭
    private readonly float[] yPositions = { 334.3f, 279.3f, 226.3f, 170.5f, 115.5f };

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

            // 5�� �� �������� y�� ����
            float randomY = yPositions[Random.Range(0, yPositions.Length)];
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
