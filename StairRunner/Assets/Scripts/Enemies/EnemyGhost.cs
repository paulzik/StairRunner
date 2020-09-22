using System.Collections;
using UnityEngine;

public class EnemyGhost : EnemyBehaviour
{

    public override void AttackPlayer()
    {
        enemyActive = true;

        int towards = 1;
        //Lerp towards player
        if (transform.localPosition.z < CharacterProperties.Get.transform.localPosition.z)
            towards = -1;//Move Right
        else
            towards = 1;//Move Left

        IEnumerator tmp = LerpTowardsPlayer(towards);
        StartCoroutine(tmp);
    }

    private IEnumerator LerpTowardsPlayer(int leftOrRight)
    {
        while(enemyActive)
        {
            transform.Translate(0.6f * Time.deltaTime * speed * leftOrRight, 0, 0);
            yield return new WaitForEndOfFrame();
        }
    }

    public override void StopAttackPlayer()
    {
        enemyActive = false;
    }
}

