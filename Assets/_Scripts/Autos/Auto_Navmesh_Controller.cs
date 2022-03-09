using UnityEngine;
using UnityEngine.AI;

//     navMeshAuto.agentTypeID = 1135425739;//NorthBound Auto
//     navMeshAuto.agentTypeID = -562324683;//EastBound Auto
//     navMeshAuto.agentTypeID = 1018083246; //SouthBound Auto
//     navMeshAuto.agentTypeID = -256249072;//WestBound Auto
public class Auto_Navmesh_Controller : MonoBehaviour
{
    public NavMeshAgent navMeshAuto;
    public LineRenderer line;
    public Vector3 nextDest;
    public Vector3 direction;
    public float destinationSensitivity;
    public Vector3 distanceFromCorner;

    public void Start()
    {

        line = GetComponent<LineRenderer>(); //get the line renderer
        navMeshAuto = GetComponent<NavMeshAgent>(); //get the agent


    }
    public void FixedUpdate()
    {
        FindDirection(transform.position, nextDest);//Pass current position and next destination

        if (GameData.autoDisplayPath)
        {
            getPath();
        }
        else
        {
            line.SetVertexCount(1);
        }
        if (!navMeshAuto.isOnNavMesh)
        {
            Destroy(this.gameObject);
        }

        if (navMeshAuto.pathStatus == NavMeshPathStatus.PathPartial || navMeshAuto.isStopped)
        {
            navMeshAuto.ResetPath();
        }
    }



    public void getPath()
    {
        line.SetPosition(0, transform.position); //set the line's origin
        DrawPath(navMeshAuto.path);
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

    public void FindDirection(Vector3 unitPos, Vector3 goalPos)
    {
        direction = (goalPos - unitPos);//.normalized//Find destination quadrant relative to unit
        if (direction.x > 0 && direction.z > 0)//Quadrant I
        {
            navMeshAuto.agentTypeID = 1135425739;//NorthBound
        }
        if (direction.x < 0 && direction.z < 0)//Quadrant III
        {
            navMeshAuto.agentTypeID = 1018083246; //SouthBound Auto
        }
        if (direction.x < 0 && direction.z > 0)//Quadrant II
        {
            navMeshAuto.agentTypeID = -256249072;//WestBound
        }
        if (direction.x > 0 && direction.z < 0)//Quadrant IV
        {
            navMeshAuto.agentTypeID = -562324683;//EastBoundAuto
        }



        if (navMeshAuto.remainingDistance < destinationSensitivity)//If unit is within range of destination
        {
            int d = Random.Range(0, Spawn_Manager.AUTO_DESTINATION_POINT.Count);//Get random node from array
            nextDest = Spawn_Manager.AUTO_DESTINATION_POINT[d].transform.position;//Set destination location
            navMeshAuto.SetDestination(nextDest);//Move to destination
            if (navMeshAuto.velocity != Vector3.zero)//If auto unit is moving
            {
                navMeshAuto.ResetPath();
                transform.rotation = Quaternion.LookRotation(navMeshAuto.velocity.normalized);//Roatate auto unit

            }

        }
    }

}