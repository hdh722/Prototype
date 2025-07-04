using UnityEngine;
using System.Collections;

public class Stone_set : MonoBehaviour
{
    public GameObject objectToSpawn; // ��ȯ�� ������
    public float fixedX = 711f;      // ���� X ��ġ
    public float fixedZ = -0.1f;      // ���� z ��ġ
    public string spawnTag = "Small_Stone"; // ��ȯ�Ǵ� ������Ʈ�� �±�

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

            // y���� 49~255 ���̿��� �������� ����
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
