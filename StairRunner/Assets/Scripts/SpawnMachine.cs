using System.Collections;
using UnityEngine;
using StairRunner.Utilities;

public class SpawnMachine : MonoBehaviour
{
    private enum spawnedType { ghost, boxingSpring, dentures, train, mana }
    private  GameObject ghostPrefab, manaPrefab, boxingSpring, denturesPrefab, trainPrefab;
    private  float chanceOfSpawn = 0.75f;

    private static SpawnMachine _instance = null;
    public static SpawnMachine Get { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        manaPrefab = PrefabImporter.LoadPrefab("Prefabs/Spawners/Mana");
        ghostPrefab = PrefabImporter.LoadPrefab("Prefabs/Spawners/Ghost");
        boxingSpring = PrefabImporter.LoadPrefab("Prefabs/Spawners/BoxingSpring");
        denturesPrefab = PrefabImporter.LoadPrefab("Prefabs/Spawners/Dentures");
        trainPrefab = PrefabImporter.LoadPrefab("Prefabs/Spawners/Train/TrainEngine");
    }


    public void SpawnRandomEverything(GameObject _step)
    {
        //Chance to spawn
        if(Random.Range(0.0f, 1.0f) <= chanceOfSpawn)
        {
            GameObject spawnedObject = null;
            //Select type of spawned
            spawnedType spawnedObjectType = (spawnedType)Random.Range(0, System.Enum.GetValues(typeof(spawnedType)).Length);
            
            switch (spawnedObjectType)
            {
                case spawnedType.ghost:
                    spawnedObject = Instantiate(ghostPrefab, _step.transform);
                    spawnedObject.transform.localPosition = new Vector3(spawnedObject.transform.localPosition.x, spawnedObject.transform.localPosition.y, Random.Range(-0.38f, 0.38f));
                    StepObserver.Get.AddNewEnemy(StairGenerator.Get.StepCounter + 1, spawnedObject);
                    break;
                case spawnedType.boxingSpring:
                    spawnedObject = Instantiate(boxingSpring, _step.transform);
                    StepObserver.Get.AddNewEnemy(StairGenerator.Get.StepCounter + 1, spawnedObject);
                    break;
                case spawnedType.dentures:
                    spawnedObject = Instantiate(denturesPrefab, _step.transform);
                    StepObserver.Get.AddNewEnemy(StairGenerator.Get.StepCounter + 1, spawnedObject);
                    break;
                case spawnedType.train:
                    spawnedObject = Instantiate(trainPrefab, _step.transform);
                    StepObserver.Get.AddNewEnemy(StairGenerator.Get.StepCounter + 1, spawnedObject);
                    break;
                case spawnedType.mana:
                    spawnedObject = Instantiate(manaPrefab, _step.transform);
                    spawnedObject.transform.localPosition = new Vector3(spawnedObject.transform.localPosition.x, spawnedObject.transform.localPosition.y, Random.Range(-0.38f, 0.38f));
                    break;
                default:
                    break;
            }
                

        }

    }

}