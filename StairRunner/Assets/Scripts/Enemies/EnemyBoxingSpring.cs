using System.Collections;
using UnityEngine;
using StairRunner.Utilities;

public class EnemyBoxingSpring : EnemyBehaviour
{
    private Animation boxingSpringAnim;

    private void Start()
    {
        boxingSpringAnim = GetComponent<Animation>();

        RandomBoxingGenerator();
    }

    private void RandomBoxingGenerator()
    {
        int direction = Randomizer.RollTheDice(0, 2);
        Debug.Log(direction);
        if (direction == 1)//Right Direction
        {
            transform.localPosition = new Vector3(1.26f, 1.22f, -0.175f);
            transform.localRotation = Quaternion.Euler(90, 180, -90);
        }
    }

    public override void AttackPlayer()
    {
        enemyActive = true;

        StartCoroutine(boxingSpringThrownDelay());
    }

    private IEnumerator boxingSpringThrownDelay()
    {
        yield return new WaitForSeconds(0.7f / speed);

        boxingSpringAnim.Play();
    }

    public override void StopAttackPlayer()
    {
        enemyActive = false;
    }
}

