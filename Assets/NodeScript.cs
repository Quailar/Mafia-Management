using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{

    public GameObject CurrrentNode;

    public List<GameObject> Neighbors = new List<GameObject>();

    private void OnCollisionEnter(Collision other)
    {

        other.gameObject.GetComponent<Auto_NavNode_Controller>().SetupNode(CurrrentNode, Neighbors);
        // other.gameObject.GetComponent<Auto_NavNode_Controller>().CurrrentNode = CurrrentNode;
        // other.gameObject.GetComponent<Auto_NavNode_Controller>().Neighbors = Neighbors;
    }
}
