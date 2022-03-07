using UnityEngine;
using UnityEngine.AI;


//Not currently used
public class Auto_Animation_Controller : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    [Range(1, 5)]
    public float velosity;


    // void Update()
    // {
    //     GetCurrentSpeed();
    //     animator.SetFloat("Velosity", navMeshAgent.speed);
    // }

    // private void GetCurrentSpeed()
    // {
    //     if (navMeshAgent.speed > .25)
    //     {
    //         animator.SetBool("isMoving", true);
    //     }
    // }
}
