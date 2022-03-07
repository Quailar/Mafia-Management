using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class Agent_Navmesh_Controller : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    public List<GameObject> DOOR_NAV_POINT_LIST = new List<GameObject>();

    private void Start()
    {
        DOOR_NAV_POINT_LIST.AddRange(GameObject.FindGameObjectsWithTag("DOOR_NAV_POINT"));//Each door is a game map destination
        int d = Random.Range(0, DOOR_NAV_POINT_LIST.Count);//get random destination
        navMeshAgent.SetDestination(DOOR_NAV_POINT_LIST[d].transform.position);//move unit to next destination
    }

    private void Update()
    {
        if (navMeshAgent.remainingDistance < .5)
        {
            if (navMeshAgent.velocity != Vector3.zero)//if unit is moving
            {
                transform.rotation = Quaternion.LookRotation(navMeshAgent.velocity.normalized);//rotate unit to destination
            }
            int d = Random.Range(0, DOOR_NAV_POINT_LIST.Count);//select new destintion
            navMeshAgent.SetDestination(DOOR_NAV_POINT_LIST[d].transform.position);//move agent
        }
    }
}

