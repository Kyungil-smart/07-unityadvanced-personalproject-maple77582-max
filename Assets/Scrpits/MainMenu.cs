using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public RectTransform transitionImage;   // RawImage의 RectTransform
    public float duration = 2f;             // 이동 시간

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
