using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoadManager : MonoBehaviour
{
    [SerializeField] private Slider loadbar;
    [SerializeField] private GameObject loadPanel;

    public void Sceneload(int sceneindex)
    {
        loadPanel.SetActive(true);
        StartCoroutine(loadAsync(sceneindex));
    }
    IEnumerator loadAsync(int sceneindex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneindex);
        while (!operation.isDone)
        {
            loadbar.value = operation.progress/0.9f;
            yield return null;
        }
    }
}
