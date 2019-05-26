using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject MainMenuPanel;

    [SerializeField]
    private GameObject LevelSelectPanel;

    [SerializeField]
    private GameObject LevelButtonPrefab;

    [SerializeField]
    private RectTransform LevelSelectButtonsParent;

    static MenuManager _instance;
    public static MenuManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }


    private void Start()
    {
        MainMenuPanel.SetActive(true);
        LevelSelectPanel.SetActive(false);

        SetupLevelSelectPanel();
    }

    public void PlayGame()
    {
        AudioManager.Instance.PlaySound("Click");

        MainMenuPanel.SetActive(false);
        LevelSelectPanel.SetActive(true);
    }

    public void OnButtonHover()
    {
        AudioManager.Instance.PlaySound("Hover");
    }

    public void QuitGame()
    {
        AudioManager.Instance.PlaySound("Click");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void LoadLevel(int levelIndex)
    {
        AudioManager.Instance.PlaySound("Click");

        SceneManager.LoadScene(levelIndex);
    }

    void SetupLevelSelectPanel()
    {
        for (int i = 0; i < GameManager.Instance.Levels.Length; i++)
        {
            Level level = GameManager.Instance.Levels[i];
            GameObject o = Instantiate(LevelButtonPrefab, LevelSelectButtonsParent);
            o.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = level.Name;
            o.GetComponentInChildren<LevelButton>().LevelIndex = i;
        }
    }

    public void BackToMainMenu()
    {
        MainMenuPanel.SetActive(true);
        LevelSelectPanel.SetActive(false);
    }
}
