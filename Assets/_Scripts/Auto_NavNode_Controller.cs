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

    private void Awake()
    {
        navmeshBaker.BuildNavMesh();
    }

    public void OnTriggerEnter(Collider other)
    {
        Neighbors.Clear();


        if (other.tag == "Auto_Node_Red" || other.tag == "Auto_Node_Blue")
        {
            currentnode = other.gameObject;

            Neighbors.AddRange(other.GetComponent<NodeScript>().neighbors);

            int _selectDirection = Random.Range(0, Neighbors.Count);

            nextNode = Neighbors[_selectDirection];
        }


        if (other.tag == "Auto_Spawn")
        {
            currentnode = other.gameObject;

            Neighbors.AddRange(other.GetComponent<NodeScript>().neighbors);

            int _selectDirection = Random.Range(0, Neighbors.Count);

            nextNode = Neighbors[_selectDirection];

        }



        if (other.tag == "Auto_Despawn")
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
                currentnode = other.gameObject;

                Neighbors.AddRange(other.GetComponent<NodeScript>().neighbors);

                int _selectDirection = Random.Range(0, Neighbors.Count);

                nextNode = Neighbors[_selectDirection];
            }
        }


        if (other.tag == "Auto_Junction")
        {
            currentnode = other.gameObject;
            Neighbors.AddRange(other.GetComponent<NodeScript>().neighbors);

            int _selectDirection = Random.Range(0, Neighbors.Count);

            nextNode = Neighbors[_selectDirection];

            while (nextNode == currentnode)
            {
                _selectDirection = Random.Range(0, Neighbors.Count);

                nextNode = Neighbors[_selectDirection];
            }


        }
    }


    //if auto collides with another auto or agent stop auto movement
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Agent" || other.gameObject.tag == "Auto")
        {
            stopped = true;
        }
    }

    private void OnCollisionExit(Collision other)
    {
        stopped = false;
    }

    private void FixedUpdate()
    {
        Drive();
    }

    private void Drive()
    {
        if (stopped)
        {
            navmeshAuto.velocity.Set(0f, 0f, 0f);
        }
        else
        {
            navmeshAuto.SetDestination(nextNode.transform.position);
        }
    }
}