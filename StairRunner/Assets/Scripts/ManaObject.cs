using UnityEngine;

public class ManaObject : MonoBehaviour
{
    private int manaAmmount = 10;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CharacterProperties.Get.UpdateMana(manaAmmount);
            Destroy(gameObject);
        }
    }

    //Set mana ammount on mana spawn
    public void SetManaAmmount(int _manaAmmount)
    {
        manaAmmount = _manaAmmount;
    }
}

