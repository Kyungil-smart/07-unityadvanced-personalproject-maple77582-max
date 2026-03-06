using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance;
    void Awake()
    {
        if (Instance == null) // 처음 게임을 시작할 때만 BGMManager 인스턴스를 생성
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // 그 외, 이미 BGMManager 인스턴스가 존재할 때는 새로 생성된 인스턴스를 파괴하여 중복 방지
        }
    }
}
