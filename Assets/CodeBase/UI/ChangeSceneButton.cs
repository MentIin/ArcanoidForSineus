using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    [SerializeField] private string Scene;

    private void Awake()
    {
        _button.onClick.AddListener(Load);
    }

    private void Load()
    {
        SceneManager.LoadScene(Scene);
    }
}
