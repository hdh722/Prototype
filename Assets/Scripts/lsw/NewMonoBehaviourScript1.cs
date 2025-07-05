// SummonManager.cs
using UnityEngine;

public class SummonManager : MonoBehaviour
{
    public static SummonManager Instance;
    public GameObject unitPrefab; // º“»Ø«“ ¿Ø¥÷ «¡∏Æ∆’
    private bool isSummonMode = false;

    private void Awake()
    {
        Instance = this;
    }

    public void OnSummonButtonClick()
    {
        isSummonMode = true;
    }

    public void TrySummonAt(Vector3 position)
    {
        if (isSummonMode)
        {
            Instantiate(unitPrefab, position, Quaternion.identity);
            isSummonMode = false;
        }
    }

    public bool IsSummonMode()
    {
        return isSummonMode;
    }
}
