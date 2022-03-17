using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapConfiguration : MonoBehaviour
{

    public GameData gameData;
    public GameObject MapInstanceFolder;
    public GameObject NeighborhoodInstanceFolder;
    public GameObject CenterBlockInstanceFolder;
    public GameObject HQBlockInstanceFolder;
    public GameObject BuildingInstanceFolder;




    [Tooltip("Zero is no city block rotation")]//Rotating city blocks increases navigation issues
    [Range(0, 1)]//Multiplier for ratation
    public int Rotation_Switch;//Toggle switch to enable rotation
    public int deg;

    private void Awake()
    {
        ActivateGameMap(GameData.MapSize);//Map size set in options menu
        SetCenterBlock();
        SetHQBlock();
        SetNeighborhoodBlocks();
        SetBuildings();

    }
    private void Start()
    {

    }

    public void ActivateGameMap(string size)
    {
        switch (size)
        {
            case "Large":
                GameData.GAME_MAP = gameData.PREFAB_GAME_MAPS[2];
                GameData.NAV_MAP = gameData.PREFAB_NAV_MAPS[2];
                break;
            case "Medium":
                GameData.GAME_MAP = gameData.PREFAB_GAME_MAPS[1];
                GameData.NAV_MAP = gameData.PREFAB_NAV_MAPS[1];
                break;
            case "Small":
                GameData.GAME_MAP = gameData.PREFAB_GAME_MAPS[0];
                GameData.NAV_MAP = gameData.PREFAB_NAV_MAPS[0];
                break;
            default:
                GameData.GAME_MAP = gameData.PREFAB_GAME_MAPS[0];
                GameData.NAV_MAP = gameData.PREFAB_NAV_MAPS[0];
                break;
        }


        GameObject spawnMap = Instantiate(GameData.GAME_MAP, Vector3.zero, Quaternion.identity);
        spawnMap.transform.parent = MapInstanceFolder.transform;
        GameObject navMap = Instantiate(GameData.NAV_MAP, Vector3.zero, Quaternion.identity);
        navMap.transform.parent = MapInstanceFolder.transform;

    }

    private void SetCenterBlock()
    {
        gameData.NEIGHBORHOOD_CENTER_COORDINATES.Add(GameObject.FindGameObjectWithTag("Neighborhood:CenterCoordinates"));

        foreach (GameObject coordinate in gameData.NEIGHBORHOOD_CENTER_COORDINATES)
        {
            int randomCenterBlock = Random.Range(0, gameData.PREFAB_CENTER_BLOCKS.Count);//Get random center block prefab
            GameObject spawnCenterBuilding = Instantiate(gameData.PREFAB_CENTER_BLOCKS[randomCenterBlock], gameData.NEIGHBORHOOD_CENTER_COORDINATES[0].transform.position, Quaternion.identity);//Spawn random center clock to map center block
            spawnCenterBuilding.transform.parent = CenterBlockInstanceFolder.transform;//Store in Parent object at runtime
        }
    }

    private void SetHQBlock()
    {
        gameData.HQ_COORDINATES.AddRange(GameObject.FindGameObjectsWithTag("Neighborhood:HQCoordinates"));

        foreach (GameObject coordinate in gameData.HQ_COORDINATES)
        {
            int randomHQBlock = Random.Range(0, gameData.PREFAB_HQ_BLOCKS.Count);//Get random HQ block prefab
            GameObject spawnHQBuilding = Instantiate(gameData.PREFAB_HQ_BLOCKS[randomHQBlock], coordinate.transform.position, Quaternion.identity);//Spawn random HQ clock to map center block
            spawnHQBuilding.transform.parent = HQBlockInstanceFolder.transform;//Store in Parent object at runtime
        }
    }

    private void SetNeighborhoodBlocks()
    {
        gameData.NEIGHBORHOOD_COORDINATES.AddRange(GameObject.FindGameObjectsWithTag("Neighborhood:Coordinates"));

        foreach (GameObject coordinate in gameData.NEIGHBORHOOD_COORDINATES)
        {
            int randomNeighborhoodBlock = Random.Range(0, gameData.PREFAB_NEIGHBORHOOD_BLOCKS.Count);//Get random NEIGHBORHOOD block prefab
            GameObject spawnNeighborhoodBuilding = Instantiate(gameData.PREFAB_NEIGHBORHOOD_BLOCKS[randomNeighborhoodBlock], coordinate.transform.position, Quaternion.identity);//Spawn random NEIGHBORHOOD clock to map center block
            spawnNeighborhoodBuilding.transform.parent = NeighborhoodInstanceFolder.transform;//Store in Parent object at runtime
        }
    }

    private void SetBuildings()
    {
        gameData.BUILDING_COORDINATES.AddRange(GameObject.FindGameObjectsWithTag("Building:Blueprint"));

        foreach (GameObject coordinate in gameData.BUILDING_COORDINATES)
        {
            int randomBuilding = Random.Range(0, gameData.PREFAB_BUILDINGS.Count);//Get random BUILDING block prefab
            GameObject spawnBuilding = Instantiate(gameData.PREFAB_BUILDINGS[randomBuilding], coordinate.transform.position, coordinate.transform.rotation);//Spawn random NEIGHBORHOOD clock to map center block
            spawnBuilding.transform.parent = BuildingInstanceFolder.transform;//Store in Parent object at runtime
        }
    }
}