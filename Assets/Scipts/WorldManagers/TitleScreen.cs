using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] public static TitleScreen Instance;

    [field:SerializeField] public int worldSceneIndex { get; private set; } = 1;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
    }

    public void StartNewGame()
    {
        StartCoroutine(LoadGame());
    }

    public IEnumerator LoadGame()
    {
        AsyncOperation loadingScene = SceneManager.LoadSceneAsync(worldSceneIndex);

        yield return null;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
