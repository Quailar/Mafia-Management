using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;


// if (navMeshAuto.velocity != Vector3.zero)
// {
//     transform.rotation = Quaternion.LookRotation(navMeshAuto.velocity.normalized);

// SetPath([NotNullAttribute("ArgumentNullException")] NavMeshPath path);

// }
// for (int i = 0; i < navMeshAuto.path.corners.Length; i++)
// {
//     print("Each Corner: " + navMeshAuto.path.corners[i]);
// }



// print("Path Next Position: " + navMeshAuto.nextPosition);
// print("Path EndPosition: " + navMeshAuto.pathEndPosition);
// print("Path Steering Target: " + navMeshAuto.steeringTarget);
// print("Velocity: " + navMeshAuto.velocity);
// print("Path Status: " + navMeshAuto.path.status);
// print("Velocity: " + navMeshAuto.Move(Vector3 offset));
// print("Raycast: " + navMeshAuto.Raycast(Vector3 targetPosition, out NavMeshHit hit));
// print("Path Remaining: " + navMeshAuto.remainingDistance);
// print("Path HasPath: " + navMeshAuto.hasPath);
// line.positionCount = path.corners.Length;
// direction = navMeshAuto.steeringTarget;



public class Auto_Navmesh_Controller : MonoBehaviour
{
    public NavMeshSurface AutoSurfaceBake;
    public NavMeshAgent navMeshAuto;
    public LineRenderer line;
    public Vector3 nextDest;
    public Vector3 direction;
    public float destinationSensitivity;
    public bool autoDisplayPath = true;
    public GameObject autoCurrentNode;
    public int closeRange;



    Vector3 c;
    Vector3 d;

    public List<GameObject> EnterNodes = new List<GameObject>();
    public List<GameObject> ExitNodes = new List<GameObject>();


    private void Awake()
    {
        EnterNodes.AddRange(GameObject.FindGameObjectsWithTag("TAG:NavigationIntersectionNode_Enter"));
        ExitNodes.AddRange(GameObject.FindGameObjectsWithTag("TAG:NavigationIntersectionNode_Exit"));
        //line = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LineRenderer>(); //get the line renderer
        navMeshAuto = GetComponent<NavMeshAgent>(); //get the agent
        AutoSurfaceBake.BuildNavMesh();
    }

    public void Start()
    {
        SetNextDestination();
    }

    public void FixedUpdate()
    {
        if (autoDisplayPath)
        {
            showPath();
        }
        else
        {
            line.positionCount = 1;
        }
        if (navMeshAuto.path.corners.Length <= destinationSensitivity)
        {
            SetNextDestination();

        }
        if (navMeshAuto.velocity.z > 1)
        {
            print("Youve Reached Max Velocity: " + navMeshAuto.velocity);
        }
    }

    public void showPath()
    {
        line.SetPosition(0, transform.position);
        DrawPath(navMeshAuto.path);
    }

    public void DrawPath(NavMeshPath path)
    {
        if (path.corners.Length < 2)
            return;
        for (int i = 0; i < path.corners.Length; i++)
        {

            line.SetVertexCount(path.corners.Length);
            line.SetPositions(path.corners);
            print("Path Corners: " + line.GetPositions(path.corners));
        }
    }

    void SetNextDestination()
    {
        direction = navMeshAuto.steeringTarget;
        int a = Random.Range(0, EnterNodes.Count);
        nextDest = EnterNodes[a].transform.position;
        float distanceLength = (nextDest - transform.position).magnitude;
        navMeshAuto.SetDestination(nextDest);//Move to destination
    }
}