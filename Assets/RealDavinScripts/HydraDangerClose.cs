using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraDangerClose : MonoBehaviour
{
    BoxCollider2D dangerClose;
    bool attacked = false;
    [SerializeField] HydraHeadScript hydraHeadScript;
    // Start is called before the first frame update
    void OnEnable ()
    {
        dangerClose = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hydraHeadScript.attack.Invoke();
    }
}
