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
        Debug.Log("HowToPlay");
        SceneManager.LoadScene("HowToPlay");
    }

    public void OnCLickQuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OnClickTitle()
    {
        Debug.Log("타이틀로 돌아갑니다");
        SceneManager.LoadScene("Title");
    }
}
