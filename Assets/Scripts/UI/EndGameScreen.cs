using System;
using UnityEngine.SceneManagement;

public class EndGameScreen : Window
{
    public event Action RestartButtonClicked;
     
    public override void Close()
    {
        WindowGroup.alpha = 0f;
        WindowGroup.blocksRaycasts = false;
        WindowGroup.interactable = false;
    }

    public override void Open()
    {
        WindowGroup.alpha = 1f;
        WindowGroup.blocksRaycasts = true;
        WindowGroup.interactable = true;
    }

    protected override void OnButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        RestartButtonClicked?.Invoke();
    }
}