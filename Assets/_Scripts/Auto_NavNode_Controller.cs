using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;


public class Auto_NavNode_Controller : MonoBehaviour
{
    public NavMeshAgent navMeshAuto;
    public GameObject CurrrentNode;

    public GameObject NextNode;

    public List<GameObject> Neighbors = new List<GameObject>();


    public void Start()
    {

    }

    public void SetupNode(GameObject _current_node, List<GameObject> _neighbor_nodes)
    {
        CurrrentNode = _current_node;
        Neighbors.AddRange(_neighbor_nodes);
        FindOptions();
    }

    public void FindOptions()
    {
        for (int i = 0; i < Neighbors.Count; i++)
        {
            if (Neighbors[i] != null)
            {
                Neighbors.Add(Neighbors[i]);
            }
        }
        ChoosePath();
    }

    public void ChoosePath()
    {
        int n = Random.Range(0, Neighbors.Count);
        NextNode = Neighbors[n];
        navMeshAuto.SetDestination(NextNode.transform.position);
    }

}