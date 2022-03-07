using UnityEngine;
using System.Collections.Generic;

//The Spawn Manager is used to spawn the agent units and auto units to map.

public class Spawn_Manager : MonoBehaviour
{
    public GameData gameData;
    public List<GameObject> AGENT_SPAWN_POINT = new List<GameObject>();
    public List<GameObject> AUTO_SPAWN_POINT = new List<GameObject>();
    public List<GameObject> AUTO_DESPAWN_POINT = new List<GameObject>();
    public static List<GameObject> AUTO_DESTINATION_POINT = new List<GameObject>();

    //Spawn agent unit
    public void spawnAgent()
    {
        if (AGENT_SPAWN_POINT.Count != 0)//If spawn points array is empty load spawn points
        {
            int spawnNode = Random.Range(0, AGENT_SPAWN_POINT.Count);//Pick a random spawn point
            Vector3 spawnLoc = new Vector3(AGENT_SPAWN_POINT[spawnNode].transform.position.x, 0, AGENT_SPAWN_POINT[spawnNode].transform.position.z);//Get location of spawn point
            int prefabIndex = Random.Range(0, gameData.PREFAB_AGENTS.Count);//get a random agent from array
            GameObject spawnNewAgent = Instantiate(gameData.PREFAB_AGENTS[prefabIndex], spawnLoc, Quaternion.identity);//Spawn new agent at spawn point
            spawnNewAgent.transform.parent = gameObject.transform;//Save clone under parent of this script
            GameData.TotalCivilians++;
        }
        else
        {
            AGENT_SPAWN_POINT.AddRange(GameObject.FindGameObjectsWithTag("TAG:Agent_Spawn"));//load agent spawn points
            int spawnNode = Random.Range(0, AGENT_SPAWN_POINT.Count);//Pick a random spawn point
            Vector3 spawnLoc = new Vector3(AGENT_SPAWN_POINT[spawnNode].transform.position.x, 0, AGENT_SPAWN_POINT[spawnNode].transform.position.z);//Get location of spawn point
            int prefabIndex = Random.Range(0, gameData.PREFAB_AGENTS.Count);//get a random agent from array
            GameObject spawnNewAgent = Instantiate(gameData.PREFAB_AGENTS[prefabIndex], spawnLoc, Quaternion.identity);//Spawn new agent at spawn point
            spawnNewAgent.transform.parent = gameObject.transform;//Save clone under parent of this script
            GameData.TotalCivilians++;
        }
    }
    public void spawnAuto()
    {
        if (AUTO_SPAWN_POINT.Count != 0)//If spawn points array is empty load spawn points
        {
            int spawnNode = Random.Range(0, AUTO_SPAWN_POINT.Count);//Pick a random spawn point
            Vector3 spawnLoc = new Vector3(AUTO_SPAWN_POINT[spawnNode].transform.position.x, 0f, AUTO_SPAWN_POINT[spawnNode].transform.position.z);//Get location of spawn point
            int prefabIndex = Random.Range(0, gameData.PREFAB_AUTOS.Count);//get a random auto from array
            GameObject spawnNewAuto = Instantiate(gameData.PREFAB_AUTOS[prefabIndex], spawnLoc, Quaternion.identity);//Spawn new auto at spawn point
            //spawnNewAuto.transform.parent = gameObject.transform;//Save clone under parent of this script
            GameData.TotalAutos++;

        }
        else
        {
            AUTO_SPAWN_POINT.AddRange(GameObject.FindGameObjectsWithTag("TAG:Auto_Spawn"));//load auto spawn points
            AUTO_DESPAWN_POINT.AddRange(GameObject.FindGameObjectsWithTag("TAG:Auto_Despawn"));//load Auto despawn points
            AUTO_DESTINATION_POINT.AddRange(GameObject.FindGameObjectsWithTag("TAG:Auto_Link_Nav"));//load Auto Nav Links
            int spawnNode = Random.Range(0, AUTO_SPAWN_POINT.Count);//Pick a random spawn point
            Vector3 spawnLoc = new Vector3(AUTO_SPAWN_POINT[spawnNode].transform.position.x, 0f, AUTO_SPAWN_POINT[spawnNode].transform.position.z);//Get location of spawn point
            int prefabIndex = Random.Range(0, gameData.PREFAB_AUTOS.Count);//get a random auto from array
            GameObject spawnNewAuto = Instantiate(gameData.PREFAB_AUTOS[prefabIndex], spawnLoc, Quaternion.identity);//Spawn new auto at spawn point
            //spawnNewAuto.transform.parent = gameObject.transform;//Save clone under parent of this script
            GameData.TotalAutos++;
        }
    }
}
