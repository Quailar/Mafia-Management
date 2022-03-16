using UnityEngine;
using UnityEngine.AI;
public class Agent_Animation_Controller : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    [Range(1, 3)]
    public float velosity;

    void Update()
    {
        GetCurrentSpeed();

    }

    private void GetCurrentSpeed()
    {
        if (navMeshAgent.speed < .25)
        {
            animator.SetBool("isIdle", true);
        }
        else if (navMeshAgent.speed < 2.5)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isRunning", true);
        }
        animator.SetFloat("Velosity", navMeshAgent.speed);
    }


}
