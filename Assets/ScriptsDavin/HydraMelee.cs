using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraMelee : MonoBehaviour
{
    [SerializeField] HydraHeadScript head;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (head.Ghidorah == HydraHeadScript.hydraAttackState.shooting)//check if hydra is able to move to the attack state
        {
            head.switchToAttackState();
            if (collision.TryGetComponent<Damagable>(out Damagable damage))//check for damagable component
            {
                damage.Hurt();
            }
        }
    }

}
