using System.Collections.Generic;
using UnityEngine;
using TMPro;


//Tuen on the auto navigation path.  primariry for debugging
public class Auto_Navigation_Display : MonoBehaviour
{
    //public MapConfiguration MapController;

    public List<GameObject> Nav_Roads = new List<GameObject>();
    public Material Nav_Roads_ON;
    public Material Nav_Roads_OFF;


    public List<GameObject> Auto_Spawn_Nodes = new List<GameObject>();
    public Material Auto_Spawn_Nodes_ON;
    public Material Auto_Spawn_Nodes_OFF;

    public List<GameObject> Auto_DeSpawn_Nodes = new List<GameObject>();
    public Material Auto_DeSpawn_Nodes_ON;
    public Material Auto_DeSpawn_Nodes_OFF;

    public List<GameObject> Agent_Spawn_Nodes = new List<GameObject>();
    public Material Agent_Spawn_Nodes_ON;
    public Material Agent_Spawn_Nodes_OFF;

    public TextMeshProUGUI civCount;
    public TextMeshProUGUI autoCount;

    private void FixedUpdate()
    {
        civCount.text = GameData.TotalCivilians.ToString();
        autoCount.text = GameData.TotalAutos.ToString();
    }

    public void DisplayPath()
    {
        if (GameData.autoDisplayPath == false)
        {
            GameData.autoDisplayPath = true;
        }
        else
        {
            GameData.autoDisplayPath = false;
        }
    }

    // public void UpdateMesh()
    // {
    //     MapController.UpdateNavMesh();
    // }
    public void ActivateNavDisplay()//Toggle Nav Display
    {
        if (Nav_Roads.Count != 0)//If spawn points array has elements
        {
            if (!GameData.NavigationDisplayActive)//If Navigation display variable is false
            {
                GameData.NavigationDisplayActive = true;//Navigation display is true
                foreach (GameObject obj in Nav_Roads)//For each road object swap material
                {
                    obj.GetComponent<Renderer>().material = Nav_Roads_ON;
                }


            }
            else//If Navigation display variable is true
            {
                GameData.NavigationDisplayActive = false;//Navigation display is false
                foreach (GameObject obj in Nav_Roads)//For each road object swap material
                {
                    obj.GetComponent<Renderer>().material = Nav_Roads_OFF;
                }

            }
        }
        else//If spawn points array is empty
        {
            Nav_Roads.AddRange(GameObject.FindGameObjectsWithTag("Map:RoadSection"));//load auto nav road 
            Nav_Roads.AddRange(GameObject.FindGameObjectsWithTag("Map:IntersectionCrossing"));//load auto nav road 
            Nav_Roads.AddRange(GameObject.FindGameObjectsWithTag("Map:IntersectionCenter"));//load auto nav road 
            if (!GameData.NavigationDisplayActive)//If Navigation display variable is false
            {
                GameData.NavigationDisplayActive = true;//Navigation display is true
                foreach (GameObject obj in Nav_Roads)//For each road object swap material
                {
                    obj.GetComponent<Renderer>().material = Nav_Roads_ON;
                }


            }
            else//If Navigation display variable is true
            {
                GameData.NavigationDisplayActive = false;//Navigation display is false
                foreach (GameObject obj in Nav_Roads)//For each road object swap material
                {
                    obj.GetComponent<Renderer>().material = Nav_Roads_OFF;
                }
            }
        }
    }
    public void ActivateSpawnDisplay()//Toggle Spawn Display
    {
        if (Auto_Spawn_Nodes.Count != 0)//If spawn points array is empty load spawn points
        {
            if (!GameData.NavigationSpawnDisplayActive)//If Navigation display variable is false
            {
                GameData.NavigationSpawnDisplayActive = true;//Navigation display is true
                foreach (GameObject obj in Auto_Spawn_Nodes)//For each road object swap material
                {
                    obj.GetComponent<Renderer>().material = Auto_Spawn_Nodes_ON;
                }
                foreach (GameObject obj in Auto_DeSpawn_Nodes)//For each road object swap material
                {
                    obj.GetComponent<Renderer>().material = Auto_DeSpawn_Nodes_ON;
                }
                foreach (GameObject obj in Agent_Spawn_Nodes)//For each road object swap material
                {
                    obj.GetComponent<Renderer>().material = Agent_Spawn_Nodes_ON;
                }
            }
            else//If Navigation display variable is true
            {
                GameData.NavigationSpawnDisplayActive = false;//Navigation display is false
                foreach (GameObject obj in Auto_Spawn_Nodes)//For each road object swap material
                {
                    obj.GetComponent<Renderer>().material = Auto_Spawn_Nodes_OFF;
                }
                foreach (GameObject obj in Auto_DeSpawn_Nodes)//For each road object swap material
                {
                    obj.GetComponent<Renderer>().material = Auto_DeSpawn_Nodes_OFF;
                }
                foreach (GameObject obj in Agent_Spawn_Nodes)//For each road object swap material
                {
                    obj.GetComponent<Renderer>().material = Agent_Spawn_Nodes_OFF;
                }
            }
        }
        else
        {
            Agent_Spawn_Nodes.AddRange(GameObject.FindGameObjectsWithTag("Agent:Spawn"));//load auto nav links
            Auto_Spawn_Nodes.AddRange(GameObject.FindGameObjectsWithTag("Auto:Spawn"));//load auto nav links
            Auto_DeSpawn_Nodes.AddRange(GameObject.FindGameObjectsWithTag("Auto:Despawn"));//load auto nav links
            if (!GameData.NavigationSpawnDisplayActive)//If Navigation display variable is false
            {
                GameData.NavigationSpawnDisplayActive = true;//Navigation display is true
                foreach (GameObject obj in Auto_Spawn_Nodes)//For each road object swap material
                {
                    obj.GetComponent<Renderer>().material = Auto_Spawn_Nodes_ON;
                }
                foreach (GameObject obj in Auto_DeSpawn_Nodes)//For each road object swap material
                {
                    obj.GetComponent<Renderer>().material = Auto_DeSpawn_Nodes_ON;
                }
                foreach (GameObject obj in Agent_Spawn_Nodes)//For each road object swap material
                {
                    obj.GetComponent<Renderer>().material = Agent_Spawn_Nodes_ON;
                }
            }
            else//If Navigation display variable is true
            {
                GameData.NavigationSpawnDisplayActive = false;//Navigation display is false
                foreach (GameObject obj in Auto_Spawn_Nodes)//For each road object swap material
                {
                    obj.GetComponent<Renderer>().material = Auto_Spawn_Nodes_OFF;
                }
                foreach (GameObject obj in Auto_DeSpawn_Nodes)//For each road object swap material
                {
                    obj.GetComponent<Renderer>().material = Auto_DeSpawn_Nodes_OFF;
                }
                foreach (GameObject obj in Agent_Spawn_Nodes)//For each road object swap material
                {
                    obj.GetComponent<Renderer>().material = Agent_Spawn_Nodes_OFF;
                }
            }
        }
    }
}
