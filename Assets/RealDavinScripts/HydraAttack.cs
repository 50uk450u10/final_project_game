using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraAttack : HydraState
{
    Coroutine Slam;
    Coroutine SlamAnimation;
    public HydraAttack(HydraScript hydra, HydraStateMachine hydraStateMachine, Animator hydraAnimator, PlayerController player, float attackSpeed, HydraHeadScript head, BoxCollider2D dangerArea, GameObject p, int numOfHeads, GameObject damageArea, GameObject damagableArea) : base(hydra, hydraStateMachine, hydraAnimator, player, attackSpeed, head, dangerArea,p, numOfHeads, damageArea, damagableArea)
    {

    }
    public override void Enter()
    {
        hydraAnimator.SetBool("attacking", true);
        SlamAnimation = head.StartCoroutine(SerpentSLAMAnimation());
        Slam = head.StartCoroutine(SerpentSLAM());
    }
    public override void Exit()
    {
        hydraAnimator.SetBool("attacking", false);
        head.StopCoroutine(Slam);
        head.StopCoroutine(SlamAnimation);
        Slam = null;
        SlamAnimation = null;
    }
    IEnumerator SerpentSLAM()
    {
        damageArea.gameObject.SetActive(true);
        Quaternion startingPos = damageArea.transform.rotation;
        yield return new WaitForSecondsRealtime(0.5f);
        while (Mathf.CeilToInt(damageArea.gameObject.transform.localEulerAngles.z) != 90)
        {
            yield return new WaitForEndOfFrame();
            damageArea.gameObject.transform.localEulerAngles = Vector3.Lerp(damageArea.gameObject.transform.localEulerAngles, new Vector3(0, 0, 90), .01f);
            Debug.Log("Hello");
        }
        damageArea.transform.rotation = startingPos;
        damageArea.gameObject.SetActive(false);
    }
    IEnumerator SerpentSLAMAnimation()
    {
        head.hydraSounds.PlayOneShot(head.Slam);
        yield return new WaitForSeconds(1.2f);
        hydraAnimator.speed = 0;
        damagableArea.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        damagableArea.gameObject.SetActive(false);
        hydraAnimator.speed = 1;
        yield return new WaitForSeconds(.5f);
        head.hydraStateMachine.ChangeState(head.hydraIdle);
    }
}
