using UnityEngine;

public class GridCellcs : MonoBehaviour
{
    public GameObject cellPrefab;
    public int rows = 5;
    public int cols = 9;
    public float cellSize = 1.28f;  // 이미지 상 각 셀의 간격
    public Vector2 startPos = new Vector2(-5f, -2f);

    void Start()
    {
        for (int y = 0; y < rows; y++)
        {
            for (int x = 0; x < cols; x++)
            {
                Vector2 pos = startPos + new Vector2(x * cellSize, y * cellSize);
                GameObject cell = Instantiate(cellPrefab, pos, Quaternion.identity, transform);
                cell.name = $"Cell_{y}_{x}";
            }
        }
    }
}
