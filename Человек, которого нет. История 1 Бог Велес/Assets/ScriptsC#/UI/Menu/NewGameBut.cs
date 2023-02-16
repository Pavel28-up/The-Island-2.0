using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGameBut : MonoBehaviour
{
    public string SceneNameLoad;
    public string NextScene;

    public void StrtGame()
    {
        PlayerPrefs.SetString("namePlayer", "");
        NextScene = "NewGame";
        PlayerPrefs.SetString("backScene", NextScene);
        NextScene = "NewPlayer";
        PlayerPrefs.SetString("nextScene", NextScene);
        SceneManager.LoadScene(SceneNameLoad);
    }
}
