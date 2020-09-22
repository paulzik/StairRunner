using System.Collections.Generic;
using UnityEngine;

namespace StairRunner.Utilities
{
    public class PrefabImporter : MonoBehaviour
    {

        public static GameObject LoadPrefab(string path)
        {
            GameObject loadedObject = Resources.Load(path, typeof(GameObject)) as GameObject;

            if (loadedObject)
                return loadedObject;
            else
            {
                Debug.LogError("Prefab Not Found");
                return null;
            }
        }

        public static GameObject SpawnPrefab(string path, GameObject parent = null)
        {
            
            GameObject prefab = Resources.Load(path) as GameObject;
            if (prefab == null)
            {
                Debug.LogError("Prefab: " + path + " Not Found!!!");
                return null;
            }

            if (parent == null) //Spawn with no parent
            {
                prefab = Instantiate(prefab) as GameObject;
            }
            else//Spawn with parent
            {
                prefab = Instantiate(prefab, parent.transform) as GameObject;
            }

            return prefab;
        }

    }
}

