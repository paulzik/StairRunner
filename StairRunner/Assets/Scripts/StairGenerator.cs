using UnityEngine;

public class StairGenerator : MonoBehaviour {

    private int stepCounter;
    public int StepCounter { get { return stepCounter; } }
    private float spawnCounter = 0f;
    public float stairSpeed = 1.0f;

    private static StairGenerator _instance = null;
    public static StairGenerator Get { get { return _instance; } }

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

    // Use this for initialization
    void Start () {
        stepCounter = transform.childCount;
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(new Vector3(0, -0.9f, -1.2f) * Time.deltaTime * stairSpeed);

        spawnCounter+= Time.deltaTime;

        if (spawnCounter >= 1/stairSpeed)
        {
            SpawnSteps();
            spawnCounter = 0;
        }
    }

    private void SpawnSteps()
    {
        GameObject step = Instantiate(this.transform.GetChild(0).gameObject, this.transform);

        //Clean Step
        foreach (Transform child in step.transform)
        {
            Destroy(child.gameObject);
        }

        //Spawn random Object
        SpawnMachine.Get.SpawnRandomEverything(step);
        
        stepCounter++;
        step.name = "StairElement_" + stepCounter;
        step.transform.parent = this.transform;
        step.transform.SetSiblingIndex(0);
        step.transform.localPosition = new Vector3(0, (stepCounter - 1) * 0.9f, (stepCounter - 1) * 1.2f);
        DestroyLastStep();
    }

    private void DestroyLastStep()
    {
        Destroy(transform.GetChild(transform.childCount - 1).gameObject);
        StepObserver.Get.RemoveEnemy(transform.childCount - 1);
    }
}
