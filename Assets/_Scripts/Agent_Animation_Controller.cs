using UnityEngine;
using UnityEngine.AI;
public class Agent_Animation_Controller : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Animator animator;

    void LateUpdate()
    {
        GetCurrentSpeed();

    }

    //get current navmesh agent speed and adjust animation
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
