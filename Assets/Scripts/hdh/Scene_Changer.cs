using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene_Changer : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    public void ChangeToScene(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
    }
}
