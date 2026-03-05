using UnityEngine;
using UnityEngine.InputSystem;

public class RockPaperScissors : MonoBehaviour
{
    void Start()
    { 
        battleSystem = GetComponent<BattleSystem>();
    }
    bool isGameActive = false;
    enum Hand
    { 
        None, //0 
        Scissors, //1 1번 input 받으면 Hand 열거형에서 1번 고른거로 판정
        Rock, //2 2번 input 받으면 Hand 열거형에서 2번 고른거로 판정
        Paper //3 3번 input 받으면 Hand 열거형에서 3번 고른거로 판정
    }

    Hand playerHand = Hand.None; // playerHand 변수 선언과 동시에 이후에 다시 가위바위보를 할 때 값을 초기화 해주는 역할
    BattleSystem battleSystem;

    public void PressEnter(InputAction.CallbackContext context)
    {
        if (!context.performed) return;// context.performed가 false면 함수 종료, 버튼이 정확히 눌렸을 때 한 번만 실행되도록 하는 역할
        isGameActive = true;// 게임이 활성화 됐다는 것을 나타내는 변수 isGameActive를 true로 설정
        Debug.Log("가위바위보 게임 시작!");
    }

    public void Press1(InputAction.CallbackContext context)
    {
        if(!context.performed)   return;
        if(!isGameActive) return;
        Debug.Log("가위!");
        Play(Hand.Scissors);
    }
    public void Press2(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (!isGameActive) return;
        Debug.Log("바위!");
        Play(Hand.Rock);
    }
    public void Press3(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (!isGameActive) return;
        Debug.Log("보!");
        Play(Hand.Paper);
    }

    private void Play(Hand player)
    {
        //if (playerHand != Hand.None) return;

        playerHand = player;
        Hand aiHand = (Hand)Random.Range(1, 4); // ai는 Hand 열거형에서 Random.Range로 1이상 4미만의 숫자를 랜덤으로 뽑아서 aiHand 변수에 저장

        Debug.Log($"Player: {playerHand}, AI: {aiHand}"); //플레이어와 ai가 낸 손을 로그로 출력

        string result = Result(playerHand, aiHand); // 플레이어와 ai가 낸 손을 Result 함수에 넘겨서 결과를 result 변수에 저장

        Debug.Log(result); // result를 로그로 출력

        isGameActive = false; // 게임이 끝났다는 것을 나타내는 변수 isGameActive를 false로 설정

        battleSystem.StartBattlePhase(result); // battleSystem의 StartBattlePhase 함수를 호출하면서 result를 인자로 넘겨서 배틀 시스템에서 결과에 따른 행동을 처리하도록 함
    }

    string Result(Hand p, Hand a)
    {
        if (p == a) 
        { 
            return "Draw"; //플레이어와 ai가 낸 손이 같을 때 무승부
        }

        if ((p == Hand.Scissors && a == Hand.Paper) || //플레이어가 가위를 냈는데 ai가 보를 냈을 때, or
            (p == Hand.Rock && a == Hand.Scissors) || //플레이어가 바위를 냈는데 ai가 가위를 냈을 때, or
            (p == Hand.Paper && a == Hand.Rock)) //플레이어가 보를 냈는데 ai가 바위를 냈을 때,
        {
            return "Player Win"; //위의 경우들이면 플레이어가 승리
        }
        return "AI Win"; //위의 경우들을 제외한 나머지는 ai가 승리로 처리
    }
}