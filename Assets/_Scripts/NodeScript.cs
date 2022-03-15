using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour
{
    public List<GameObject> neighbors;

    private void OnDrawGizmos()
    {
        if (gameObject.layer == 7)//Blueline Layer
        {
            foreach (GameObject nextNode in neighbors)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(gameObject.transform.position, nextNode.transform.position);
                //Gizmos.DrawIcon(transform.position, "d_tab_next@2x", true, Color.yellow);
            }
        }
        if (gameObject.layer == 8)//Redline Layer
        {
            foreach (GameObject nextNode in neighbors)
            {

                Gizmos.color = Color.red;
                Gizmos.DrawLine(transform.position, nextNode.transform.position);
                //Gizmos.DrawIcon(nextNode.transform.position, "d_tab_next@2x", true, Color.yellow);

            }
        }

    }

}