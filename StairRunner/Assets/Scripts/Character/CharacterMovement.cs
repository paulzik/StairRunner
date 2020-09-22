using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private int currentStep = 1;

    private bool canGoLeft = true, canGoRight = true;
    private int maxStep = 1;
    public AndroidControlls androidControlls;
    private Rigidbody rb;
    
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        //Mobile Controlls
        if ((Input.GetKeyDown(KeyCode.W) || androidControlls.SwipeUp))
        {
            //if (canJump)
            {
                ChangeStep(1);
            }

        }

        if (Input.GetKeyDown(KeyCode.S) || androidControlls.SwipeDown)
        {
            //if (canJump)
            {
                ChangeStep(-1);
            }

        }

        if (Input.GetKey(KeyCode.A))
        {
            if (!canGoLeft)
                return;

            if (transform.localPosition.z > 0.39f)
            {
                canGoLeft = false;
            }
            else
            {
                transform.Translate(new Vector3(-0.1f, 0, 0));
                canGoRight = true;
            }
                
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (!canGoRight)
                return;

            if (transform.localPosition.z < -0.39f)
            {
                canGoRight = false;
            }
            else
            {
                transform.Translate(new Vector3(0.1f, 0, 0));
                canGoLeft = true;
            }

        }


    }

    /// <summary>
    /// 1 For Up/ -1 For down
    /// </summary>
    /// <param name="changeMode"></param>
    private void ChangeStep(int changeMode)
    {
        //Get next step
        int nextStepID = transform.parent.GetSiblingIndex() - changeMode;

        if (nextStepID < 0)
            return;

        Transform nextStep = StairGenerator.Get.transform.GetChild(nextStepID);
        //Deparent
        transform.parent = StairGenerator.Get.transform;

        //Parent to step
        transform.parent = nextStep;
        //Jump to next step
        StartCoroutine(JumpCooroutine(changeMode));

        currentStep += changeMode;
        if (maxStep < currentStep)
        {
            UIManager.UpdateStepCounter(currentStep);
            maxStep = currentStep;
        }
        CharacterProperties.Get.CurrentStep = currentStep;
    }

    IEnumerator JumpCooroutine(int changeMode)
    {
        Vector3 point = transform.position + new Vector3(0, 0.9f, 1.2f) * changeMode;
        GameObject jumpPoint = new GameObject();
        jumpPoint.transform.parent = transform.parent;
        jumpPoint.transform.position = point;

        bool finished = false;

        Transform startMarker = transform;

        float startTime;

        startTime = Time.time;
        

        while (!finished)
        {
            // Distance moved = time * speed.
            float distCovered = (Time.time - startTime) * 1;

            float fracJourney = distCovered / Vector3.Distance(startMarker.position, jumpPoint.transform.position);

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startMarker.position, jumpPoint.transform.position, fracJourney);
            if (fracJourney >= 0.4)
            {
                finished = true;
                transform.position = jumpPoint.transform.position;
                Destroy(jumpPoint);
            }

            yield return null;
        }

    }



    void OnDestroy()
    {
        Debug.Log("GAME OVER");
    }
}