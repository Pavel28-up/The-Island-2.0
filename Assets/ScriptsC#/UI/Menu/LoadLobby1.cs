using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadLobby1 : MonoBehaviour
{
    AsyncOperation asyncOperation;
    public Image loadBar;
    public Text barTxt;
    public int sceneId;

    private float progress;

    private void Start()
    {
        StartCoroutine(LoadSceneCorId());
    }

    private void Update()
    {
        barTxt.text = "Loading: " + progress * 100f + "%";
    }


    IEnumerator LoadSceneCorId()
    {
        yield return new WaitForSeconds(1f);
        asyncOperation = SceneManager.LoadSceneAsync(sceneId);
        while (!asyncOperation.isDone)
        {
            progress = asyncOperation.progress / 0.9f;
            loadBar.fillAmount = progress;
            barTxt.text = "Loading: " + progress * 100f + "%";
            yield return 0;
        }
    }
}
