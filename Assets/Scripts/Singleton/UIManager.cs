using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject InGameMenu;
    [SerializeField] GameObject SettingsMenu;
    [SerializeField] GameObject CreditsMenu;

    [SerializeField] string gameSceneName = "Game";

    private void Start()
    {
        SwitchToMainMenuUI();
    }

    public void SwitchToMainMenuUI()
    {
        DisableAllUI();

        MainMenu.SetActive(true);
        InGameMenu.SetActive(false);
    }

    public void SwitchToInGameMenuUI()
    {
        DisableAllUI();

        MainMenu.SetActive(false);
        InGameMenu.SetActive(true);
    }

    public void PlayBtn()
    {
        SwitchToInGameMenuUI();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitBtn()
    {
        SwitchToMainMenuUI();
        SceneManager.LoadScene(0);
    }

    public void SettingsBtn()
    {
        DisableAllUI();

        SettingsMenu.SetActive(true);
    }

    public void CreditsBtn()
    {
        DisableAllUI();

        CreditsMenu.SetActive(true);
    }

    private void DisableAllUI()
    {
        SettingsMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }
}