using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepObserver : MonoBehaviour
{
    private static StepObserver _instance = null;
    public static StepObserver Get { get { return _instance; } }

    private Dictionary<int,GameObject> enemiesMapping = new Dictionary<int, GameObject>();

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
        
    }

    public void SetCurrentStep(int _currentStep)
    {
        //if enemy exist in current step
        if (enemiesMapping.ContainsKey(_currentStep))
        {
            enemiesMapping[_currentStep].GetComponent<EnemyBehaviour>().AttackPlayer();
        }

        //Stop Attacking from prev step
        if (enemiesMapping.ContainsKey(_currentStep - 1))
        {
            enemiesMapping[_currentStep -1].GetComponent<EnemyBehaviour>().StopAttackPlayer();
        }

        if (enemiesMapping.ContainsKey(_currentStep + 1))
        {
            enemiesMapping[_currentStep + 1].GetComponent<EnemyBehaviour>().StopAttackPlayer();
        }
    }

    public void AddNewEnemy(int stepToSpawn, GameObject enemy)
    {
        enemy.GetComponent<EnemyBehaviour>().StepID = stepToSpawn;
        enemiesMapping.Add(stepToSpawn, enemy);
    }

    public void RemoveEnemy(int stepToRemove)
    {
        if (enemiesMapping.ContainsKey(stepToRemove))
        {
            Destroy(enemiesMapping[stepToRemove]);
            enemiesMapping.Remove(stepToRemove);
        }
            
    }

   
}

