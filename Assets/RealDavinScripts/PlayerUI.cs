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
    PlayerController player;
    AllyScript ally;
    HydraScript hydra;
    Damagable playerDamagable;
    Damagable allyDamagable;
    Damagable hydraDamagable;
    Vector3 normalHydraHealthPos;
    Coroutine coroutine;
    private void OnEnable()
    {
        player = FindAnyObjectByType<PlayerController>();
        playerHealth.fillAmount = player.MaxHealth;
        playerDamagable = player.gameObject.GetComponent<Damagable>();
        playerDamagable.onDamage.AddListener(ChangeHealth);
        ally = FindAnyObjectByType<AllyScript>();
        followerHealth.fillAmount = ally.MaxHealth;
        allyDamagable = ally.gameObject.GetComponent<Damagable>();
        allyDamagable.onDamage.AddListener(ChangeHealthAlly);
        hydra = FindAnyObjectByType<HydraScript>().GetComponent<HydraScript>();
        hydraHealth.fillAmount = hydra.MaxHealth;
        hydraDamagable = hydra.gameObject.GetComponent<Damagable>();
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
