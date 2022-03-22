using System.Collections.Generic;
using UnityEngine;
using TMPro;


//Tuen on the auto navigation path.  primariry for debugging
public class Auto_Node_Display : MonoBehaviour
{

    public List<GameObject> AutoNodesRed = new List<GameObject>();
    public List<GameObject> AutoNodesBlue = new List<GameObject>();
    public List<GameObject> AutoNodesJunction = new List<GameObject>();
    public List<GameObject> AutoNodesSpawn = new List<GameObject>();
    public List<GameObject> AutoNodesDespawn = new List<GameObject>();
    public List<GameObject> AgentNodesSpawn = new List<GameObject>();


    public Material AutoNodesRed_ON;
    public Material AutoNodesBlue_ON;
    public Material AutoNodesJunction_ON;
    public Material AutoNodesSpawn_ON;
    public Material AutoNodesDespawn_ON;
    public Material AgentNodesSpawn_ON;

    public Material Nodes_OFF;


    private void Start()
    {
        AutoNodesRed.AddRange(GameObject.FindGameObjectsWithTag("Auto:NodeRed"));
        AutoNodesBlue.AddRange(GameObject.FindGameObjectsWithTag("Auto:NodeBlue"));
        AutoNodesJunction.AddRange(GameObject.FindGameObjectsWithTag("Auto:Junction"));
        AutoNodesSpawn.AddRange(GameObject.FindGameObjectsWithTag("Auto:Spawn"));
        AutoNodesDespawn.AddRange(GameObject.FindGameObjectsWithTag("Auto:Despawn"));
        AgentNodesSpawn.AddRange(GameObject.FindGameObjectsWithTag("Agent:Spawn"));

    }


    public void ActivateNavDisplay()//Toggle Nav Display
    {


        if (GameData.NavigationDisplayActive == false)
        {
            GameData.NavigationDisplayActive = true;
            foreach (GameObject node in AutoNodesRed)
            {
                node.GetComponent<MeshRenderer>().material = AutoNodesRed_ON;
            }
            foreach (GameObject node in AutoNodesBlue)
            {
                node.GetComponent<MeshRenderer>().material = AutoNodesBlue_ON;
            }
            foreach (GameObject node in AutoNodesJunction)
            {
                node.GetComponent<MeshRenderer>().material = AutoNodesJunction_ON;
            }
            foreach (GameObject node in AutoNodesSpawn)
            {
                node.GetComponent<MeshRenderer>().material = AutoNodesSpawn_ON;
            }
            foreach (GameObject node in AutoNodesDespawn)
            {
                node.GetComponent<MeshRenderer>().material = AutoNodesDespawn_ON;
            }
            foreach (GameObject node in AgentNodesSpawn)
            {
                node.GetComponent<MeshRenderer>().material = AgentNodesSpawn_ON;
            }

        }
        else
        {
            GameData.NavigationDisplayActive = false;

            foreach (GameObject node in AutoNodesRed)
            {
                node.GetComponent<MeshRenderer>().material = Nodes_OFF;
            }
            foreach (GameObject node in AutoNodesBlue)
            {
                node.GetComponent<MeshRenderer>().material = Nodes_OFF;
            }
            foreach (GameObject node in AutoNodesJunction)
            {
                node.GetComponent<MeshRenderer>().material = Nodes_OFF;
            }
            foreach (GameObject node in AutoNodesSpawn)
            {
                node.GetComponent<MeshRenderer>().material = Nodes_OFF;
            }
            foreach (GameObject node in AutoNodesDespawn)
            {
                node.GetComponent<MeshRenderer>().material = Nodes_OFF;
            }
            foreach (GameObject node in AgentNodesSpawn)
            {
                node.GetComponent<MeshRenderer>().material = Nodes_OFF;
            }

        }
    }
}
