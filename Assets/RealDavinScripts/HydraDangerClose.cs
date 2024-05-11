using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HydraDangerClose : MonoBehaviour
{
    BoxCollider2D dangerClose;
    [SerializeField] HydraHeadScript hydraHeadScript;
    // Start is called before the first frame update
    void OnEnable ()
    {
        dangerClose = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController player))
        {
            hydraHeadScript.swing.Invoke();
        }
    }
}
