using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Auto_NavNode_Controller : MonoBehaviour
{
    //Navmesh used for movement
    public NavMeshAgent navmeshAuto;
    public TrafficLightController trafficController;

    public GameObject currentnode;

    public GameObject nextNode;

    public List<GameObject> Neighbors;

    public bool isStopped;




    private void Start()
    {
        trafficController = GameObject.FindGameObjectWithTag("TrafficLight:Manager").GetComponent<TrafficLightController>();
    }

    public void OnTriggerEnter(Collider other)
    {



        // if (other.tag == "TrafficLightNorthSouth")
        // {
        //     if (trafficController.RedLightNorthSouth_ON)
        //     {
        //         print(other.tag);
        //     }
        // }


        // if (other.tag == "TrafficLightEastWest")
        // {
        //     if (trafficController.RedLightEastWest_ON)
        //     {
        //         print(other.tag);
        //     }

        // }

        if (other.tag == "Auto:NodeRed" || other.tag == "Auto:NodeBlue")
        {
            FindNextNode(other);
        }

        if (other.tag == "Auto:Spawn")
        {
            FindNextNode(other);
        }

        if (other.tag == "Auto:Despawn")
        {
            if (GameData.DecreaseAutos)//Despawn node
            {
                if (GameData.TotalAutos > GameData.MaxAutos)
                {
                    Destroy(this);
                }
            }
            else
            {
                FindNextNode(other);
            }
        }

        if (other.tag == "Auto:Junction")
        {
            FindNextNode(other);
        }
    }

    private void FindNextNode(Collider other)
    {
        Neighbors.Clear();
        currentnode = other.gameObject;
        Neighbors.AddRange(other.GetComponent<NodeScript>().neighbors);
        int _selectDirection = Random.Range(0, Neighbors.Count);
        nextNode = Neighbors[_selectDirection];
    }

    //if auto collides with another auto or agent stop auto movement
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Agent:Unit" || other.gameObject.tag == "Auto:Unit")
        {
            isStopped = true;
        }


    }

    private void OnCollisionExit(Collision other)
    {
        isStopped = false;
    }

    private void FixedUpdate()
    {
        if (nextNode != null)
        {
            Drive();
            navmeshAuto.speed = 3.5f * GameData.gameSpeed;
        }
    }

    private void Drive()
    {
        if (!isStopped)
        {
            navmeshAuto.SetDestination(nextNode.transform.position);
        }
        else
        {
            navmeshAuto.velocity.Set(0f, 0f, 0f);
        }
    }
}