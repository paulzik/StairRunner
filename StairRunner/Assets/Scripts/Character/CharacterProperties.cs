using UnityEngine;

public class CharacterProperties : MonoBehaviour
{
    private static CharacterProperties _instance = null;
    public static CharacterProperties Get { get { return _instance; } }

    private GameObject characterGameObject;

    public void Start()
    {
        characterGameObject = gameObject;
    }

    //Current Values
    private int currentStep = 1;
    public int CurrentStep {
        get { return currentStep; }
        set {
                this.currentStep =  value;
                StepObserver.Get.SetCurrentStep(value);
            }
    }

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

    private int mana;
    
    public void UpdateMana(int _mana)
    {
        mana += _mana;
    }

    public GameObject GetCharacterGameObject()
    {
        return characterGameObject;
    }
}
