using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private string QuizLink = "https://google.com";
    [SerializeField] private GameObject MenuButton;
    [SerializeField] private GameObject CreditsLayout;
    [SerializeField] private GameObject ProfilLayout;

    // Start is called before the first frame update
    void Start()
    {
        GotoMenuLayout();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GotoProfilLayout()
    {
        ShowMainMenu(false);
        ShowProfil(true);
    }

    public void GoToCreditsLayout()
    {
        ShowMainMenu(false);
        ShowCredits(true);
    }

    public void GotoMenuLayout()
    {
        ShowMainMenu(true);
        ShowCredits(false);
        ShowProfil(false);
    }

    public void GoToARScene()
    {
        SceneManager.LoadScene("ARScene");
    }
    public void GoToTeoriScene()
    {
        SceneManager.LoadScene("TeoriScene");
    }

    public void GoToQuizScene()
    {
        Application.OpenURL(QuizLink);
    }

    public void ShowMainMenu(bool value)
    {
        MenuButton.SetActive(value);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void ShowCredits(bool value)
    {
        CreditsLayout.SetActive(value);
    }
    private void ShowProfil(bool value)
    {
        ProfilLayout.SetActive(value);
    }
}
