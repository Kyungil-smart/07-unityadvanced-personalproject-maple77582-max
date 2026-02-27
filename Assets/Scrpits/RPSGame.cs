using UnityEngine;
using UnityEngine.InputSystem;

public class RockPaperScissors : MonoBehaviour
{
    enum Hand
    { 
        None, //0 
        Scissors, //1 1번 input 받으면 Hand 열거형에서 1번 고른거로 판정
        Rock, //2 2번 input 받으면 Hand 열거형에서 2번 고른거로 판정
        Paper //3 3번 input 받으면 Hand 열거형에서 3번 고른거로 판정
    }

    Hand playerHand = Hand.None; // playerHand 변수 선언과 동시에 이후에 다시 가위바위보를 할 때 값을 초기화 해주는 역할

    public void Press1(InputAction.CallbackContext context)
    {
        if(!context.performed)   return;
        Debug.Log("Press1 called");
        Play(Hand.Rock);
    }
    public void Press2(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Debug.Log("Press2 called");
        Play(Hand.Scissors);
    }
    public void Press3(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        Debug.Log("Press3 called");
        Play(Hand.Paper);
    }

    private void Play(Hand player)
    {
        //if (playerHand != Hand.None) return;

        playerHand = player;
        Hand aiHand = (Hand)Random.Range(1, 4); // ai는 Hand 열거형에서 Random.Range로 1이상 4미만의 숫자를 랜덤으로 뽑아서 aiHand 변수에 저장

        Debug.Log($"Player: {playerHand}, AI: {aiHand}"); //플레이어와 ai가 낸 손을 로그로 출력
        Debug.Log(Result(playerHand, aiHand)); // 플레이어와 ai가 낸 손을 Result 함수에 넘겨서 결과를 로그로 출력
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