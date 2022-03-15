using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Auto_NavNode_Controller : MonoBehaviour
{
    public NavMeshAgent navmeshAuto;
    public NavMeshSurface navmeshBaker;
    public GameObject currentnode;
    public GameObject nextNode;
    public List<GameObject> Neighbors;
    public bool stopped;
    public bool ReduceTraffic;

    private void Awake()
    {
        navmeshBaker.BuildNavMesh();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Node")
        {
            currentnode = other.gameObject;
            print("Auto Sees Node: ");



            Neighbors.AddRange(other.GetComponent<NodeScript>().neighbors);
            print("Amount of Neighbors: " + Neighbors.Count);
            int _selectDirection = Random.Range(0, Neighbors.Count);
            print("Neighbor Selected: " + _selectDirection);
            nextNode = Neighbors[_selectDirection];
            if (nextNode.layer == 7)//Blueline node
            {
                //navmeshAuto.agentTypeID = ;
            }
            if (nextNode.layer == 8)//Redline node
            {
                //navmeshAuto.agentTypeID = ;
            }
            if (currentnode.layer == 0 && ReduceTraffic == true)//Despaen Node
            {
                Destroy(this.gameObject);
            }
            print("NextNode: " + nextNode);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Neighbors.Clear();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Agent" || other.gameObject.tag == "Auto")
        {

            stopped = true;
            print(stopped);
        }
    }

    private void OnCollisionExit(Collision other)
    {

        stopped = false;
        print(stopped);
    }

    private void FixedUpdate()
    {
        Drive();

    }

    private void Drive()
    {
        if (stopped)
        {
            print("Stopping");
            // this.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity - (Vector3.one * .5f);
            navmeshAuto.velocity.Set(0f, 0f, 0f);
        }
        else
        {
            print("Driving");
            // this.GetComponent<Rigidbody>().MovePosition(transform.position + (transform.forward * speed * Time.deltaTime));
            navmeshAuto.SetDestination(nextNode.transform.position);
        }
    }
}