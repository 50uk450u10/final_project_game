using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraHeadScript : MonoBehaviour
{
    HydraScript hydra;
    [SerializeField] GameObject fire;
    [SerializeField] PlayerController player;
    [SerializeField] float attackTime;
    [SerializeField] float meleeTime;
    float elapsedTime;
    bool isAttacking = false;
    public enum hydraAttackState { attacking, shooting, hurt }//declare states
    public hydraAttackState Ghidorah { get { return ghidorah; } }//declare property for enum
    hydraAttackState ghidorah = hydraAttackState.shooting;//initialize enum variable to default shooting state
    [SerializeField] Animator hydraAnimator;

    private void Start()
    {
        hydra = GetComponentInParent<HydraScript>();
        hydra.hit.AddListener(switchToAttackState);
    }

    private void Update()
    {
        {
            switch (Ghidorah)
            {
                case hydraAttackState.shooting:
                    elapsedTime += Time.deltaTime;//timer
                    if (elapsedTime >= attackTime)
                    {
                        hydraAnimator.SetTrigger("firing");
                        elapsedTime = 0;//reset timer
                        GameObject p = Instantiate(fire);//create projectile
                        Vector3 playerDirectionV3 = (player.transform.position - transform.position).normalized;//grab 3D coordinates because Unity
                        Vector2 playerDirection = new Vector2(playerDirectionV3.x, playerDirectionV3.y);//set target coordinates to 2D
                        p.GetComponent<Projectile>().spawnProjectileSettings(playerDirection);//force added
                        p.transform.position = transform.position;//origin point of projectile
                        hydraAnimator.SetTrigger("firing");
                    }
                    break;
                case hydraAttackState.attacking:
                    hydraAnimator.SetTrigger("attacking");
                    elapsedTime += Time.deltaTime;
                    if (elapsedTime >= meleeTime)
                    {
                        elapsedTime = 0;
                        hydraAnimator.SetTrigger("attacking");
                        ghidorah = hydraAttackState.shooting;
                    }
                    break;
            }
        }
    }


    public void switchToAttackState()
    {
        elapsedTime = 0;
        ghidorah = hydraAttackState.attacking;
    }
}