using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static Text stepCounterText;

    void Start()
    {
        stepCounterText = transform.Find("Steps/StepCounter").GetComponent<Text>();
    }


    public static void UpdateStepCounter(int stepCounter)
    {
        if (stepCounterText)
            stepCounterText.text = stepCounter.ToString();
    }


}

