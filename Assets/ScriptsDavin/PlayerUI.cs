using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] Image playerHealth;
    [SerializeField] Image followerHealth;
    [SerializeField] Image hydraHealth;
    [SerializeField] GameObject hydraHealthObject;
    PlayerController1 player;
    AllyScript1 ally;
    HydraScript1 hydra;
    Damagable1 playerDamagable;
    Damagable1 allyDamagable;
    Damagable1 hydraDamagable;
    Vector3 normalHydraHealthPos;
    Coroutine coroutine;
    private void OnEnable()
    {
        player = FindAnyObjectByType<PlayerController1>();
        playerHealth.fillAmount = player.MaxHealth;
        playerDamagable = player.gameObject.GetComponent<Damagable1>();
        playerDamagable.onDamage.AddListener(ChangeHealth);
        ally = FindAnyObjectByType<AllyScript1>();
        followerHealth.fillAmount = ally.MaxHealth;
        allyDamagable = ally.gameObject.GetComponent<Damagable1>();
        allyDamagable.onDamage.AddListener(ChangeHealthAlly);
        hydra = FindAnyObjectByType<HydraScript1>().GetComponent<HydraScript1>();
        hydraHealth.fillAmount = hydra.MaxHealth;
        hydraDamagable = hydra.gameObject.GetComponent<Damagable1>();
        hydraDamagable.onDamage.AddListener(ChangeHydraHealth);
        normalHydraHealthPos = hydraHealthObject.transform.position;
        hydra.died.AddListener(ChangeHydraHealthPos);
        hydra.respawned.AddListener(ChangeHydraHealthPosBack);
        hydra.respawned.AddListener(ChangeHydraHealth);
    }
    public void ChangeHealth()
    {
        playerHealth.fillAmount = player.health / player.MaxHealth;
    }
    public void ChangeHealthAlly()
    {
        followerHealth.fillAmount = ally.health / ally.MaxHealth;
    }
    public void ChangeHydraHealth()
    {
        hydraHealth.fillAmount = hydra.health / hydra.MaxHealth;
    }
    public void ChangeHydraHealthPosBack()
    {
        coroutine = StartCoroutine(MoveBar());
    }
    public void ChangeHydraHealthPos()
    {
        hydraHealthObject.transform.position = new Vector3(hydraHealthObject.transform.position.x + 2000, hydraHealthObject.transform.position.y);
    }

    IEnumerator MoveBar()
    {
        while(Mathf.CeilToInt(hydraHealthObject.transform.position.x) != Mathf.CeilToInt(normalHydraHealthPos.x))
        {
            yield return new WaitForEndOfFrame();
            hydraHealthObject.transform.position = Vector2.Lerp(hydraHealthObject.transform.position, normalHydraHealthPos, .01f);
        }
        StopCoroutine(coroutine);
    }
}
