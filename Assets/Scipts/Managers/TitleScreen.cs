using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] int sceneIndex = 1;

    public void StartNewGame()
    {
        StartCoroutine(LoadGame());
    }

    public IEnumerator LoadGame()
    {
        AsyncOperation loadingScene = SceneManager.LoadSceneAsync(sceneIndex);

        yield return null;
    }

    public void Credits()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}
