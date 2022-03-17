using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class Agent_Navmesh_Controller : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public LineRenderer line;

    public List<GameObject> DOOR_NAV_POINT_LIST = new List<GameObject>();

    private void Start()
    {
        GetRandomDestination();
        DOOR_NAV_POINT_LIST.AddRange(GameObject.FindGameObjectsWithTag("Building:Door"));//Each door is a game map destination
        line = GameObject.FindGameObjectWithTag("Util:LineRenderer").GetComponent<LineRenderer>();
        int d = Random.Range(0, DOOR_NAV_POINT_LIST.Count);//get random destination
        navMeshAgent.SetDestination(DOOR_NAV_POINT_LIST[d].transform.position);//move unit to next destination
    }


    public void GetRandomDestination()
    {



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

        if (GameData.agentDisplayPath)
        {
            getPath();
        }
        else
        {
            line.SetVertexCount(1);
        }
    }
    public void getPath()
    {
        line.SetPosition(0, transform.position); //set the line's origin
        DrawPath(navMeshAgent.path);
    }

    public void DrawPath(NavMeshPath path)
    {
        if (path.corners.Length < 2) //if the path has 1 or no corners, there is no need
            return;
        line.SetVertexCount(path.corners.Length); //set the array of positions to the amount of corners

        for (var i = 1; i < path.corners.Length; i++)
        {
            line.SetPosition(i, path.corners[i]); //go through each corner and set that to the line renderer's position
        }
    }
}

