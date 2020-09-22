using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour
{
    private int stepID;
    public int StepID {
        get { return stepID; }
        set { stepID = value; }
    }

    protected int speed = 1;
    protected bool enemyActive = false;

    public abstract void AttackPlayer();
    public abstract void StopAttackPlayer();

    public virtual void AnimationController() { }

    public void KillEnemy()
    {
        //Destroy enemy and remove him from dictionary
        StepObserver.Get.RemoveEnemy(stepID);
        Destroy(this.gameObject);
    }
}

