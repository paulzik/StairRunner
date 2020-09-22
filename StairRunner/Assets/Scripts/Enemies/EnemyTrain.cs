using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StairRunner.Utilities;

public class EnemyTrain : EnemyBehaviour
{
    private GameObject stepGameObject;
    private Vector3 directionVec;

    // Use this for initialization
    void Start()
    {
        stepGameObject = transform.parent.gameObject;
        //Spawn Rails
        PrefabImporter.SpawnPrefab("Prefabs/Spawners/Train/Rails", stepGameObject);
        
        RandomTrainGenerator();
    }

    /// <summary>
    /// Rolls the dice and generates a random train
    /// </summary>
    private void RandomTrainGenerator()
    {
        int numOfCargos = Randomizer.RollTheDice(1, 4);
        int direction = Randomizer.RollTheDice(0, 2);
        speed = Randomizer.RollTheDice(1, 11);

        //Number of cargos
        for(int i = 0; i < numOfCargos; i++)
        {
            GameObject cargo = PrefabImporter.SpawnPrefab("Prefabs/Spawners/Train/Cargo", gameObject);

            cargo.transform.Translate(new Vector3(-1 * (i + 1), 0, 0));
        }

        //Direction
        if (direction == 0) //Right
        {
            transform.localPosition = new Vector3(4.0f, 0.849f, -0.01699996f);
            transform.localRotation = Quaternion.Euler(-90, 180, 0);

            directionVec = new Vector3(-1, 0, 0);
        }
        else //Left
        {
            transform.localPosition = new Vector3(-4.0f, 0.849f, -0.01699996f);
            transform.localRotation = Quaternion.Euler(-90, 180, 180);

            directionVec = new Vector3(1, 0, 0);

        }

    }

    public void Update()
    {
        transform.Translate(directionVec * Time.deltaTime * speed * (0.2f), Space.World);
    }



    public override void AttackPlayer()
    {
        
    }

    public override void StopAttackPlayer()
    {
        
    }



}
