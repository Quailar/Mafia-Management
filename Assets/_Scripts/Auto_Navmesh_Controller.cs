using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class Auto_Navmesh_Controller : MonoBehaviour
{
    public NavMeshSurface AutoSurfaceBake;
    public NavMeshAgent navMeshAuto;
    public LineRenderer line;
    public Vector3 nextDest;
    public Vector3 direction;
    public float destinationSensitivity;
    public bool autoDisplayPath = true;
    public List<Vector3> nodes;
    public int minRange;
    public int maxRange;
    Vector3 c;
    Vector3 d;

    public List<GameObject> EnterNodes = new List<GameObject>();
    public List<GameObject> ExitNodes = new List<GameObject>();


    private void Awake()
    {
        EnterNodes.AddRange(GameObject.FindGameObjectsWithTag("TAG:NavigationIntersectionNode_Enter"));
        ExitNodes.AddRange(GameObject.FindGameObjectsWithTag("TAG:NavigationIntersectionNode_Exit"));
        line = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<LineRenderer>(); //get the line renderer
        navMeshAuto = GetComponent<NavMeshAgent>(); //get the agent
        AutoSurfaceBake.BuildNavMesh();
    }


    public void Start()
    {

        int d = Random.Range(0, EnterNodes.Count);
        nextDest = EnterNodes[d].transform.position;//Set destination location
        navMeshAuto.SetDestination(nextDest);//Move to destination


        for (int i = 0; i < EnterNodes.Count; i++)
        {
            nodes.Add(EnterNodes[i].transform.position);
        }
    }

    public void FixedUpdate()
    {

        if (autoDisplayPath)
        {
            getPath();
        }
        else
        {
            line.SetVertexCount(0);
        }



        for (int i = 0; i < navMeshAuto.path.corners.Length; i++)
        {
            print("Each Corner: " + navMeshAuto.path.corners[i]);
        }
        print("Path Next Position: " + navMeshAuto.nextPosition);
        print("Path EndPosition: " + navMeshAuto.pathEndPosition);
        print("Path Steering Target: " + navMeshAuto.steeringTarget);
        print("Velocity: " + navMeshAuto.velocity);
        //print("Path Status: " + navMeshAuto.path.status);
        //SetPath([NotNullAttribute("ArgumentNullException")] NavMeshPath path);
        // print("Velocity: " + navMeshAuto.Move(Vector3 offset));
        //print("Raycast: " + navMeshAuto.Raycast(Vector3 targetPosition, out NavMeshHit hit));
        // print("Path HasPath: " + navMeshAuto.hasPath);

    }

    public void getPath()
    {
        line.SetPosition(0, transform.position);
        DrawPath(navMeshAuto.path);
    }

    public void DrawPath(NavMeshPath path)
    {
        if (path.corners.Length < 2)
            return;
        line.SetVertexCount(path.corners.Length);

        for (var i = 0; i < path.corners.Length; i++)
        {
            line.SetPosition(i, path.corners[i]);
        }
    }

    public void GetSteering()
    {
        direction = navMeshAuto.steeringTarget;
    }

    public void FindClosestNode()
    {
        for (int a = 0; a < EnterNodes.Count; a++)
        {
            Vector3 c = EnterNodes[a].transform.position;
            for (int b = 0; b < ExitNodes.Count; b++)
            {
                Vector3 d = ExitNodes[b].transform.position;
                float distanceLength = (c - d).magnitude;
                if (distanceLength > minRange && distanceLength < maxRange)
                {
                    //find closest nodes
                }
            }
        }
    }

    void SetNextDestination()
    {
        if (navMeshAuto.remainingDistance < destinationSensitivity)
        {
            int d = Random.Range(0, EnterNodes.Count);
            nextDest = EnterNodes[d].transform.position;//Set destination location
            navMeshAuto.SetDestination(nextDest);//Move to destination
            if (navMeshAuto.velocity != Vector3.zero)
            {
                navMeshAuto.ResetPath();
                transform.rotation = Quaternion.LookRotation(navMeshAuto.velocity.normalized);

            }

        }
    }
}