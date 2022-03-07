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

    public void Start()
    {
        int d = Random.Range(0, Spawn_Manager.AUTO_DESTINATION_POINT.Count);//Get random node from array
        nextDest = Spawn_Manager.AUTO_DESTINATION_POINT[d].transform.position;//Set destination location
        navMeshAuto.SetDestination(nextDest);//Move to destination
        line = GetComponent<LineRenderer>(); //get the line renderer
        navMeshAuto = GetComponent<NavMeshAgent>(); //get the agent


    }
    public void Update()
    {
        FindDirection(transform.position, nextDest);//Pass current position and next destination

        if (GameData.displayPath)
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



    public void FindDirection(Vector3 unitPos, Vector3 goalPos)//Find destination quadrant relative to unit
    {
        direction = (goalPos - unitPos);//.normalized//Find destination quadrant relative to unit

        if (direction.x < 0 && direction.z < 0)//Quadrant III
        {
            navMeshAuto.agentTypeID = 1018083246; //SouthBound Auto
        }
        else
        if (direction.x > 0 && direction.z > 0)//Quadrant I
        {
            navMeshAuto.agentTypeID = 1135425739;//NorthBound
        }
        else
        if (direction.x < 0 && direction.z > 0)//Quadrant II
        {
            navMeshAuto.agentTypeID = -256249072;//WestBound
        }
        else
        if (direction.x > 0 && direction.z < 0)//Quadrant IV
        {
            navMeshAuto.agentTypeID = -562324683;//EastBoundAuto

        }

        // float dir = transform.eulerAngles.y;
        // if (dir < 0)
        // {
        //     dir += 360;
        // }
        // if (dir > 315 && dir < 45)
        // {
        //     navMeshAuto.agentTypeID = 1135425739;//NorthBound
        // }
        // if (dir > 45 && dir < 135)
        // {
        //     navMeshAuto.agentTypeID = -562324683;//EastBoundAuto
        // }
        // if (dir > 135 && dir < 225)
        // {
        //     navMeshAuto.agentTypeID = 1018083246; //SouthBound Auto
        // }
        // if (dir > 225 && dir < 315)
        // {
        //     navMeshAuto.agentTypeID = -256249072;//WestBound
        // }



        if (navMeshAuto.remainingDistance < destinationSensitivity)//If unit is within range of destination
        {

            int d = Random.Range(0, Spawn_Manager.AUTO_DESTINATION_POINT.Count);//Get random node from array
            nextDest = Spawn_Manager.AUTO_DESTINATION_POINT[d].transform.position;//Set destination location
            navMeshAuto.SetDestination(nextDest);//Move to destination
            if (navMeshAuto.velocity != Vector3.zero)//If auto unit is moving
            {
                transform.rotation = Quaternion.LookRotation(navMeshAuto.velocity.normalized);//Roatate auto unit

            }



        }


    }
    public void ChangeDirection()
    {
        navMeshAuto.agentTypeID = 1229499183; //All Auto Nav
    }
}