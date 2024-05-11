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
    private void Start()
    {
        numOfHeads = 1;
        hydra = GetComponentInParent<HydraScript>();
        hydraStateMachine = new HydraStateMachine();
        hydraAttack = new HydraAttack(hydra, hydraStateMachine, hydraAnimator, player, attackTime, GetComponent<HydraHeadScript>(), dangerArea, fire,numOfHeads);
        hydraShoot = new HydraShoot(hydra, hydraStateMachine, hydraAnimator, player, attackTime, GetComponent<HydraHeadScript>(), dangerArea, fire, numOfHeads);
        hydraState = new HydraState(hydra, hydraStateMachine, hydraAnimator, player, attackTime, GetComponent<HydraHeadScript>(), dangerArea, fire, numOfHeads);
        hydraIdle = new HydraIdle(hydra, hydraStateMachine, hydraAnimator, player, attackTime, GetComponent<HydraHeadScript>(), dangerArea, fire, numOfHeads);
        hydraDead = new HydraDead(hydra, hydraStateMachine, hydraAnimator, player, attackTime, GetComponent<HydraHeadScript>(), dangerArea, fire, numOfHeads);
        hydra.died.AddListener(IncreaseHeads);
        hydra.died.AddListener(() => hydraStateMachine.ChangeState(hydraDead));
        hydra.respawned.AddListener(() => hydraStateMachine.ChangeState(hydraIdle));
        hydraStateMachine.Initialize(hydraShoot);
    }

    private void Update()
    {
        {
            Debug.Log(hydraStateMachine.hCurrentState);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Damagable>(out Damagable damage))//check for damagable component
        {
            damage.Hurt();
        }
    }

    public void Shoot()
    {
        GameObject p = Instantiate(fire);
        Vector3 playerDirectionV3 = (player.transform.position - transform.position).normalized;//grab 3D coordinates because Unity
        Vector2 playerDirection = new Vector2(playerDirectionV3.x, playerDirectionV3.y);//set target coordinates to 2D
        p.GetComponent<Projectile>().spawnProjectileSettings(playerDirection);//force added
        p.transform.position = transform.position;//origin point of projectile
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
}