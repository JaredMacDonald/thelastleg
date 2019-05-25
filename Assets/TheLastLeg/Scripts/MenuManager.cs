using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private AudioManager audioManager;
    
    public void PlayGame()
    {
        audioManager.PlaySound("Click");

        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void OnButtonHover()
    {
        audioManager.PlaySound("Hover");
    }

    public void QuitGame()
    {
        audioManager.PlaySound("Click");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
