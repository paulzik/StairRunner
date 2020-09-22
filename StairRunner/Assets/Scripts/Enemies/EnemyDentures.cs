using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDentures : EnemyBehaviour
{
    private Animator anim;
    private float positionX;
    public void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    public void Update()
    {
        positionX = transform.localPosition.x;

        if (positionX > 1.35f)
        {
            transform.localEulerAngles = new Vector3(0, -90f, 0);
        }else if(positionX < -1.5f)
        {
            transform.localEulerAngles = new Vector3(0, 90f, 0);

        }
    }


    public override void AttackPlayer()
    {

    }

    public override void StopAttackPlayer()
    {

    }

}
