using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Auto_NavNode_Controller : MonoBehaviour
{
    //Navmesh used for movement
    [Header("Assign:")]
    public NavMeshAgent navmeshAuto;
    public TrafficLightController trafficController;


    [Header("Assign neighbor nodes:")]
    public List<GameObject> Neighbors;

    public bool isStopped;

    [SerializeField] private GameObject currentnode;
    [SerializeField] private GameObject nextNode;

    private void Start()
    {
        // navmeshAuto.speed = 3.5f * GameData.gameSpeed;
        trafficController = GameObject.FindGameObjectWithTag("TrafficLight:Manager").GetComponent<TrafficLightController>();
    }

    public void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Auto:Despawn")
        {
            if (GameData.DecreaseAutos)
            {
                if (GameData.LIST_ALL_AUTOS.Count > GameData.MaxAutos)
                {
                    Destroy(this.gameObject);
                }
            }
            FindNextNode(other);
        }


        if (other.tag == "Auto:NodeRed" || other.tag == "Auto:NodeBlue")
        {
            FindNextNode(other);
        }


        if (other.tag == "Auto:Spawn")
        {
            FindNextNode(other);
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
        Drive();
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


    private void Drive()
    {
        if (!isStopped)
        {
            navmeshAuto.SetDestination(nextNode.transform.position);
            navmeshAuto.transform.LookAt(nextNode.transform);
        }
        else
        {
            navmeshAuto.velocity.Set(0f, 0f, 0f);
        }
    }
}