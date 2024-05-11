using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HydraHeadScript : MonoBehaviour
{
    HydraScript hydra;
    [SerializeField] GameObject fire;
    [SerializeField] PlayerController player;
    [SerializeField] float attackTime;
    [SerializeField] float meleeTime;
    [SerializeField] GameObject damageArea;
    float elapsedTime;
    bool isAttacking = false;
    public UnityEvent attack;
    int numOfHeads;
    //public enum hydraAttackState { attacking, shooting, hurt }//declare states
    //public hydraAttackState Ghidorah { get { return ghidorah; } }//declare property for enum
    //hydraAttackState ghidorah = hydraAttackState.shooting;//initialize enum variable to default shooting state
    [SerializeField] Animator hydraAnimator;
    public HydraState hydraState { get; private set; }
    public HydraAttack hydraAttack { get; private set; }
    public HydraStateMachine hydraStateMachine { get; private set; }
    public HydraIdle hydraIdle { get; private set; }
    public HydraShoot hydraShoot { get; private set; }
    public HydraDead hydraDead { get; private set; }
    [SerializeField] BoxCollider2D dangerArea;
    [SerializeField] GameObject damagableArea;
    public UnityEvent swing;
    private void Start()
    {
        hydraAnimator.SetFloat("multiplier", (DifficultyManager.difficultyMultiplier/ attackTime) + 1.65f);
        numOfHeads = 1;
        hydra = GetComponentInParent<HydraScript>();
        hydraStateMachine = new HydraStateMachine();
        hydraAttack = new HydraAttack(hydra, hydraStateMachine, hydraAnimator, player, attackTime, GetComponent<HydraHeadScript>(), dangerArea, fire,numOfHeads, damageArea, damagableArea);
        hydraShoot = new HydraShoot(hydra, hydraStateMachine, hydraAnimator, player, attackTime, GetComponent<HydraHeadScript>(), dangerArea, fire, numOfHeads, damageArea, damagableArea);
        hydraState = new HydraState(hydra, hydraStateMachine, hydraAnimator, player, attackTime, GetComponent<HydraHeadScript>(), dangerArea, fire, numOfHeads, damageArea, damagableArea);
        hydraIdle = new HydraIdle(hydra, hydraStateMachine, hydraAnimator, player, attackTime, GetComponent<HydraHeadScript>(), dangerArea, fire, numOfHeads, damageArea, damagableArea);
        hydraDead = new HydraDead(hydra, hydraStateMachine, hydraAnimator, player, attackTime, GetComponent<HydraHeadScript>(), dangerArea, fire, numOfHeads, damageArea, damagableArea);
        hydra.died.AddListener(IncreaseHeads);
        hydra.died.AddListener(() => hydraStateMachine.ChangeState(hydraDead));
        hydra.respawned.AddListener(() => hydraStateMachine.ChangeState(hydraIdle));
        swing.AddListener(Swinging);
        damagableArea.SetActive(false);
        damageArea.SetActive(false);
        hydraStateMachine.Initialize(hydraShoot);
    }

    private void Update()
    {
        {
            /*switch (Ghidorah)
            {
                case hydraAttackState.shooting:
                    elapsedTime += Time.deltaTime;//timer
                    if (elapsedTime >= attackTime)
                    {
                        hydraAnimator.SetBool("firing", true);
                        elapsedTime = 0;//reset timer
                        GameObject p = Instantiate(fire);//create projectile
                        Vector3 playerDirectionV3 = (player.transform.position - transform.position).normalized;//grab 3D coordinates because Unity
                        Vector2 playerDirection = new Vector2(playerDirectionV3.x, playerDirectionV3.y);//set target coordinates to 2D
                        p.GetComponent<Projectile>().spawnProjectileSettings(playerDirection);//force added
                        p.transform.position = transform.position;//origin point of projectile
                        hydraAnimator.SetBool("firing", false);
                    }
                    break;
                case hydraAttackState.attacking:
                    hydraAnimator.SetBool("attacking", true);
                    elapsedTime += Time.deltaTime;
                    if (elapsedTime >= meleeTime)
                    {
                        elapsedTime = 0;
                        hydraAnimator.SetBool("attacking", false);
                        ghidorah = hydraAttackState.shooting;
                    }
                    break;
            }*/
        }
    }

    public void Shoot(int num)
    {
        if (num == 1)
        {
            GameObject p = Instantiate(fire);
            Vector3 playerDirectionV3 = (player.transform.position - transform.position).normalized;//grab 3D coordinates because Unity
            Vector2 playerDirection = new Vector2(playerDirectionV3.x, playerDirectionV3.y);//set target coordinates to 2D
            p.GetComponent<Projectile>().spawnProjectileSettings(playerDirection);//force added
            p.transform.position = transform.position;//origin point of projectile
            Vector3 target = player.transform.position;
            target.z = 0;
            Vector3 start = transform.position;
            target.x -= start.x;
            target.y -= start.y;
            float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
            p.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else if (num == 2)
        {
            GameObject p = Instantiate(fire);
            GameObject b = Instantiate(fire);
            Vector3 playerDirectionV3 = (player.transform.position - transform.position).normalized;//grab 3D coordinates because Unity
            Vector2 playerDirection = new Vector2(playerDirectionV3.x, playerDirectionV3.y);//set target coordinates to 2D
            p.GetComponent<Projectile>().spawnProjectileSettings(new Vector2(playerDirection.x, playerDirection.y + 0.1f).normalized);//force added
            b.GetComponent<Projectile>().spawnProjectileSettings(new Vector2(playerDirection.x, playerDirection.y - 0.1f).normalized);
            p.transform.position = transform.position;//origin point of projectile
            b.transform.position = transform.position;
            Vector3 target = player.transform.position;
            target.z = 0;
            Vector3 start = transform.position;
            target.x -= start.x;
            target.y -= start.y;
            float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
            p.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + .1f));
            b.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - .1f));
        }
        else if (num == 3)
        {
            GameObject p = Instantiate(fire);
            GameObject b = Instantiate(fire);
            GameObject d = Instantiate(fire);
            Vector3 playerDirectionV3 = (player.transform.position - transform.position).normalized;//grab 3D coordinates because Unity
            Vector2 playerDirection = new Vector2(playerDirectionV3.x, playerDirectionV3.y);//set target coordinates to 2D
            p.GetComponent<Projectile>().spawnProjectileSettings(new Vector2(playerDirection.x, playerDirection.y + 0.15f).normalized);//force added
            b.GetComponent<Projectile>().spawnProjectileSettings(new Vector2(playerDirection.x, playerDirection.y + 0.15f).normalized);
            d.GetComponent<Projectile>().spawnProjectileSettings(playerDirection);
            p.transform.position = transform.position;//origin point of projectile
            b.transform.position = transform.position;
            d.transform.position = transform.position;
            Vector3 target = player.transform.position;
            target.z = 0;
            Vector3 start = transform.position;
            target.x -= start.x;
            target.y -= start.y;
            float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
            p.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 0.15f));
            b.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 0.15f));
            d.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

    }

    public int HeadCount()
    {
        return numOfHeads;
    }

    public void IncreaseHeads()
    {
        if (numOfHeads < 3)
        {
            numOfHeads++;
        }
    }
    public void Swinging()
    {
        if (hydraStateMachine.hCurrentState != hydraAttack)
        {
            hydraStateMachine.ChangeState(hydraAttack);
        }
    }
}