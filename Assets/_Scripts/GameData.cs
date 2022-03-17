//================================
//          OBJECTS
//================================
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public partial class GameData : MonoBehaviour
{
    [Header("Navmesh Bakes")]
    public NavMeshSurface NAVMESH_AGENT;
    public NavMeshSurface NAVMESH_AUTO;


    [Header("Neighborhood Coordinates")]
    public List<GameObject> CENTER_BLOCK_COORDINATES = new List<GameObject>();

    public List<GameObject> HQ_BLOCK_COORDINATES = new List<GameObject>();
    public List<GameObject> NEIGHBORHOOD_BLOCK_COORDINATES = new List<GameObject>();
    public List<GameObject> NEIGHBORHOOD_BUILDING_COORDINATES = new List<GameObject>();


    [Header("Prefab Objects")]
    public List<GameObject> PREFAB_GAME_MAPS = new List<GameObject>();
    public List<GameObject> PREFAB_CENTER_BLOCKS = new List<GameObject>();
    public List<GameObject> PREFAB_HQ_BLOCKS = new List<GameObject>();
    public List<GameObject> PREFAB_NEIGHBORHOOD_BLOCKS = new List<GameObject>();
    public List<GameObject> PREFAB_BUILDINGS = new List<GameObject>();
    public List<GameObject> PREFAB_AUTOS = new List<GameObject>();
    public List<GameObject> PREFAB_AGENTS = new List<GameObject>();


    [Header("Lists of Objects")]
    public List<GameObject> LIST_TOTAL_AUTOS = new List<GameObject>();
    public List<GameObject> LIST_TOTAL_AGENTS = new List<GameObject>();
    public List<GameObject> LIST_TOTAL_CIVILIANS = new List<GameObject>();
    public List<GameObject> LIST_TOTAL_POLICE = new List<GameObject>();
    public List<GameObject> LIST_TOTAL_JUDGES = new List<GameObject>();
    public List<GameObject> LIST_TOTAL_PLAYER1 = new List<GameObject>();
    public List<GameObject> LIST_TOTAL_PLAYER2 = new List<GameObject>();
    public List<GameObject> LIST_TOTAL_PLAYER3 = new List<GameObject>();
    public List<GameObject> LIST_TOTAL_PLAYER4 = new List<GameObject>();
    public List<GameObject> LIST_TOTAL_PLAYER5 = new List<GameObject>();
    public List<GameObject> LIST_TOTAL_PLAYER6 = new List<GameObject>();
    public List<GameObject> STREET_LIGHTS = new List<GameObject>();
    public List<GameObject> NEIGHBORHOOD_LIGHTS = new List<GameObject>();

    private void Start()
    {
        NAVMESH_AUTO.BuildNavMesh();
        NAVMESH_AGENT.BuildNavMesh();
    }
}
