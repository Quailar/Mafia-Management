using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationBaker : MonoBehaviour
{

    public NavMeshSurface[] nSurfaces;


    // Use this for initialization
    void Start()
    {


        for (int i = 0; i < nSurfaces.Length; i++)
        {
            nSurfaces[i].BuildNavMesh();
        }
    }

}