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
            if (nextNode.tag == "Auto:Despawn")
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(transform.position, nextNode.transform.position);
            }
            if (nextNode.tag == "Auto:Spawn")
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(transform.position, nextNode.transform.position);
            }
            if (nextNode.tag == "Auto:Junction")
            {
                Gizmos.color = Color.magenta;
                Gizmos.DrawLine(transform.position, nextNode.transform.position);
            }
            if (nextNode.tag == "Auto:NodeRed")
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, nextNode.transform.position);
            }
            if (nextNode.tag == "Auto:NodeBlue")
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(transform.position, nextNode.transform.position);
            }
        }
    }
}