using System.Collections;
using UnityEngine;

public class EnemyBreakStep : EnemyBehaviour
{
    private bool triggered = false;
   

    public override void AttackPlayer()
    {
        if (!triggered)
        {
            StartCoroutine(BreakStep());
        }
        else
        {
            //Enable falling
            transform.parent.GetComponent<BoxCollider>().enabled = false;
            CharacterProperties.Get.GetCharacterGameObject().GetComponent<Rigidbody>().useGravity = true;
            CharacterProperties.Get.GetCharacterGameObject().GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    private IEnumerator BreakStep()
    {
        yield return new WaitForSeconds(0.8f);

        //Spawn broken stair with no collider
        //StepObserver.Get.RemoveEnemy(StepID);
        //Trigger the trap
        triggered = true;

        //Disable Mesh renderers (Replace this with other models)
        transform.parent.GetComponent<MeshRenderer>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
    }

    public override void StopAttackPlayer()
    {

    }

}

