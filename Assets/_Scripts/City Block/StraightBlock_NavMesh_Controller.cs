using UnityEngine;
//This script is to change the road navigation direction when city block is rotated

public class StraightBlock_NavMesh_Controller : MonoBehaviour
{
    public GameObject[] Nav_Roads;
    public GameObject[] BUILDING_COORDINATES;
    public GameObject[] PREFAB_BUILDINGS;

    // Nav_Roads[0].layer = 16;  //NORTH Road
    // Nav_Roads[1].layer = 17;  //SOUTH Road
    // Nav_Roads[2].layer = 18;  //EAST Road
    // Nav_Roads[3].layer = 19;  //WEST Road

    private void Start()

    {
        GetDirection(transform.eulerAngles.y);
        PlotBuildings();
    }

    public void GetDirection(float degree)
    {
        switch (degree)
        {
            case 0:
                Nav_Roads[0].layer = 17;
                Nav_Roads[1].layer = 16;
                break;
            case 90:
                Nav_Roads[0].layer = 19;
                Nav_Roads[1].layer = 18;
                break;
            case 180:
                Nav_Roads[0].layer = 16;
                Nav_Roads[1].layer = 17;
                break;
            case 270:
                Nav_Roads[0].layer = 18;
                Nav_Roads[1].layer = 19;
                break;
            default:
                Nav_Roads[0].layer = 18;
                Nav_Roads[1].layer = 19;
                break;
        }
    }
    public void PlotBuildings()
    {
        for (int i = 0; i < BUILDING_COORDINATES.Length; i++)//for each object in node list
        {
            int randomBuildingBlock = Random.Range(0, PREFAB_BUILDINGS.Length);//get a random building prefab
            GameObject newObject = Instantiate(PREFAB_BUILDINGS[randomBuildingBlock], BUILDING_COORDINATES[i].transform.position, BUILDING_COORDINATES[i].transform.rotation);//Set building to node location and direction
            newObject.transform.localScale = new Vector3(BUILDING_COORDINATES[i].transform.localScale.x, BUILDING_COORDINATES[i].transform.localScale.y, BUILDING_COORDINATES[i].transform.localScale.z);//Set building scale to node scale
        }
    }
}
