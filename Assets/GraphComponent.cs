using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//[ExecuteInEditMode]
public class GraphComponent : MonoBehaviour
{

    private Graph<Vector3, float> graph;
    public int maxRange;
    public int minRange;
    private List<GameObject> nodeEnter = new List<GameObject>();
    private List<GameObject> nodeExit = new List<GameObject>();
    // Start is called before the first frame update
    private async void Start()
    {
        graph = new Graph<Vector3, float>();
        nodeEnter.AddRange(GameObject.FindGameObjectsWithTag("TAG:NavigationIntersectionNode_Enter"));
        nodeExit.AddRange(GameObject.FindGameObjectsWithTag("TAG:NavigationIntersectionNode_Exit"));
        foreach (GameObject node in nodeEnter)
        {
            var node1 = new Node<Vector3>() { Value = node.transform.position, NodeColor = Color.green };
            graph.EnterNodes.Add(node1);
        }

        foreach (GameObject node in nodeExit)
        {
            var node2 = new Node<Vector3>() { Value = node.transform.position, NodeColor = Color.red };
            graph.ExitNodes.Add(node2);
        }

        for (int a = 0; a < graph.EnterNodes.Count; a++)
        {
            //print("A: " + graph.EnterNodes[a].Value);
            Node<Vector3> c = graph.EnterNodes[a];
            for (int b = 0; b < graph.ExitNodes.Count; b++)
            {

                //print("B: " + graph.EnterNodes[b].Value);
                Node<Vector3> d = graph.ExitNodes[b];
                float distanceLength = (c.Value - d.Value).magnitude;
                if (distanceLength > minRange && distanceLength < maxRange)
                {
                    //print(distanceLength);
                    var edge1 = new Edge<float, Vector3>() { Value = 5f, From = graph.EnterNodes[a], To = graph.ExitNodes[b], EdgeColor = Color.yellow };

                    //print($"(From: {edge1.From.Value.ToString()} To: {edge1.To.Value.ToString()}");
                }


            }

        }

    }
    private void Update()
    {

    }
    private void OnDrawGizmos()
    {
        if (graph == null)
        {
            Start();
        }

        foreach (var node in graph.EnterNodes)
        {
            Gizmos.color = node.NodeColor;
            Gizmos.DrawSphere(node.Value, 0.125f);
        }
        foreach (var node in graph.ExitNodes)
        {
            Gizmos.color = node.NodeColor;
            Gizmos.DrawSphere(node.Value, 0.125f);
        }
        foreach (var edge in graph.Edges)
        {
            Gizmos.color = edge.EdgeColor;
            Gizmos.DrawLine(edge.From.Value, edge.To.Value);
        }
    }
}
