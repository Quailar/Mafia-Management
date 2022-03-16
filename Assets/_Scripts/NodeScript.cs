using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    public List<GameObject> neighbors;
    private void OnDrawGizmos()
    {
        foreach (GameObject nextNode in neighbors)
        {
            if (nextNode.tag == "Auto_Despawn")
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(transform.position, nextNode.transform.position);
            }
            if (nextNode.tag == "Auto_Spawn")
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(transform.position, nextNode.transform.position);
            }
            if (nextNode.tag == "Auto_Junction")
            {
                Gizmos.color = Color.magenta;
                Gizmos.DrawLine(transform.position, nextNode.transform.position);
            }
            if (nextNode.tag == "Auto_Node_Red")
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, nextNode.transform.position);
            }
            if (nextNode.tag == "Auto_Node_Blue")
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(transform.position, nextNode.transform.position);
            }
        }
    }
}