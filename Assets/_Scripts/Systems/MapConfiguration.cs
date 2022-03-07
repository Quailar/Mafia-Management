using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapConfiguration : MonoBehaviour
{

    public GameData gameData;
    [Tooltip("Zero is no city block rotation")]//Rotating city blocks increases navigation issues
    [Range(0, 1)]//Multiplier for ratation
    public int Rotation_Switch;//Toggle switch to enable rotation
    public int deg;

    private void Awake()
    {
        //StartCoroutine(MapSetup());
        ActivateGameMap(GameData.MapSize);//Map size set in options menu
        SetCenterBlock();
        SetCityBlocks();
        UpdateNavMesh();
    }
    // IEnumerator MapSetup()
    // {

    // }
    public void ActivateGameMap(string size)
    {
        switch (size)
        {
            case "Large":
                GameData.GAME_MAP = gameData.PREFAB_GAME_MAPS[2];
                break;
            case "Medium":
                GameData.GAME_MAP = gameData.PREFAB_GAME_MAPS[1];
                break;
            case "Small":
                GameData.GAME_MAP = gameData.PREFAB_GAME_MAPS[0];
                break;
            default:
                GameData.GAME_MAP = gameData.PREFAB_GAME_MAPS[0];
                break;
        }

        if (GameData.GAME_MAP != null)
        {
            Instantiate(GameData.GAME_MAP, Vector3.zero, Quaternion.identity);
        }
    }

    private void SetCenterBlock()
    {
        gameData.CITY_CENTER_BLOCK_COORDINATE.Add(GameObject.FindGameObjectWithTag("TAG:Block_Center_Coordinate"));
        int randomCenterBlock = Random.Range(0, gameData.PREFAB_CENTER_BLOCKS.Count);//Get random center block prefab
        GameObject spawnCenterBuilding = Instantiate(gameData.PREFAB_CENTER_BLOCKS[randomCenterBlock], gameData.CITY_CENTER_BLOCK_COORDINATE[0].transform.position, Quaternion.identity);//Spawn random center clock to map center block
        spawnCenterBuilding.transform.parent = gameObject.transform;//Store in Parent object at runtime
    }

    private void SetCityBlocks()
    {
        gameData.CITY_NEIGHBORHOOD_BLOCK_COORDINATES.AddRange(GameObject.FindGameObjectsWithTag("TAG:Block_Coordinates"));
        for (int i = 0; i < gameData.CITY_NEIGHBORHOOD_BLOCK_COORDINATES.Count; i++)//For each city block coordinate on map
        {
            int randomDirection = Random.Range(0, 3) * Rotation_Switch;//Get random rotation of city block.  Rotation switch multipler used to disable
            if (randomDirection == 0)
            {
                deg = 0;
            }
            else if (randomDirection == 1)
            {
                deg = 90;
            }
            else if (randomDirection == 2)
            {
                deg = 180;
            }
            else if (randomDirection == 3)
            {
                deg = 270;
            }

            Vector3 SpawnLocation = gameData.CITY_NEIGHBORHOOD_BLOCK_COORDINATES[i].transform.position;//Get city block map location
            int randomCityBlock = Random.Range(0, gameData.PREFAB_CITY_BLOCKS.Count);//Get random prfab city block
            GameObject spawnBuilding = Instantiate(gameData.PREFAB_CITY_BLOCKS[randomCityBlock], SpawnLocation, Quaternion.Euler(new Vector3(0, deg, 0)));//Spawn random city block to map block coordinate
            spawnBuilding.transform.parent = gameObject.transform;//Store in Parent object at runtime
        }
    }

    public void UpdateNavMesh()//Build all five navmeshes 
    {
        gameData.NAVMESH_AGENT[0].BuildNavMesh();
        gameData.NAVMESH_AUTO[0].BuildNavMesh();
        gameData.NAVMESH_AUTO[1].BuildNavMesh();
        gameData.NAVMESH_AUTO[2].BuildNavMesh();
        gameData.NAVMESH_AUTO[3].BuildNavMesh();
        gameData.NAVMESH_AUTO[4].BuildNavMesh();
    }
}