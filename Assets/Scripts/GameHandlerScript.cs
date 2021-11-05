using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandlerScript : MonoBehaviour
{
    List<List<GameObject>> floorObjects;
    GameObject floorTileCollector;
    List<List<int>> tileMap;
    public GameObject BikePrefab;

    // Start is called before the first frame update
    void Start()
    {
        floorTileCollector=new GameObject();

        tileMap=new List<List<int>>();
        for(int x=0;x<50;x++){
            List<int> L=new List<int>();
            for(int y=0;y<50;y++){
                if((x>20)&&(x<25))
                    L.Add(1); //street
                else{
                    if((x==20)||(x==25))
                        L.Add(2); // sidewalk
                    else
                        L.Add(0); //gras
                }
            }
            tileMap.Add(L);
        }

        floorTileCollector.name="Floor Tile Collector";
        floorObjects=new List<List<GameObject>>();
        for(int x=0;x<50;x++){
            List<GameObject> L=new List<GameObject>();
            for(int y=0;y<50;y++){
                GameObject localGameObject=GameObject.CreatePrimitive(PrimitiveType.Cube);
                localGameObject.name="floorTile";
                L.Add(localGameObject);
                localGameObject.transform.parent=floorTileCollector.transform;
                localGameObject.transform.position=new Vector3(x,0,y);
                switch(tileMap[x][y]){
                    case 0: //gras
                        localGameObject.GetComponent<Renderer>().material.color = new Color(0.1f,1.0f,0.1f);
                        break;
                    case 1: //street
                        localGameObject.GetComponent<Renderer>().material.color = new Color(0.1f,0.1f,0.1f);
                        localGameObject.transform.position+=new Vector3(0.0f,-0.1f,0.0f);
                        break;
                    case 2: //sidewalk
                        localGameObject.GetComponent<Renderer>().material.color = new Color(0.6f,0.6f,0.6f);
                        break;
                }
            }
            floorObjects.Add(L);
        }
        BikePrefab=Resources.Load ("BikeGameObject") as GameObject;
        BikePrefab.transform.RotateAround(BikePrefab.transform.position, BikePrefab.transform.up, 45.0f);
        Instantiate(BikePrefab, new Vector3(22.0f,-0.39f,2.0f), Quaternion.identity);
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
