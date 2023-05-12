using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private int sceneBuildIndexToChangeInto;
    [SerializeField] private bool exit;
    [SerializeField] private Image loadingBar;
    [SerializeField] private GameObject loadingBarContainer;
    public void LoadScene()
    {
        StartCoroutine(LoadSceneAsync(sceneBuildIndexToChangeInto));
    }
    IEnumerator LoadSceneAsync(int sceneIndex)
    {
        if (exit)
        {
            Application.Quit();
            Debug.Log("Wyjœcie z gry");
            yield return null;
        }

        loadingBarContainer.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            float progressVal = Mathf.Clamp01(operation.progress / 0.9f);
            loadingBar.fillAmount = progressVal;

            yield return null;
        }
        
    }
}
