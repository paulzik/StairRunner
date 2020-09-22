using UnityEngine;

public class AndroidControlls : MonoBehaviour
{
    private bool swipeUp, swipeDown;
    private Vector2 startTouch, swipeDelta;
    private bool isDraging = false;
    private float charstartDragPos = 0f;
    private int screenWidth;
    private float startDragPosition;
    private float scaleFactor;
    private Transform player;
    private float newPlayerPosition;

    private void Start()
    {
        screenWidth = Screen.width;
        scaleFactor = 0.39f / screenWidth;
        player = CharacterProperties.Get.transform;
    }

    private void Update()
    {
        swipeUp = swipeDown = false;

        if (Input.GetMouseButtonDown(0))
        {
            isDraging = true;
            startTouch = Input.mousePosition;
            startDragPosition = startTouch.x;
            
            charstartDragPos = player.localPosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Reset();
        }

        //Mobile Inputs
        if(Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isDraging = true;
                startTouch = Input.touches[0].position;
                
            }else if(Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                Reset();
            }
        }

        //Calculate the distance
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - startTouch;

            newPlayerPosition = -charstartDragPos - ((4.7f * swipeDelta.x) / screenWidth);

            //Check boundaries
            if (newPlayerPosition > 1.35f)
            {
                newPlayerPosition = 1.35f;
            }else if(newPlayerPosition < -1.35f)
            {
                newPlayerPosition = -1.35f;
            }

            player.localPosition = new Vector3(-newPlayerPosition, player.localPosition.y, player.localPosition.z);

            //if (swipeDelta.x > 0)
            //{
            //    if(player.localRotation.eulerAngles.y != 90)
            //    {
            //        player.Rotate(new Vector3(0, 90, 0));
            //    }
            //}
            //else
            //{
            //    if (player.localRotation.eulerAngles.y != -90)
            //    {
            //        player.Rotate(new Vector3(0, -90, 0));
            //    }
            //}

        }



        //Cross dead zone check
        if (swipeDelta.magnitude > 100)
        {
            //which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            
            if(Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or Right

            }
            else
            {
                
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
                Reset();
            }

            
        }
    }

    private void Reset()
    {
        //player.localRotation = new Quaternion();
        startTouch = swipeDelta = Vector2.zero;
        isDraging = false;
    }

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
}

