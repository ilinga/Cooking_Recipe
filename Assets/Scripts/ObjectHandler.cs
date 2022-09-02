using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectHandler : MonoBehaviour
{
    public GameObject gameObject;
    public int x = 0;
    public int y = 0;
    public int z = 0;
    //private static ObjectHandler instance = null;
    //private static readonly object padlock = new object();
    //ObjectHandler()
    //{
    //}
    /*
    public static ObjectHandler Instance
    {
        get
        {
            lock (padlock)
            {
                if (instance == null)
                {
                    instance = new ObjectHandler();
                }
                return instance;
            }
        }
    }
    */
    public static void AddObject(GameObject gameObject, Vector3 vector3)
    {
        Instantiate(gameObject, vector3, Quaternion.identity);
    }

    public static void RemoveObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }
}
