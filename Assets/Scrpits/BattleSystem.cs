using UnityEngine;
using UnityEngine.InputSystem;

public class BattleSystem : MonoBehaviour
{
    enum AttackType
    {
        High,
        Middle,
        Low
    }

    enum DefenseType
    {
        High,
        Middle,
        Low
    }

    bool canAttack = false;
    bool canDefense = false;

    public MoveController moveController;

    public void StartBattlePhase(string result)
    {
        if (result == "Player Win")
        {
            Debug.Log("Choose Attack");
            canAttack = true;
        }

        else if (result == "AI Win")
        {
            Debug.Log("Choose Defense");
            canDefense = true;
        }

        else
        {
            Debug.Log("It's a draw. Rock paper scissors again");
        }
    }

    public void PressQ(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (!canAttack) return;
        Debug.Log("High Attack!");
        Attack(AttackType.High);
    }

    public void PressW(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (!canAttack) return;
        Debug.Log("Middle Attack!");
        Attack(AttackType.Middle);
    }

    public void PressE(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (!canAttack) return;
        Debug.Log("Low Attack!");
        Attack(AttackType.Low);
    }

    private void Attack(AttackType playerAttack)
    {
        DefenseType aiDefense = (DefenseType)Random.Range(0, 3); //ai의 방어 타입을 랜덤으로 결정

        Debug.Log($"Player Attack : {playerAttack}");
        Debug.Log($"AI Defense : {aiDefense}");

        if ((int)playerAttack == (int)aiDefense)
        {
            Debug.Log("Attack Failed! AI succeeded in defending");//공격에 실패하였기 때문에 포지션 이동 없음
        }
        else
        {
            Debug.Log("Attack Success! AI failed to defend.");//공격에 성공하였기 때문에 포지션 이동 있음
            moveController.PlayerAttackSuccess();
        }

        canAttack = false; //공격이 끝나면 가위바위보에서 다시 이기기 전까지 canAttack을 false로 전환
    }

    public void PressA(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (!canDefense) return;
        Debug.Log("High Defense");
        Defense(DefenseType.High);
    }

    public void PressS(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (!canDefense) return;
        Debug.Log("Middle Defense");
        Defense(DefenseType.Middle);
    }

    public void PressD(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (!canDefense) return;
        Debug.Log("Low Defense");
        Defense(DefenseType.Low);
    }

    private void Defense(DefenseType playerDefense)
    {
        AttackType aiAttack = (AttackType)Random.Range(0, 3); //ai의 공격 타입을 랜덤으로 결정
        Debug.Log($"Player Defense : {playerDefense}");
        Debug.Log($"AI Attack : {aiAttack}");
        if ((int)playerDefense == (int)aiAttack)
        {
            Debug.Log("Defense Success! AI has failed to attack.");//플레리어가 방어에 성공하였기 때문에 포지션 이동 없음
        }
        else
        {
            Debug.Log("Failed to defend! AI succeeded in attack.");//플레이어가 방어에 실패하였기 때문에 포지션 이동 있음
            moveController.AIAttackSuccess();
        }
        canDefense = false; //방어가 끝나면 가위바위보에서 다시 지기 전까지 canDefense를 false로 전환
    }
}
