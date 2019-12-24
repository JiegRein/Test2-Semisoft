using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayFab_Login : MonoBehaviour
{
    private string customId;
    public Text text_CustomId;
    public Button button_Login;
    public Text text_LoginError;
    public void Start()
    {
        text_LoginError.enabled = false;
    }

    public void OnLoginClick()
    {
        customId = text_CustomId.text;
        var request = new LoginWithCustomIDRequest { CustomId = customId, CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        text_LoginError.text = "";
        text_LoginError.enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Congratulations, you made your first successful API call!");
    }

    private void OnLoginFailure(PlayFabError error)
    {
        if (text_CustomId.text.Length == 0 || text_CustomId.text.Trim().Length == 0)
        {
            text_LoginError.text = "Custom ID Cannot be empty";
        }
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }
}