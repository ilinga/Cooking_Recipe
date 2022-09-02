using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public List<GameObject> gameObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlaceManager()
    { 
        for(int i = 0; i < gameObjects.Count; i++)
        {
            Vector3 vector3 = new Vector3(0, 0, 0);
            ObjectHandler.AddObject(gameObjects[i], vector3);
        }
    }

    void RemoveManager()
    {
        for(int i = 0; i < gameObjects.Count; i++)
        {
            ObjectHandler.RemoveObject(gameObjects[i]);
        }
    }
}
