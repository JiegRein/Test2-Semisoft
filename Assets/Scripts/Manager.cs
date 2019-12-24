using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject mainCamera;
    public void OpenShopMenu()
    {
        menuCanvas.SetActive(false);
        mainCamera.SetActive(false);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
    }

    public void CloseShopMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
