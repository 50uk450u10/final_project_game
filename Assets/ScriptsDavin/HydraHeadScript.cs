using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraHeadScript : MonoBehaviour
{
    [SerializeField] Projectile fire;
    [SerializeField] PlayerController player;
    [SerializeField] float attackTime;
    [SerializeField] float meleeTime;
    float elapsedTime;
    public enum hydraAttackState {attacking , shooting}//declare states
    public hydraAttackState Ghidorah { get { return ghidorah; } }//declare property for enum
    hydraAttackState ghidorah = hydraAttackState.shooting;//initialize enum variable to default shooting state

    private void Update()
    {
        switch (ghidorah)//godzilla reference
        {
            case hydraAttackState.shooting:
                elapsedTime += Time.deltaTime;//timer
                if (elapsedTime >= attackTime)
                {
                    elapsedTime = 0;//reset timer
                    Projectile p = Instantiate(fire);//create projectile
                    Vector3 playerDirectionV3 = (player.transform.position - transform.position).normalized;//grab 3D coordinates because Unity
                    Vector2 playerDirection = new Vector2(playerDirectionV3.x, playerDirectionV3.y);//set target coordinates to 2D
                    p.spawnProjectileSettings(playerDirection);//force added
                    p.transform.position = transform.position;//origin point of projectile
                }
                break;
            case hydraAttackState.attacking:
                elapsedTime += Time.deltaTime;
                if(elapsedTime >= meleeTime)
                {
                    elapsedTime = 0;
                    ghidorah = hydraAttackState.shooting;
                }
                break;
        }
    }

    public void switchToAttackState()
    {
        elapsedTime = 0;
        ghidorah = hydraAttackState.attacking;
    }

}
