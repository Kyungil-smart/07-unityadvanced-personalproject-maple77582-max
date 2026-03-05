using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class MainMenu : MonoBehaviour
{
    public void OnClickNewGame()
    {
        Debug.Log("새 게임");
        SceneManager.LoadScene("TetoCats");
    }

    public void OnClickSetting()
    {
        Debug.Log("설정");
    }

    public void OnCLickQuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
