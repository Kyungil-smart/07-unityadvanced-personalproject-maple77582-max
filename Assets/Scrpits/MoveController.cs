using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveController : MonoBehaviour
{
    public Transform player;
    public Transform ai;

    public Transform playerGoal;
    public Transform aiGoal;

    public void PlayerAttackSuccess()
    {
        player.position += new Vector3(0, 0, 6f);
        ai.position += new Vector3(0, 0, 6f);

        CheckGoal();
    }

    public void AIAttackSuccess()
    {
        player.position -= new Vector3(0, 0, 6f);
        ai.position -= new Vector3(0, 0, 6f);

        CheckGoal();
    }

    void CheckGoal()
    {
        float playerGoalDistance = Vector3.Distance(player.position, playerGoal.position); //플레이어의 골까지의 거리
        float aiGoalDistance = Vector3.Distance(ai.position, aiGoal.position); //Ai의 골까지의 거리

        Debug.Log($"Player goal distance : {playerGoalDistance}");
        Debug.Log($"AI goal distance : {aiGoalDistance}");

        if (playerGoalDistance <= 0.1f)
        {
            Debug.Log("Player Win!");
            SceneManager.LoadScene("PlayerWin");
        }

        if(aiGoalDistance <= 0.1f)
        {
            Debug.Log("AI Win...");
            SceneManager.LoadScene("AiWin");
        }
    }
}
